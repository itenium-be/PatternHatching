Pattern Hatching
================

Pattern Hatching: Design Patterns Applied by John Vlissides.

- Boekenclub Session 1: p1 -> p34 (Composite, Proxy and Visitor)
- Boekenclub Session 2: p34 -> p54 (Template Method, Singleton and Mediator)
- Boekenclub Session 3: TBD


Chapter 1
---------

Top Ten Misconceptions (p3):

- _A pattern is a solution to a problem in a context_
    - Missing: Recurrence (relevant in multiple situations)
    - Missing: Teaching (name, consequences)
- _Patterns are just jargon, rules, programming tricks, data structures_
    - The "belittling dismissal"
    - The three stages of acceptance:
        1. Dismissed as rubbish
        2. It's nonviable
        3. Obvious and trivial "What've been doing all along"
- _Seen one, seen them all_
- _Patterns need tool or methodological support to be effective_
    - Patterns capture expertise and make it accsible to non-experts
    - Their names form a vocabulary to aid communication
    - Help us understand a system more quickly when documented with the patterns in use
- _Patterns guarantee reusable software, higher productivity, world peace etc_
    - Patterns don't guarantee anything
    - They are just another tool in the box
    - People speak of good patterns to produce an "Aha!" response
- _Patterns 'generate' whole architectures_
    - Patterns are unlikely to cover every aspect of the architecture
- _Patterns are for (object-oriented) design or implementations_
- _There's no evidence that patterns help anybody_
- _The pattern community is a clique of elites_
- _The pattern community is self-serving, even conspiratorial_

Chapter 2
---------

Designing with Patterns (p11)

- COMPOSITE: to model the FileSystem (File/Directory : INode)
- PROXY: to model symbolic links (Link : INode)
- VISITOR: to add extra functionality without bloating the COMPOSITE (SizeVisitor : IVisitor<int>)

See `Itenium.PatternHatching` for an implementation in C#
and `MultipleDispatch` how VISITOR is not needed in a
language such as Julia.


### Multi-User Protection (p34)

- TEMPLATE METHOD: have the base Node class implement security so the subclasses don't have to worry about it
- SINGLETON: a "Multiton" implementation for the Users of the system
- MEDIATOR: handle the two-way binding between Groups and Users


Chapter 3
---------

Themes and Variations (p55)

**To kill a singleton**:  
If we use a singleton for User which is created with `User::logIn`,
how do we manage User destruction?

Not really an issue when you're working in a Garbage Collected language!


**The Trouble with Observer**:  
A lot of redundancy due the Subject/Observer parallel hierarchy.
Have coarser grained Subject/Observers?

- For a UI redrawing everything, that could be very inefficient
- Have a `dirty` flag to keep track of what has changed?

This is also not really an issue when this is a language feature
(like in .NET)


**Visitor Revisited**:  
Make sure your hierarchy is somewhat stable when using visitor.


**Generation Gap**:  
Re-generate code but do allow to modify the generated code.  
Examples: VB6, .NET WinForms, gRPC.  
Using: Composition (ex Partials in .NET), or inheritance.


**Type Laundering**:  
Explicit casts are a sure sign of a design bug. How to create "events"
when we don't know what the events will be, how to access the specific
data and methods?

- Factory Method
- Prototype
- Generics/Templates

If you have an interface for, for example Factory Method, it must use
the base but if you want to do something with it, you have to work
with the derived type.

In .NET, we have `IEnumerable` and `IEnumerable<T>` because the first
version didn't have generics.

```c#
// Example
string json = JsonConvert.SerializeObject(someUnknownType);
T recovered = JsonConvert.DeserializeObject<T>(json);
```


**Thanks for the memory leaks**:  
Handle-Body Idiom (Pimpl — Pointer to IMPLementation)

Still useful in a managed language in some cases.  
Ex: A public handle and internal impl.  
Ex: Hide volatile internal type behind more stable public type


**Pushme-Pullyu**:  
A new event should result in creating one new class only.

Suggestion: static register/notify methods on the event class?
Have XEvent and XHandler classes?

--> Real solution? MULTICAST pattern?


Chapter 4
---------

Labor of Love (p111)

- Multicast: How is different from Observer
    - Observer: Register yourself to the source (Subject) to be notified when it changes (You observe something)
    - Multicast: Register yourself to an event to be notified when it happened, without knowing the source
        - Example: KeyPressEvent from both a Keyboard/Keypad. You don't care where the event originated from
- Multicast: Refinement of Observer + Typed Message?


Chapter 5
---------

Seven Habits of Effective Pattern Writers (p133)

- Taking time to reflect
- Adhering to a structure
- Being Concrete Early and Often
- Keeping Patterns Distinct and Complementary
- Presenting Effectively
- Iterating Tirelessly
- Collecting and Incorporating Feedback

No Silver Bullet.
