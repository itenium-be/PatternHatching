Julia: Multiple Dispatch
========================

**Iterator**:  
Provide a way to access the elements of an aggregate object sequentially
without exposing its underlying representation.

This is a GoF design pattern you don't have to implement in Java/.NET
because, it is available out of the box!

```c#
public class Directory
{
  public IEnumerable<INode> Children { get; }
}
```

Julia
-----

- [Download Julia](https://julialang.org/downloads/)
- [VSCode Extension](https://github.com/julia-vscode/julia-vscode)
  - Might need to set `julia.executablePath` in settings

Run with `Control + F5` or Open "Julia: Start REPL"

```jl
include("test_SizeCalculator.jl")
```


Visitor and Julia
-----------------

Visitor is a pattern that IS used in Java/.NET because these
languages are Single Dispatch. Julia has Multiple Dispatch
making Visitor unnecessary.

Typically:

- Single Dispatch: the method to call depends on one object (the runtime type of the object on which the method is called)
- Double Dispatch: depends on two objects, the receiver and one argument (=Visitor)
- Multiple Dispatch: depends on the runtime type of all arguments
