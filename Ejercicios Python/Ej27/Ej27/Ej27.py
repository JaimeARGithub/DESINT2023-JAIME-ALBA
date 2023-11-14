def fuerzG(m1, m2, r):
    G=6.67*(10**-11)
    F= (G*m1*m2) / (r**2)
    return F

print("If mass 1 is 5000kg, mass 2 if 15000kg and they're sepparated 1m...")
print("The attraction gravitational force between them will be " + str(fuerzG(5000, 15000, 1)) + " newtons!")
