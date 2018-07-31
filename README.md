# CSharpPriorityQueue
Implemented as a binary min heap.

Implements ICollection<T>.

Constructors:
* `PriorityQueue<T>()`: Constructs an empty Priority Queue. Default Comparer for T is used.
* `PriorityQueue<T>(comparer)`: Constructs an empty Priority Queue. Given Comparer is used.

Methods and Properties:
* `Count`: Gets number of elements in `O(1)`
* `Add(item)`: Enqueues in `O(log N)`
* `Peek()`: Gets first element in `O(1)`
* `Remove()`: Removes first element in `O(log N)`
* `Clear()`: Clears all elements in the heap
* `Contains(item)`: Checks if this heap contains the item in `O(log N)`
* `Remove(item)`: Removes given item (if it exists) in `O(log N)`
* `IndexOf(item)`: Gets index of item (or -1 if it does not exist) in `O(log N)`
* `GetEnumerator()`: Enumerator. Order is "random" (not guaranteed to be sorted or ordered in any specific way)

No out of bounds error checking. Also not thread-safe.
