#Monday, February 3 Code Practice

#Program that calculates distance using the distance formula:
#Distance = rate * time

def get_float_input(prompt):
    value = float(input(prompt))
    return value

def calculate_distance():

    rate = get_float_input("\nPlease enter a rate (feet per second): ")
    time = get_float_input("Please enter time (in seconds): ")
    
    distance = rate*time
    return distance

def main():

    do_again = True
    while (do_again):
        distance = calculate_distance()
        print("The distance is", distance)
        do_another = input("Would you like to calculate another distance (y/n)?")
        if (do_another == 'n'):
            do_again = False
            
''' 
the while loop above will keep going on forever because there is nothing
that will change it from being a 'True' statement. So we add 'do_another' set equal to 'n' and 'false' to prompt user
'''


#using the main() function
#we define a function called main() that did not take any parameters at the top of program
#main() will not execute on its own - this has to be "called/invoked" after it is defined
#python does not require a main() function for the program to run

main()



