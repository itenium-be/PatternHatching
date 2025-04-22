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
