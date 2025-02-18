# Reflection

## IEnumerable 
   For the understanding of IEnumerable ,Created a class UnderstandIEnumerable with method SumOfElements which get any concrete collection as IEnumerable and returns the sum of elements in the collection.This IEnumerable collection does not follow the approach of the collections such as list,stack,queue.Whatever it can be but it only iterate and read the value and does not alter anything inside it.
## IReadOnlyCollection
  For the understanding of the IReadOnlyCollection,Created class UnderstandingReadOnlyCollection with methods GenerateDictionary,PrintDictionary and ModifyDictionary.<br>
  **GenerateDictionary()** : 
  The GenerateDictionary method create a dictionary object with some values and return as IReadOnlyDictionary
  **PrintDictionary()** :The PrintDictionary get input as IReadOnlyDictionary and prints the key and value.
 **ModifyDictionary()** :This method gets the result from the GenerateDictionary method and try to change a value .On that time,it throws an error because it is readonly collection and it cannot be modify.
## Conclusion
 The IReadOnlyCollection comes under the IEnumerable .In Both,Only able to read the values.The only differenec is IEnumberable are used only to iterate to all the values till the end but IReadOnlyCollection have all the methods as same as in the collection except the modify kind of things and mainly used to protect the original data