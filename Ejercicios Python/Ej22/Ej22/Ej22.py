def fact(num):
  acc=1
  for i in range(1,num+1):
    acc=acc*i
  return acc

def cos(grados, numTerms):
  pi=3.141592653589793
  radianes = grados * pi / 180
  cos=1
  iterador=2
  terminos=numTerms
  
  for i in range(1,terminos+1):
    if (i%2!=0):
      cos = cos - ( (radianes**iterador) / (fact(iterador)) )
    else:
      cos = cos + ( (radianes**iterador) / (fact(iterador)) )
    iterador+=2
    
  return cos

print(str(cos(60,10)))
  
  
      

  

  
  
