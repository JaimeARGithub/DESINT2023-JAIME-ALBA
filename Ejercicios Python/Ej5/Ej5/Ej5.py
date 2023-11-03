upper = input("Enter the upper bound: ")
acc = 0

for i in range(1,int(upper)+1):
    acc = acc + ((int(upper)+1) ** 2)/(i+1)
    
print(acc)
