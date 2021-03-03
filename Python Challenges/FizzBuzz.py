# IT2040 Module 1 Challenge: "FizzBuzz" Program
# By: Ariana Higgins (axhf9)

print("\n____Welcome to Fizz Buzz_____\n")

def main():
    i = 1
    for i in range (1, 101):
        if i % 3 == 0 and i % 5 == 0:
            print("FizzBuzz")
        elif i % 3 == 0:
            print("Fizz")
        elif i % 5 == 0:
            print("Buzz")
        else:
            print(i)
main()

print("\nGoodbye!\n")