import math
from math import inf
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from matplotlib import animation
from matplotlib import colors
from skimage import draw
import random
import openpyxl

class Customer:
    def __init__(self, agent_id, birth_time):
        self.id = agent_id
        self.birth_time = birth_time
        self.death_time = None

class QueueingSystem:
    def __init__(self, mu):
        self.mu = mu
        self.x = 0
        self.customers = []
        self.next_id = 0

    def add_customer(self, current_time):
        customer = Customer(self.next_id, current_time)
        self.next_id += 1
        self.customers.append(customer)
        self.x += 1

    def remove_customer(self, current_time):
        if self.x > 0:
            for c in reversed(self.customers):
                if c.death_time is None:
                    c.death_time = current_time
                    break
            self.x -= 1

    def service_rate(self):
        if self.x == 0:
            return 0
        return (self.mu * self.x) * (1 / math.sqrt(1 + self.x))

class Environment:
    def __init__(self, Q, lam):
        self.Q = Q
        self.lam = lam
        self.state = random.randint(0, len(Q) - 1)

    def next_transition_time(self, t):
        rate = -self.Q[self.state][self.state]
        if rate <= 0:
            return float('inf')
        return t + random.expovariate(rate)

    def transition(self):
        r = random.random()
        s = 0
        total_rate = -self.Q[self.state][self.state]
        for j in range(len(self.Q)):
            if j != self.state:
                prob = self.Q[self.state][j] / total_rate
                s += prob
                if r <= s:
                    self.state = j
                    break

    def arrival_rate(self):
        return self.lam[self.state]

mu = 1
num_steps = 100000
t = 0
time_history = []
x_history = []
time_steps = []
T = 1
Qq = [
    [-1.0, 0.2, 0.8],
    [0.5, -1.5, 1.0],
    [0.8, 1.2, -2.0]
]
lamm = [1, 2, 3]
Q = [[q_ij * T for q_ij in row] for row in Qq]
lam = [l * T for l in lamm]

env = Environment(Q, lam)
system = QueueingSystem(mu)

print("Запуск агентного моделирования...")
for step in range(num_steps):
    eta = env.next_transition_time(t)
    tau = t + random.expovariate(env.arrival_rate())
    if system.x > 0:
        sig = t + random.expovariate(system.service_rate())
    else:
        sig = float('inf')

    x_history.append(system.x)

    min_time = min(tau, eta, sig)
    if min_time == tau:
        dt = tau - t
        t = tau
        system.add_customer(t)
    elif min_time == eta:
        dt = eta - t
        t = eta
        env.transition()
    else:
        dt = sig - t
        t = sig
        system.remove_customer(t)

    time_steps.append(dt)
    time_history.append(t)

p = [0] * (max(x_history) + 1)
for i in range(len(time_steps)):
    p[x_history[i]] += time_steps[i]
p = [time / t for time in p]

fig, ax = plt.subplots(1, 1, figsize=(12, 6))

states = range(len(p))
ax.plot(states, p, 'b-o', linewidth=2, markersize=4, label='Стационарное распределение')
ax.set_xlabel('Состояние x')
ax.set_ylabel('Вероятность')
ax.set_title('Стационарное распределение вероятностей')
ax.grid(True, alpha=0.3)
ax.legend()

plt.tight_layout()
plt.show()

print(f"Общее время моделирования: {t:.2f}")
print(f"Всего создано заявок: {system.next_id}")
print("Вероятности состояний:")
for i in range(len(p)):
    if p[i] > 0.0001:
        print(f"P(x={i:3d}) = {p[i]:.4f}")

print(f"Сумма вероятностей: {sum(p):.4f}")
