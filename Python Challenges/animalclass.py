# This is the program that defines an animal's class
# By: Ariana Higgins

import random

class Animal:
    # function that defines what happens when a new animal object is created
    def __init__(self, animal_type, animal_name):
        self.__animal_type = animal_type
        self.__name = animal_name

        # generates a random number between 1 and 3
        random_number = random.randint(1, 3)

        # this gives the animal it's mood based on the random number generated
        if random_number == 1:
            self.__animalmood = "happy"
        elif random_number == 2:
            self.__animalmood = "hungry"           
        elif random_number == 3:
            self.__animalmood = "sleepy"
        
    # function that returns the animal type
    def get_animal_type(self):
        return self.__animal_type

    # function that returns the animal name
    def get_name(self):
        return self.__name

    # function that returns animal mood
    def check_mood(self):
        return self.__animalmood
