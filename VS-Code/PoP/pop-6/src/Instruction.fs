module Instruction

open Stack
// Type of instructions
type instruction = Value of int | Multiply | Plus | Minus | Divide
// Type of values 
type stack = Stack<int>

// pop two elements from a stack, return None if there are fewer than 2 elements on the stack
let pop2 (stack: Stack<'a>): (('a * 'a) * Stack<'a>) option = 
  match pop stack with
  | Some (v1, rest) -> 
      match pop rest with
      | Some (v2, rest') -> Some ((v2, v1), rest')
      | None -> None
  | None -> None

// Given a Value instruction, push the value onto the stack;
// Given an operator instruction, pop two values from the stack, compute the result and push it onto the stack.
let eval1 (instr: instruction) (stack : stack) : stack option =
  match instr with
  | Value v -> Some (push v stack)
  | Multiply -> 
    match pop2 stack with
    | Some ((v1, v2), stack') -> Some (push (v1 * v2) stack')
    | None -> None
  | Plus -> 
    match pop2 stack with
    | Some ((v1, v2), stack') -> Some (push (v1 + v2) stack')
    | None -> None
  | Minus -> 
    match pop2 stack with
    | Some ((v1, v2), stack') -> Some (push (v1 - v2) stack')
    | None -> None
  | Divide -> 
    match pop2 stack with
    | Some ((v1, v2), stack') -> Some (push (v1 / v2) stack')
    | None -> None
 
// evaluate a list of instructions one-by-one, using tail recursion
// and return the final stack, tagged by Some; if an error occurs return None
let rec eval (instrs: instruction list) (stack: stack): stack option = 
  match instrs with
  | [] -> Some stack 
  | fstInst :: remInsts ->
      match eval1 fstInst stack with
      | None -> None
      | Some newStack -> eval remInsts newStack