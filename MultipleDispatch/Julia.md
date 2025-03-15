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

Open "Julia: Start REPL"

```
include("math_utils.jl")
include("test_math_utils.jl")
```


Visitor and Julia
-----------------

Visitor is a pattern that IS used in Java/.NET because these
languages are Single Dispatch. Julia has Multiple Dispatch
making Visitor obsolete.
