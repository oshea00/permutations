# Permutations
This is a rich area of somewhat well-trodden ground in computer science. 

The recursive algorithm looks pretty, but generates a lot of call stack frames. So not the most efficient out of the gate. For example ABCD has 4! (24) permutations, but it takes the recursive algorithm 65 calls to generate those 24 permutations.

Looking at the permutations it occurs that you can arrange the permutations such that each successive permutation is arrived at by swapping two positions in-place so that you theoretically only need to loop 24 times - quite an improvement over the naive recursive algorithms.

After confirming to myself that yes, indeed, you can arrange the order of swaps so that the deed can be done in the same buffer containing the original starting sequence by successively swapping two elements, I played around with the index values needed to choose the elements to swap at each iteration and found it depended on the ending sub sequence and choosing which element to "promote" outside the current sequence length and swap in the first position to begin iterating the next subsequence in-place. The same sequence at each stage can be re-played N times for an N-length starting sequence, but I was getting stuck on the transition swaps. Then looked at the internet and found a guy named Heap had already figured this out in 1963 and it is called **Heap's Algorithm**.

So, let's write some implementations and compare them.

## Cute recursion
This version is based on permutations being (recursively):
permutation(N) = Ni + permutation(N-1)

## Heap's Algorithm

I like the iterative approach. It is easy to understand, and has the benefit of not generating deep call stacks.

For further education, refer to the article: [Wikipedia Article](https://en.wikipedia.org/wiki/Heap%27s_algorithm#)

## Results
Surprisingly, the purely recursive version is not that much slower then the iterative Heap's version. I ran them both separately (see Program.cs). Increasing the length of the input. For shorter lengths ABCDE, the iterative is faster hands down, but increasing to ABCDEF there's a breakeven time - which I'm guessing is about the time that the JIT-compiled code is fully optimized between the two versions. Longer sequences ABCDEFGHIJK start to show the iterative approach winning out, but the time difference is a few seconds. The O-notation is pretty much O(n!), so even if the iterative approach saves some iterations, the total runtime is overwhelmed by the n! factor.

# Next
There is yet another algorithm related to pair swapping approaches called **Steinhaus–Johnson–Trotter** algorithm. 
This one may be fun to try next [Wikipedia Article](https://en.wikipedia.org/wiki/Steinhaus%E2%80%93Johnson%E2%80%93Trotter_algorithm
)
