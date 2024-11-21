module Stack

// Integer stacks, implemented using F# integer lists
type Stack<'a> = 'a list

exception PopError

// empty stack
val empty: Stack<'a>
// push an element to the top of the stack
val push: 'a -> Stack<'a> -> Stack<'a>
// check whether stack is empty
val isEmpty: Stack<'a> -> bool
// return top element and remainder of nonempty stack; return error value if empty
val pop: Stack<'a> -> ('a * Stack<'a>)