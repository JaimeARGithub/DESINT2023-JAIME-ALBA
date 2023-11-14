import math 
#también está cmath para calcular raíces imaginarias

def bakhshali(x,n):
    total = ((n**4) + (6*(n**2)*x) + (x**2)) / ((4*(n**3)) + (4*n*x))
    return total

print("We want to get the square root of 20.")
print("The integer number which 2 power approaches the most is 4 (4^2=16, not exceding 20)")
root = math.sqrt(20)
print(str(root) + " more or less equals " + str(bakhshali(20,4)))
