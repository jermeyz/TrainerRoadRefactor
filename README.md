TrainerRoadRefactor
===================

I hope you get a good picture of my coding style from looking at how I did the refactor.

There were many changes I made to this project.  The changes will help support expanding the code bases functionality going forward as well as making the code more readable.

Some of the issues I saw:

Duplication of code.  the total calculations and discount logic where duplicated.  I pulled these out into seperate types that do one thing well instead of many things,  Single Responsibility.

Tight Coupling.  The code was very tightly coupled.  Each method to render a receipt contained all the code it needed to do so.  I created many new types that each have a very specific purpose.

Refactoring in my opinion is never really done.  Each new change to a system is a opportunity to make the code better.  Based on the requirements in the instructions I feel I took it to a suffucient level.  There is of course room for more changes in this system but with time always being a constraint you need to be pragmatic about it.

I also added many new tests.  For each new type that was added I used a coverage tool to ensure that there was a reasonable amount of coverage aginst the new code.  I also left the exisiting test assertions unchanged.  That way I know the code is at least doing the same thing that it was before the refactor.

I made some comments inline in the code where I wanted to point out why I made the change I did.  Enjoy!!!
