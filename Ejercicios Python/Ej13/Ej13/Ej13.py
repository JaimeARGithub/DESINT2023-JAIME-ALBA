number = input("Enter a number to determine if it is abundant or not: ")
accumulator=0

for i in range(1, int(number)):
    if (int(number)%i==0):
        accumulator+=i
        
if (accumulator>int(number)):
    print("Abundant number.")
else:
    print("Not an abundant number.")

