numberStr = input("Please, enter a number: ")
number = int(numberStr)

print("Numero          Cuadrado          Cubo")
for i in range(1,11):
    print(str(number+i) + "              " + str((number+i)**2) + "               " + str((number+i)**3))
