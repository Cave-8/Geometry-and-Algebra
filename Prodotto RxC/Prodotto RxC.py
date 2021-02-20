#Import
import random as rand
import sys
import numpy as np

#Declaration and check
r_M = int(input("Inserire righe prima matrice: "))
c_M = int(input("Inserire colonne prima matrice: "))
r_N = int(input("Inserire righe seconda matrice: "))
c_N = int(input("Inserire colonne seconda matrice: "))

if (c_M != r_N):
    print ("Condizione prodotto riga colonna non rispettata!\n")
    sys.exit()

M = [[0 for x in range(c_M)] for y in range (r_M)]
N = [[0 for x in range(c_N)] for y in range (r_N)]
L = [[0 for x in range (c_N)] for y in range (r_M)]

#Fill and print matrix
for i in range (r_M):
    print ("|", end = '')
    for u in range (c_M):
        M[i][u] = rand.randrange(10)
        print (f'{M[i][u]} ', end = '')
    print ("|")
print ("")    

for i in range (r_N):
    print ("|", end = '')
    for u in range (c_N):
        N[i][u] = rand.randrange(10)
        print (f'{N[i][u]} ', end = '')
    print ("|")    
print ("")    

#Filling result
for n in range (r_M):
    for m in range (c_N):            
        for k in range (r_N): 
             L[n][m] += (M[n][k]*N[k][m])

#Print result
for i in range (r_M):
    print ("|", end = '')
    for u in range (c_N):
        print (f'{L[i][u]} ', end = '')
    print ("|")     

