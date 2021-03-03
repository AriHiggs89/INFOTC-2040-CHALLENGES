# Program: animalclassgenerator.py
# Program that creates animal objects and then displays them

import Animal

# This creates a list for the animal objects
animals = list()

# user interface
print("Welcome to the animal generator!")
print("This program creates Animal objects")

while True:
    # take user input
    animal_type = input("\nWhat type of animal would you like to create? ")
    animal_name = input("What is the animal's name? ")

    animal = Animal.Animal(animal_type, animal_name)

    # opens file and appends the animal file
    animals.append(animal)

    # takes user input to create more animals or quit
    choice = input("\nWould you like to continue to add animals (Y/N)? ")
    if choice != "y" or "Y":
        break

print("\nAnimal List")

# This loops through the animals in the animal file
for animal in animals:
    # methods that get object information
    animal_name = animal.get_name()
    animal_type = animal.get_animal_type()
    animal_mood = animal.check_animalmood()

    # Print the object information
    print(animal_name, "the", animal_type, "is", animal_mood)
