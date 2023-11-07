number = input("Enter a number to calculate its factorial: ")
fact=1

for i in range(1, int(number)+1):
    fact=fact*i
    
print(fact)
