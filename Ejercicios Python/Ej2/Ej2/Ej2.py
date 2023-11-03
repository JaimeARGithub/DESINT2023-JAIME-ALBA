year = input("Enter the year you desire to evaluate: ")

if ((int(year)%4==0) and (int(year)%100!=0)) or (int(year)%400==0):
    print("It is a leap-year")
else:
    print("Not a leap-year")
