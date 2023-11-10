def fact(num):
  acc=1
  for i in range(1,num+1):
    acc=acc*i
  return acc

def getE(num, terms):
  e=1
  
  for i in range(1, terms+1):
    e += ( num**i / fact(i) )
    
  return e

print(str(getE(10,50)))


