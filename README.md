# Calculator
 
Welcome to my calculator project !

I did as requested, a calculator on the WEB that is capable of doing a series of arithmetic operations, and showing the history.

About the history i saved it in the local storage to have a different history per user (i would have usually used a service as Auth0 and save the history in the DB).

The only issue that i had was to find a solution for the order of operations in a serie of operations.

I had the idea of a tree with a recursive, I checked online and found the Suffix (or Postfix) expressions.

I compared both solutions and found out that the second one is the best so i went to this idea.

I used a queue and temporary stack to build and solve it, and wrote unit tests for each step.

I separated everything on the Web and API for it to be re-usable, easy to maintain and change.

Handled errors and showed in case of situations like dividing by 0..

I'm available if you have questions.

Thank you and have a nice day.