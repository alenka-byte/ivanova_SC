import numpy as np
import matplotlib.pyplot as plt
from matplotlib import animation
from matplotlib import colors
from matplotlib.widgets import Button, Slider
from skimage import draw
import tkinter as tk
from tkinter import ttk

# Константы
neighbourhood = ((-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1))
empty, tree, fire, water = 0, 1, 2, 3
color_list = ['white', 'green', 'orange', 'blue', 'lightblue']
cmap = colors.ListedColormap(color_list)
bounds = [0, 1, 2, 3, 4, 5]
norm = colors.BoundaryNorm(bounds, cmap.N)


class ForestFireSimulation:
    def __init__(self):
        # Параметры симуляции
        self.forest_fraction = 0.7
        self.p = 0.1  # Вероятность роста дерева
        self.f = 0.0001  # Вероятность возгорания
        self.nx, self.ny = 200, 200
        self.rain_radius = 12
        self.rain_effectiveness = 1.0  # Эффективность дождя

        # Параметры облака
        self.cloud_radius = 12
        self.cloud_y, self.cloud_x = 50, 50
        self.cloud_direction = 1
        self.cloud_speed = 2
        self.cloud_active = True

        # Состояние симуляции
        self.x = None
        self.anim = None
        self.is_running = False
        self.frame = 0

        # Создание интерфейса
        self.setup_ui()
        self.init_simulation()

    def setup_ui(self):
        # Создание основного окна Tkinter
        self.root = tk.Tk()
        self.root.title("Управление симуляцией лесного пожара")
        self.root.geometry("300x510")

        # Фрейм для параметров
        params_frame = ttk.LabelFrame(self.root, text="Параметры симуляции", padding=10)
        params_frame.pack(fill="both", padx=10, pady=5)

        # Параметры леса
        ttk.Label(params_frame, text="Плотность леса:").pack(anchor="w")
        self.forest_var = tk.DoubleVar(value=0.7)
        forest_scale = ttk.Scale(params_frame, from_=0.1, to=0.9, variable=self.forest_var,
                                 orient="horizontal", command=self.update_params)
        forest_scale.pack(fill="x", pady=(0, 10))

        ttk.Label(params_frame, text="Вероятность роста деревьев:").pack(anchor="w")
        self.p_var = tk.DoubleVar(value=0.1)
        p_scale = ttk.Scale(params_frame, from_=0.0, to=0.5, variable=self.p_var,
                            orient="horizontal", command=self.update_params)
        p_scale.pack(fill="x", pady=(0, 10))

        ttk.Label(params_frame, text="Вероятность возгорания:").pack(anchor="w")
        self.f_var = tk.DoubleVar(value=0.0001)
        f_scale = ttk.Scale(params_frame, from_=0.0, to=0.001, variable=self.f_var,
                            orient="horizontal", command=self.update_params)
        f_scale.pack(fill="x", pady=(0, 10))

        # Параметры облака
        cloud_frame = ttk.LabelFrame(self.root, text="Параметры облака", padding=10)
        cloud_frame.pack(fill="both", padx=10, pady=5)

        ttk.Label(cloud_frame, text="Радиус дождя:").pack(anchor="w")
        self.rain_radius_var = tk.IntVar(value=12)
        rain_scale = ttk.Scale(cloud_frame, from_=5, to=25, variable=self.rain_radius_var,
                               orient="horizontal", command=self.update_params)
        rain_scale.pack(fill="x", pady=(0, 10))

        ttk.Label(cloud_frame, text="Эффективность дождя:").pack(anchor="w")
        self.rain_eff_var = tk.DoubleVar(value=1.0)
        rain_eff_scale = ttk.Scale(cloud_frame, from_=0.0, to=1.0, variable=self.rain_eff_var,
                                   orient="horizontal", command=self.update_params)
        rain_eff_scale.pack(fill="x", pady=(0, 10))

        ttk.Label(cloud_frame, text="Скорость облака:").pack(anchor="w")
        self.cloud_speed_var = tk.IntVar(value=2)
        speed_scale = ttk.Scale(cloud_frame, from_=1, to=5, variable=self.cloud_speed_var,
                                orient="horizontal", command=self.update_params)
        speed_scale.pack(fill="x", pady=(0, 10))

        # Чекбокс для включения/выключения облака
        self.cloud_active_var = tk.BooleanVar(value=True)
        cloud_check = ttk.Checkbutton(cloud_frame, text="Облако активно",
                                      variable=self.cloud_active_var, command=self.update_params)
        cloud_check.pack(anchor="w", pady=(0, 10))

        # Фрейм для кнопок
        buttons_frame = ttk.Frame(self.root)
        buttons_frame.pack(fill="x", padx=10, pady=10)

        # Кнопки управления
        self.start_button = ttk.Button(buttons_frame, text="Запустить", command=self.start_simulation)
        self.start_button.pack(side="left", padx=5, expand=True, fill="x")

        self.stop_button = ttk.Button(buttons_frame, text="Стоп", command=self.stop_simulation, state="disabled")
        self.stop_button.pack(side="left", padx=5, expand=True, fill="x")

        self.reset_button = ttk.Button(buttons_frame, text="Сбросить", command=self.reset_simulation)
        self.reset_button.pack(side="left", padx=5, expand=True, fill="x")

        self.close_button = ttk.Button(buttons_frame, text="Закрыть", command=self.close_simulation)
        self.close_button.pack(side="left", padx=5, expand=True, fill="x")

    def init_simulation(self):
        self.x = np.zeros((self.ny, self.nx))
        for y in range(1, self.ny - 1):
            for x in range(1, self.nx - 1):
                if np.random.random() < self.forest_fraction:
                    self.x[y, x] = tree
                else:
                    self.x[y, x] = empty

        # Добавление водоемов
        self.x[1:self.ny, 2:15] = water
        for _ in range(5):
            center_y = np.random.randint(20, 180)
            center_x = np.random.randint(20, 180)
            radius = np.random.randint(3, 10)
            rr, cc = draw.disk((center_y, center_x), radius)
            self.x[rr, cc] = water

    def create_rain_cloud(self, center_y, center_x, shape_parameter=8):
        """Создает облако в форме эллипса"""
        cloud = []
        for dy in range(-shape_parameter, shape_parameter + 1):
            for dx in range(-shape_parameter * 2, shape_parameter * 2 + 1):
                if (dx / (shape_parameter * 1.5)) ** 2 + (dy / shape_parameter) ** 2 <= 1:
                    cloud.append((dy, dx))
        return cloud

    def apply_rain(self, x, cloud_center):
        """Применяет эффект дождя - тушит огонь в области облака"""
        if not self.cloud_active:
            return x.copy()

        cy, cx = cloud_center
        rain_affected = x.copy()
        radius = self.rain_radius

        for dy in range(-radius, radius + 1):
            for dx in range(-radius, radius + 1):
                if dy ** 2 + dx ** 2 <= radius ** 2:
                    y, x_coord = cy + dy, cx + dx
                    if 0 <= y < self.ny and 0 <= x_coord < self.nx:
                        if rain_affected[y, x_coord] == fire:
                            if np.random.random() < self.rain_effectiveness:
                                rain_affected[y, x_coord] = empty
        return rain_affected

    def count_neighbor_fires(self, x, iy, ix):
        """Подсчитывает количество горящих соседей вокруг клетки"""
        fire_count = 0
        for dy, dx in neighbourhood:
            ny, nx_coord = iy + dy, ix + dx
            if 0 <= ny < len(x) and 0 <= nx_coord < len(x[0]):
                if x[ny, nx_coord] == fire:
                    fire_count += 1
        return fire_count

    def iterate(self, x, cloud_pos):
        """Один шаг симуляции"""
        # Сначала применяем дождь от облака
        x_after_rain = self.apply_rain(x, cloud_pos)
        x1 = x_after_rain.copy()

        for ix in range(1, self.nx - 1):
            for iy in range(1, self.ny - 1):
                if x_after_rain[iy, ix] == empty and np.random.random() <= self.p:
                    x1[iy, ix] = tree

                elif x_after_rain[iy, ix] == water:
                    x1[iy, ix] = water

                elif x_after_rain[iy, ix] == tree:
                    for dx, dy in neighbourhood:
                        if x_after_rain[iy + dy, ix + dx] == fire:
                            modified_probability = 0.478
                            if abs(dx) == abs(dy):
                                modified_probability *= 0.8
                            if np.random.random() < modified_probability:
                                x1[iy, ix] = fire
                                break
                    else:
                        if np.random.random() <= self.f:
                            x1[iy, ix] = fire

                elif x_after_rain[iy, ix] == fire:
                    neighbor_fires = self.count_neighbor_fires(x_after_rain, iy, ix)
                    if neighbor_fires >= 8:
                        x1[iy, ix] = empty
                    else:
                        if np.random.random() < 0.1:
                            x1[iy, ix] = empty
                        else:
                            x1[iy, ix] = fire

        return x1

    def animate(self, frame):
        """Функция анимации"""
        if self.is_running:
            # Движение облака
            if self.cloud_active:
                self.cloud_x += self.cloud_direction * self.cloud_speed
                self.cloud_y += int(np.sin(frame / 20) * 1.5)

                # Отражение от границ
                if self.cloud_x >= self.nx - self.cloud_radius:
                    self.cloud_direction = -1
                elif self.cloud_x <= self.cloud_radius:
                    self.cloud_direction = 1

                self.cloud_y = max(self.cloud_radius, min(self.ny - self.cloud_radius, self.cloud_y))

            # Обновление состояния леса
            self.x = self.iterate(self.x, (self.cloud_y, self.cloud_x))

            # Создание временного массива для отображения облака
            display_x = self.x.copy()

            # Рисуем облако
            if self.cloud_active:
                cloud_shape = self.create_rain_cloud(self.cloud_y, self.cloud_x, self.cloud_radius)
                for dy, dx in cloud_shape:
                    y, x_coord = self.cloud_y + dy, self.cloud_x + dx
                    if 0 <= y < self.ny and 0 <= x_coord < self.nx:
                        if display_x[y, x_coord] != water:
                            display_x[y, x_coord] = 4

            self.im.set_array(display_x)

            fire_count = np.sum(self.x == fire)
            tree_count = np.sum(self.x == tree)
            self.title.set_text(f'Кадр: {frame} | Пожаров: {fire_count} | Деревьев: {tree_count}')

        return [self.im, self.title]

    def setup_matplotlib(self):
        self.fig = plt.figure(figsize=(12, 8))
        self.ax = self.fig.add_subplot(111)
        self.ax.set_axis_off()
        self.im = self.ax.imshow(self.x, cmap=cmap, norm=norm, interpolation='nearest')
        self.title = self.ax.set_title('Лесной пожар с эффектом распространения огня', fontsize=14)

    def start_simulation(self):
        if not self.is_running:
            self.is_running = True
            self.start_button.config(state="disabled")
            self.stop_button.config(state="normal")
            if self.anim is None:
                self.setup_matplotlib()
                self.anim = animation.FuncAnimation(self.fig, self.animate, frames=1000,
                                                    interval=50, blit=True, repeat=True)
            plt.show(block=False)

    def stop_simulation(self):
        self.is_running = False
        self.start_button.config(state="normal")
        self.stop_button.config(state="disabled")

    def reset_simulation(self):
        self.stop_simulation()
        self.init_simulation()
        if hasattr(self, 'im'):
            self.im.set_array(self.x)
            plt.draw()

    def close_simulation(self):
        self.stop_simulation()
        if self.anim:
            self.anim.event_source.stop()
        plt.close('all')
        self.root.quit()
        self.root.destroy()

    def update_params(self, event=None):
        self.forest_fraction = self.forest_var.get()
        self.p = self.p_var.get()
        self.f = self.f_var.get()
        self.rain_radius = self.rain_radius_var.get()
        self.rain_effectiveness = self.rain_eff_var.get()
        self.cloud_speed = self.cloud_speed_var.get()
        self.cloud_active = self.cloud_active_var.get()

    def run(self):
        self.root.mainloop()

if __name__ == "__main__":
    app = ForestFireSimulation()
    app.run()