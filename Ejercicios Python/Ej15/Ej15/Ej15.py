number = input("Enter a number to calculate its odd factorial: ")
fact = 1

for i in range(1, int(number)+1):
    if (i%2!=0):
        fact=fact*i
        

print(fact)

