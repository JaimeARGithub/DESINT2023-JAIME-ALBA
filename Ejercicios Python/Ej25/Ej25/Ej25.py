print("What do you want to do?")
print("1) Convert euros to dollars")
print("2) Convert dollars to euros")

option = input("Please, type 1 or 2: ")

if (option==str(1)):
    amount = input("Please, type the amount that you want to convert: ")
    result=float(amount)*1.07
    print("Your amount equals "+str(result)+" dollars")
elif (option==str(2)):
    amount = input("Please, type the amount that you want to convert: ")
    result=float(amount)*0.93
    print("Your amount equals "+str(result)+" euros")
else:
    print("Please, choose a valid option.")


