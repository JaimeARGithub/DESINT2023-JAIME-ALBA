char = input("Enter a character: ")
countVocals=0

while char!=' ':
    if char=='a' or char=='e' or char=='i' or char=='o' or char=='u' or char=='A' or char=='E' or char=='I' or char=='O' or char=='U':
        countVocals=countVocals+1
        
    char = input("Enter a character: ")
    
print(countVocals)
