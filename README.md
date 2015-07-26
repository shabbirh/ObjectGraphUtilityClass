# ObjectGraphUtilityClass
Utility Class To Merge Two Object Graphs (Identical types) using the given rules

##Task:
The goal is to create a utility class that given two object graphs (source and target) of identical Type, merges the object graphs following the rules below and returns the merged object.


##Rules:
###Properties:
If a source property has a null value, do not merge.

###Value-Type Properties (int, long, bool, etc): 
Replace target property value with source property value.
 
###Reference-Type Properties (String, UserDefined Classes, Interfaces, but EXCLUDING Collections):
Use recursion to merge source and target properties

###Collection-Types (IEnumerable):

If source and target collections are empty, 
			do nothing.

If source collection has no elements, 
			remove all elements from the target collection.

If source collection has elements, 
	assuming there is a property that has a unique matching value in the source and target collections (i.e. Name),  
	find that element and merge it with the source element.


If source collection has elements that don’t exist in target, 
			then add them to target.

If target collection has elements that don’t exist in source, 
			remove them.


##Advice:		
Bear in mind that elements of a collection can also be collections.
 
You will need to use generics and reflection. The method signature  could be something like this:     public static T Merge<T>(T source, T target).
You can make use of other support methods (private) to carry out this task.
