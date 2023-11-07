accumulator = 0
amount = 0

number = input("Please, enter a number: ")
while (float(number)!=100):
    accumulator+=float(number)
    amount+=1
    number = input("Please, enter a number: ")
    
print(accumulator/amount)
