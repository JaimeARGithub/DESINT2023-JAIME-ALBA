lower = input("Enter the lower limit: ")
upper = input("Enter the upper bound: ")

for i in range(int(lower), int(upper)+1):
    if (i%7==0):
        print(i)

