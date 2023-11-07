accumulator = 0
amount = 0

number = input("Please, enter a number: ")
while (int(number)>=0):
    accumulator+=int(number)
    amount+=1
    number = input("Please, enter a number: ")
    
print(accumulator/amount)
