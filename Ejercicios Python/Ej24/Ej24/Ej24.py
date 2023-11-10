digits = input("How many hexadecimal digits are you going to enter? ")
decimal=0

for i in range(0, int(digits)):
    pos = int(digits)-1 - i
    digit = input("Enter the digit in position "+str(pos)+": ")

    match digit:
        case 'A':
            value=10
        case 'B':
            value=11
        case 'C':
            value=12
        case 'D':
            value=13
        case 'E':
            value=14
        case 'F':
            value=15
        case default:
            value=int(digit)

    decimal = decimal + (value * (16**pos))
    

print("The decimal value for that number is "+str(decimal))
    
    
