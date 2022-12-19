# electrode-list-simplifier

Solution contains 3 projects: 
- Simple WPF UI
- Library with the required logic
- Unit tests for the library

I didn't know what do you expect from the code-style perspective and I didn't have much time for fancy stuff I just went to extension functions (as I started to like static more than before) + a simple object to split Electrode name and number in the object constructor.

Also, the actual logic code in `.ToSimplifiedString()` looks a bit messy, I understand that. Though, there're good points: the complexity is good: `O(L) + M * O(log(M)) + O(N) * O(M)`, where:

- N - amount of Electode name prefixes
- M - amount of numbers by each category
- Also, plus some complexity to fill in the SortedSet before the actual execution, M * O(log(M)) 
- Also, plus splitting the names and numbers of Electodes before the actual execution = O(L), where L - amount of symbols in string

So, Instead of breaking a head for the most visually great version I've decided to spend more time on proper testing with unit tests.

But I hope you're not gonna judge too heavy as I had 1 minute notice and no choice. 😃

Cheers!
