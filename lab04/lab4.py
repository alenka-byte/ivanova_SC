import math
import random

N = 100000
con_random = []
beta =  4294967299
M = pow(2, 63)
x_start = beta
for i in range(N):
    x_start = (beta * x_start) % M
    con_random.append(x_start / M)

built_random = [random.random() for _ in range(N)]


def fibonacci_generator(n):
    fib_result = []
    x_prev2 = 0.4  # x_{n-2}
    x_prev1 = 1.7  # x_{n-1}
    for i in range(n):
        x_current = (x_prev1 + x_prev2) % 1
        fib_result.append(x_current)
        x_prev2 = x_prev1
        x_prev1 = x_current
    return fib_result

fibonacci_random = fibonacci_generator(N)
teor_mean = 0.5
teor_var = 1 / 12
def calculate_mean_and_variance(sample):
    n = len(sample)
    total = 0
    for x in sample:
        total += x
    mean = total / n
    s = 0
    for x in sample:
        s += (x - mean) ** 2
    var = s / (n - 1)
    return mean, var

con_random_mean, con_random_var = calculate_mean_and_variance(con_random)
fibonacci_mean, fibonacci_var = calculate_mean_and_variance(fibonacci_random)
built_mean, built_var = calculate_mean_and_variance(built_random)

print(f"{'':<30} {'Среднее':<20} {'Дисперсия':<20}")
print("-" * 70)
print(f"{'Собственный датчик':<30} {con_random_mean:<20.6f} {con_random_var:<20.6f}")
print(f"{'Встроенный генератор':<30} {built_mean:<20.6f} {built_var:<20.6f}")
print(f"{'Метод Фибоначчи':<30} {fibonacci_mean:<20.6f} {fibonacci_var:<20.6f}")
print(f"{'Теоретические значения':<30} {teor_mean:<20.6f} {teor_var:<20.6f}")