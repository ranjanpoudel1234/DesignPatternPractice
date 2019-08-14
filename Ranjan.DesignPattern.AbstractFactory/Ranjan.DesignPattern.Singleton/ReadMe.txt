1) What ?
 This is a creational pattern as it is used to control class instantiation.
 The pattern ensures that only one object of a particular class is ever created. 
 All further references to objects of the singleton class refer to the same underlying instance.

 2) Why useful ?
 The singleton pattern is useful when a single, global point of access to a limited resource is required.
 It is more appropriate than creating a global variable as this may be copied, leading to multiple access points and the risk that the duplicates become out of step with the original

 3) Example
	An example of the use of a singleton class is a connector to a legacy data file that only supports a single reader at any time.
	In this case, creating multiple instances of the legacy data connector would simply cause all but the first to fail when reading from the file.
	By forcing a single, global instance to be used, only one underlying connection would ever be active.