using System;
using System.Collections.Generic;
using System.Linq;
using ObjectGraphMergeUtilityClass.Interfaces;

namespace ObjectGraphMergeUtilityClass.Entities
{
	public class Library : IMergable<Library>
	{
		public List<Book> Books { get; set; }

		public Library MergeWith(Library target)
		{
		   var mergedLibrary = new Library
			{
				Books = Books.Union(target.Books).ToList()
			};

			return mergedLibrary;
		}

       public Library MergeWithRules(Library target)
		{

			var mergedLibrary = new Library();

			foreach(Book sourceBook in Books)
			{
                /** Properties:
                 ** If a source property has a null value, do not merge.
                **/
                if (sourceBook == null)
                {
                    break;
                }

                /** Value-Type Properties (int, long, bool, etc): 
			     ** Replace target property value with source property value.
                **/

			}


			/*
			

			//TODO
 
			Reference-Type Properties (String, UserDefined Classes, Interfaces, but EXCLUDING Collections):
			** Use recursion to merge source and target properties

			Collection-Types (IEnumerable):

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

			*/


                return mergedLibrary;
		}
    }
}
