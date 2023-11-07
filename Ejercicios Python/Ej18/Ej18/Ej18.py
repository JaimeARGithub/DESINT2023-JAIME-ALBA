amount = input("How many real numbers do you desire to enter? ")
accumulator = 0

for i in range(int(amount)):
    realNum = input("Please, enter a real number: ")
    accumulator+=float(realNum)
    
average=accumulator/float(amount)

print("The average value is "+str(average))
print("How many real numbers do you desire to enter? ")
