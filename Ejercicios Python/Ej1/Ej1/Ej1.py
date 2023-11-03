hours1 = input("Enter the number of hours for time 1: ")
mins1 = input("Enter the number of minutes for time 1: ")
secs1 = input("Enter the number of seconds for time 1: ")

hours2 = input("Enter the number of hours for time 2: ")
mins2 = input("Enter the number of minutes for time 2: ")
secs2 = input("Enter the number of seconds for time 2: ")

time1 = [hours1, mins1, secs1]
time2 = [hours2, mins2, secs2]

totalSeconds1 = int(hours1)*3600 + int(mins1)*60 + int(secs1)
totalSeconds2 = int(hours2)*3600 + int(mins2)*60 + int(secs2)
print("The difference is "+str((totalSeconds1-totalSeconds2))+" seconds")
