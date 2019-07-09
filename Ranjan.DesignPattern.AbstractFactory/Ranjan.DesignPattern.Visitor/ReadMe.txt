A) What ?

1) The visitor pattern is used to separate a relatively complex set of structured data classes
from the functionality that may be performed upon the data that they hold.

2) This allows the creation of a data model with limited internal functionality 
and a set of visitors that perform operations upon the data

3) The pattern specifically allows each of the elements of a data structure to be visited in turn
without knowing the details of the structure beforehand.

B) Benefit/Why ?

1) he key benefit of separating the data model from the algorithms that may be applied to it 
is the ability to add new operations easily

2) A second benefit of the design pattern is that a single visitor object is used to visit all elements of the data structure. 
The visitor object can maintain state between calls to individual data objects.

c) HOw ?
The classes of the data structure are initially created with the inclusion of a method that may be called by a visitor object.
This method performs a callback to the visitor, passing itself to the visitor's method as a parameter. 
The visitor can then perform operations upon the data object. 
To add a new operation, a new visitor class is created with the appropriate callback method. 
The data classes need no further modification

d) Example
An example of the use of the visitor design pattern could be used within a personnel system. 
The data structure could define a hierarchy of managers and employees, each with a salary property.
This system could include two visitor algorithms.
The first would traverse the hierarchy and generate monthly salary payments. 
The second could apply a standard pay increase to each employee.