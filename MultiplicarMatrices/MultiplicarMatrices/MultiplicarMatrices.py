matrix1 = []
matrix2 = []
for row in range(4):
    matrix_inner = []
    for col in range(4):
        matrix_inner.append(None)
    matrix1.append(matrix_inner)
    matrix2.append(matrix_inner)
    

for i in range(len(matrix1)):
    for j in range(len(matrix1[0])):
        print("For the matrix 1, enter the element ",i,"-",j)
        matrix1[i][j] = int(input())
        
for i in range(len(matrix2)):
    for j in range(len(matrix2[0])):
        print("For the matrix 2, enter the element ",i,"-",j)
        matrix2[i][j] = int(input())
    

numCols1st = len(matrix1[0])
numRows2nd = len(matrix2)


if numCols1st!=numRows2nd:

    print("Operation is not possible; the number of columns in matrix 1 must equal the number of rows in matrix 2.")
else:
    
    
    result = []
    for row in range(len(matrix1)):
        inner_result = []
        for col in range(len(matrix2[0])):
            inner_result.append(None)
        result.append(inner_result)

    
    for i in range(0,len(result)):
        for j in range(0,len(result[0])):
            
            result[i][j]=0
            
            for z in range(0,len(matrix1[0])):
                result[i][j] = result[i][j] + (matrix1[i][z] * matrix2[z][j])
                
    

    for i in range(0,len(result)):
        for j in range(0,len(result[0])):
            
            if (result[i][j]>=10):
                print(result[i][j], end=" ")
            else:
                print("",result[i][j], end=" ")

        print("")