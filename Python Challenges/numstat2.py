#Random Number Generator
#This program writes random numbers to a text file, specified by how many random numbers a user wants to generate. The user gives upper and lower bounds
#All numbers must be positive 

import random

def generate_random_numbers(): 
    random_file = open("randomnum.txt", "w")

    for i in range(get_user_input("How many random numbers would you like to generate? ")):
            upper_bound = get_user_input("What is the largest number in the range? ")
            lower_bound = get_user_input("What is the smallest number in the range? ")

    number = str(random.randint(upper_bound, lower_bound))
    random_file.write(number)
    print(number)

def get_user_input():
    while True:
        try:
            value = int(input)
        except ValueError:
            print("\nSorry, only numerical values are allowed!!\n")
            continue
        if value <= 0:
            print("\nSorry, value must not be negative or zero!!\n")
            continue
        else:
            break
        return value
    
        number = str(random.randint(upper_bound, lower_bound))
        random_file.write(number)
        print(number)

generate_random_numbers()
get_user_input()
random_file.close()
