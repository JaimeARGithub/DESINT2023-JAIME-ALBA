from pickle import FALSE
import random

# Definimos el array de n�meros como un array vac�o
numbers = []

# Le a�adimos al array 15 ceros, el n�mero total de n�meros que contendr� la matriz final
for i in range(15):
    numbers.append(0)


# A cada posici�n del array le asignamos un n�mero aleatorio entre 1 y 99
# En la generaci�n de cada aleatorio se revisa el contenido del array; si
# el n�mero aleatorio generado coincide con alguno de los elementos del
# array, y mientras lo siga haciendo, se vuelve a generar (asegurarnos de
# que todos los n�meros son distintos)
for i in range(15):
    a=random.randint(1,90)
    for j in range(15):
        while (numbers[j]==a):
            a=random.randint(1,90)
    numbers[i]=a
     
# Ordenamos el vector de menor a mayor
numbers.sort()

# Creamos una matriz de 3x5 vac�a
bingo = []
for row in range(3):
    bingo_inner = []
    for col in range(5):
        bingo_inner.append(None)
    bingo.append(bingo_inner)
    
# Asignamos al contenido de la matriz el contenido del array; nos creamos
# un iterador que vaya recorriendo las posiciones del array, de tal manera
# que, cada vez que se asigne un n�mero a una posici�n [fila][columna] de
# la matriz, se avance una posici�n en el array y se proceda a asignar el
# siguiente n�mero
iterator=0
for row in range(len(bingo)):
    for col in range(len(bingo[0])):
        bingo[row][col]=numbers[iterator]
        iterator+=1
            
# E imprimimos el cart�n de bingo final
for row in range(len(bingo)):
    for col in range(len(bingo[0])):
        if (bingo[row][col]>=10):
            print(bingo[row][col], end=" ")
        else:
            print("",bingo[row][col], end=" ")
    print("")
    
# Dedicado a las 16 horas de curso de Python que no me he visto





