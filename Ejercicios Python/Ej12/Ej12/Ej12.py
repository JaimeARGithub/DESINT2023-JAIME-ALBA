number = input("Enter a number to determine if it is or not a prime number: ")
counter = 0

for i in range(1, int(number)+1):
    if (int(number)%i==0):
        counter+=1
        

if (counter==2):
    print("Prime number.")
else:
    print("Not a prime number.")
