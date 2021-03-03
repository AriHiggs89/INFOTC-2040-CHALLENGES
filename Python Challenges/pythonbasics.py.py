'''

INTRODUCTION TO PYTHON PROGRAMMING IDLE TUTORIAL - YOUTUBE
https://www.youtube.com/watch?v=2Thymdugfp4&t=18s

'''


# In Python, we talk about writing scripts
# Python is an interpreted lanuage
# Use '''   ''' for multi-line comment

# PRINT FUNCTION:
print("Hello, World!")
print('Hello, World!')

#we can combine both double and single quotes in one function
print("hello" 'there')

# this produces one line of output
print("hello there")

# print strings to different lines using escape sequences:
# \n escape sequence: this produces two lines of output
print("hello\nthere")


# VARIABLES:
# -- variable is  a storage location in memory
# -- has a name, and a value assigned to it
# -- unlike other languages, does not have a type
# -- must be defined before it is used

item = 5   # item is the identifier for the variable location 

# LITERALS:
# -- literals are just a value written into a program's code
"hello there"  # this is a string literal
5  # an integer literal


# PYTHON KEYWORDS:
# -- example keywords that cannot be used as variables:
# -- and
# -- while
# -- or
# -- else,
# -- if  

# IDENTIFIER RULES:
# identifiers are programer defined names for parts of a program:
# variables, functions, etc...(anything we give a name to)
# -- must begin with an alphabetic character
a95 = 2

# or begin with an underscore
_a95 = 2

# upper and lower-case characters are distinct ("case matters")
A95 = 2

# DATA TYPES IN PYTHON:
# -- python determines data type at run-time so we don't have to specify this
# -- python is  a weakly-typed language, so we can do this:

foo = 5
foo = 5.5    # no need to use float or int char etc
foo = 'a'
foo = "dogbutt"

# DEFINING VARIABLES 
# -- variables can be defined on separate lines:

a = 1
b = 2
c = 3

# -- variables can be defined on the same line: (order matters!)
a, b, c = 1, 2, 3

# -- variables that store different data types can be defined on same line:

a, b, c = "hi", 5, 2.89
print(a, b, c)

# can store floating point numbers using e notation
a = 3.15E20   #3.15 * 10^20
print(a)


# VARIABLE ASSIGNMENT AND INITIALIZATION variables must be initialized
# -- when they are defined
span = 210

# -- variable is on the left, value assigned is on the right
#   invalid:  210 = span      valid:   span = 210

# no bool data types in Python. Anything that is non-zero is true; 0 is false
# python variables must be initialized to some value
# sizeof function
import sys

print(sys.getsizeof(a))

#
#
#
#
#
#

# VARIABLE SCOPE:
# scope is the part of a program where a defined variable can be used
# -- cannot use a a variable before it is defined
# -- if you do, it is called "variable out of scope" & produce an error
# -- print(z)
# -- z = 100
# -- the above would be INVALID because z is defined AFTER print function
#
# -- y = 99
# -- print(y)
# -- the aboive would be VALID because y is defined BEFORE print function

 
# ARITHMETIC OPERATORS:
# -- python has unary and binary operators:
#     -10         a unary operator
#     10 + 2      a binary operator

# python binary arithmetic operators:

print ( 2 + 2)    # addition
print ( 2 - 2)    # subtraction
print ( 2 * 2)    # multiplication
print ( 2 / 2)    # division (will produce float)
print ( 3 // 2)   # floor division  (will round down to whole number)
print ( 2 % 2)    # modulus (remainder division - will return 0)
print (2 ** 2)    # exponent operator 

# take a closer look at the / operator
print( 13 / 5)    # display will be 2.6
print( 91 / 7)    # display will be 13.0
print( 13 / 5.0)  # display will be 2.6
print( 13 // 5)   # display will be 2


#SIMPLE BEGINNER PROGRAM TO TIE EVERYTHING TOGETHER!!

print("Hello to my simple script to\nadd two numbers")
num1 = 5.2
num2 = 8.7

sum = num1 + num2

print("The sum of num1 and num2 is:")
print(sum)


