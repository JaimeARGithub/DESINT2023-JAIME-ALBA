amount = input("Enter the amount of numbers that will be read: ")
max = 0

for i in range(int(amount)):
    number = input("Enter a number: ")
    if (int(number)>max):
        max=int(number)
        
print("The biggest number is "+str(max))
