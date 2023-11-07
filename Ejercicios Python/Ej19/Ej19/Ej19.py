dividend = input("Enter the dividend: ")
divider = input("Enter the divider: ")
dividendShow = dividend
quotient = 0
rest = 0

while (int(dividend)>=int(divider)):
    dividend = int(dividend)-int(divider)
    quotient = int(quotient)+1
    
rest = dividend
print("The result of dividing "+dividendShow+" between "+divider+" is "+str(quotient)+", with rest "+str(rest))



