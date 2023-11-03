upper1 = input("Enter the first bound: ")
upper2 = input("Enter the second bound: ")
acc = 0

for i in range(1, int(upper1)+1):
    for j in range(1, int(upper2)+1):
        acc = acc + (i+j)
        
print(acc)
