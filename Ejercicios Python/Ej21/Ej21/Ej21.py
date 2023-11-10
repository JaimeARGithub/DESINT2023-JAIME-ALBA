amount = input("How many characters are you gonna enter? ")
char = input("What character do you want to count? ")
counter = 0

for i in range(int(amount)):
    entered_char = input("Please, enter a char: ")
    if (entered_char == char):
        counter+=1
        
print("The selected char was '"+char+"'. It appeared "+str(counter)+" times.")
