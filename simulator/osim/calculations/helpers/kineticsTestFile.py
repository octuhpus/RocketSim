# File used to test IO for kinetics methods

import kinetics

'''
# -----------------------------------------------
drag = []
x = float(input("Enter drag x value: "))
y = float(input("Enter drag y value: "))
z = float(input("Enter drag z value: "))

drag.append(x)
drag.append(y)
drag.append(z)

# -----------------------------------------------
gravity = []
x = float(input("Enter gravity x value: "))
y = float(input("Enter gravity y value: "))
z = float(input("Enter gravity z value: "))

gravity.append(x)
gravity.append(y)
gravity.append(z)

# -----------------------------------------------
thrust = []
x = float(input("Enter thrust x value: "))
y = float(input("Enter thrust y value: "))
z = float(input("Enter thrust z value: "))

thrust.append(x)
thrust.append(y)
thrust.append(z)

# -----------------------------------------------
'''

velocity = [10, 20, 30]

kinetics.calcDrag(velocity)
x = kinetics.calcGravity(.1)
print(x)

