'''
IMPROVED OBJECT POSITION CALCULATION PROGRAM 
Program that takes initial position of object,initial velocity, acceleration,
and time that has passed from user and calculates outputs the final position
based upon an equation provided in the requirements.
'''

def menu():
    print("\n<><> WELCOME TO THE OBJECT POSITION CALCULATION PROGRAM <><>\n")
    print("This program calculates an object’s final position using the below information: ")
    print("<> Initial position of the object\n<> Initial velocity of the object \n<> Object's acceleration \n<> Time interval that has passed\n")

#function that takes user input 
def user_interface():
    initial_position = get_float("\n** Please enter object's initial position (meters): ")
    initial_velocity = get_float("** Please enter object's initial velocity (meters/second): ")
    acceleration = get_float("** Please enter the object's acceleration (meters/seconds squared): ")
    time = get_non_negative_time_float("** Please enter the time interval that has passed (seconds): ")
    calc_final_position_float(initial_position, initial_velocity, acceleration, time)

#function that takes user input for object calculation 
def get_float(prompt):
    while True:
        try:
            value = float(input(prompt))
        except ValueError:
            print("!! Sorry, only numerical values are allowed !!\n")
            continue
        else:
            break
    return value

#function that takes user time input and verifies that it is a non-negative number
def get_non_negative_time_float(prompt):
    while True:
        try:
            value = float(input(prompt))
        except ValueError:
            print("!! Sorry, only numerical values are allowed !!\n")
            continue
        if value < 0:
            print("!! Sorry, time interval must not be negative !!\n")
            continue
        else:
            break
    return value

#function that calculates final position of object 
def calc_final_position_float(initial_position, initial_velocity, acceleration, time):
    time_squared = float(time * time)
    half_acceleration = float(acceleration / 2)
    final_position = float(initial_position + initial_velocity * time + half_acceleration * time_squared)
    print(f"\n<> The final position of the object is: {final_position} meters!!")

def main():
    menu()
    user_interface()
    do_repeat = True
    while (do_repeat):
        another_calculation = input("\nDo you want to perform another calculation? (y/n): ")
        if (another_calculation != "y" and another_calculation != "Y"):
            do_repeat = False
        else:
            user_interface()

main()

