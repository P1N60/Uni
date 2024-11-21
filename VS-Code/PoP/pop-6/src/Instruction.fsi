module Instruction 

// instruction is either a constant value or a binary operator name 
type instruction = Value of int | Multiply | Plus | Minus | Divide
// integer stacks, used for pushing and popping of values
type stack = Stack.Stack<int>

// evaluate single instruction on a stack
val eval1: instr: instruction -> stack -> stack option
// evaluate a l for list of instructions
val eval: instruction list -> stack -> stack option