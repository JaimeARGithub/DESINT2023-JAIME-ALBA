upper = input("Enter the upper limit: ")
acc = 0

for i in range(1, int(upper)+1):
    acc = acc + (int(upper) ** 2)/i
    
print(acc)
