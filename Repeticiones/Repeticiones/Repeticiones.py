matrixA = [[2, 2, 3, 2, 1], [3, 3, 2, 1, 2], [5, 6, 1, 2, 1], [4, 3, 1, 2, 2], [1, 2, 2, 2, 3]]
vector = [3, 4, 3, 2, 1, 4, 2, 3, 2, 1]

for i in range(len(matrixA)):
    for j in range(len(matrixA[0])):
        counter=0;
        for z in range(len(vector)):
            if matrixA[i][j]==vector[z]:
                counter+=1
        matrixA[i][j]=counter
    matrixA[i].sort()
        
for i in range(len(matrixA)):
    for j in range(len(matrixA[0])):
        print(" ",matrixA[i][j], end=" ")
    print(" ")