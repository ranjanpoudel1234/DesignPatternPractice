UML DIAGRAM 
http://www.blackwasp.co.uk/images/Adapter.png

Defn
The adapter pattern is a design pattern that is used to allow two incompatible types to communicate.
Where one class relies upon a specific interface that is not implemented by another class, the adapter acts as a translator between the two types.

A GOOD EXAMPLE:
Legacy Microservice between new Microservices and SQL Server.

1) Why?

i) You are designing a class or a framework and you want to ensure it is usable by a wide variety of as-yet-unwritten class and applications.
ii) Also called Wrappers.
iii) Example, if you want to use library in your code. Or if you are writing library that you want future users to be able to use easily.
iv) Real World Example, like multiplug for wrong power socker, adding adapter in between.
v) Useful to convert interface of a class into another interface clients expect.
vi) Allow classes to work together that couldnot otherwise due to incompatible interfaces.

2) Use when:
i) you want to use an existing class, but its interface does not match the one you require.
ii) You want to create a reusable class that cooperates with unrelated or unforseen classes(i.e classes that wont share the same interface)
iii) You need to use several existing subclasses, but its impractical to adapt their interface by subclassing every one. eg dataAdapterClass for
sqlDataClass, oracleDataClass, MangoDataClass.

3) Structure
	a) Client
	b) Adaptee

4) Other related patterns are
Repository, 
STRATEGY as adapter is passed into a class that depends on it.
FACADE -> both are wrappers.Facade wraps multiple classes.

5) Short Summary
Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.