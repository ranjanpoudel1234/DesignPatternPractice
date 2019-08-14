1) Useful:
The decorator pattern is used to extend or alter the functionality of objects at run-time by wrapping them in an object of a decorator class. 
This provides a flexible alternative to using inheritance to modify behavior

The decorator pattern is used to extend the functionality of individual objects, not classes.
This means that the modifications are made at run-time rather than at design time. 
This allows changes to be applied to objects in response to specific conditions such as user-selected options and business rules

In addition, as both the class of the object being modified and the class of the decorator share a base class, 
multiple decorators can be applied to the same object to incrementally modify behavior.

2) Example
An example of the decorator pattern could be used in a computer system used by a company that provides vehicles for hire during track days. 
Such a company could own a fleet of cars and motorcycles for hire. 
Each vehicle could be represented by an instance of a class that inherits from the Vehicle class. 
This would define key properties such as make, model, hire price and number of laps permitted.

Vehicles in the track day system will not be available for hire if they have faults.
However, if no faults are known, the vehicle's object would be wrapped by the hireable class.
This class would be a decorator that holds a reference to the underlying vehicle and adds extra functionality to allow logging of the details of hire periods.
Further decorators could be added according to business rules.
For example, special offer decorators could be added to automatically reduce the hire price or increase the number of laps that may be driven.