# PT_NuGet_DSA.MyCollections

## General information

PT_NuGet_DSA.MyCollections is a personal research on both linear and non-linear Data Structures.  
It includes explicit implementations of a number of DS collections - all analyzed and learnt via the great lectures on DSA in SoftUni and Telerik Academy.

I also shared the implementation of these collection with the community via a NuGet package:

![nuget_package](/Resources/Screenshots/NuGet_PetarTotev.Net.DSA.MyCollections.jpg)

This NuGet already has 328 downloads, which seems crazy to me...

## Technologies
- NUnit

## Contents

The solution contains 2 projects:

- DSA.MyCollections - a .NET Standard project that contains a number of explicitly implemented collections, as follows:

  - MyDictionary<TKey, TValue>
  - MyHashSet\<Tkey>
  - MyHashTable<TKey, TValue>
  - MyHeapMax\<T>
  - MyHeapMin\<T>
  - MyKeyValuePair<TKey, TValue>
  - MyLinkedListD\<T> ('D' is for doubly)
  - MyLinkedListS\<T> ('S' is for singly)
  - MyList\<T>
  - MyNodeAVL\<T> ('AVL' is for Adelson-Velsky and Landis)
  - MyNodeBST\<T> ('BST' is for Binary Search Tree)
  - MyNodeD\<T> ('D' is for doubly)
  - MyNodeS\<T> ('S' is for singly)
  - MyPriorityQueue\<T>
  - MyQueue\<T>
  - MyStack\<T>
  - MyTree\<T>
  - MyTreeAVL\<T> ('AVL' is for Adelson-Velsky and Landis)
  - MyTreeBinary\<T>
  - MyTreeBinarySearch\<T>
  - MyTreeBinarySearch\<T>
  - MyTreeRedBlack\<T>

- DSA.MyCollections.Tests\* - a NUnit test project which includes 121 tests that investigate the consistency, stability and predictability of the collections described above

## Credits

\* All of the tests included in the NUnit project came for granted from the resources of the DS courses of Software University (SoftUni) that I officially participated in.

All knowledge I gained I owe to the great lecturers in SoftUni - Georgi Angelov and Kiril Kirilov as well as my generous trainers in Telerik Academy - Kiril Stanoev and Radko Stanev.

Thank you for invoiking my passion for DSA!

\~THE END\~
