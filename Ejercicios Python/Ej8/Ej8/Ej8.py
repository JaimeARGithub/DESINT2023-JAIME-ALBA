char = input("Enter a character: ")
countVocals=0
countConsonants=0
countSigns=0
countTotal=0

while char!=' ':
    countTotal=countTotal+1

    if char=='a' or char=='e' or char=='i' or char=='o' or char=='u' or char=='A' or char=='E' or char=='I' or char=='O' or char=='U':
        countVocals=countVocals+1
    elif ord(char)>65 and ord(char)<122:
        countConsonants=countConsonants+1
    else:
        countSigns=countSigns+1  
    
        
    char = input("Enter a character: ")
    
print(countVocals)
print(countConsonants)
print(countSigns)
print(countTotal)

