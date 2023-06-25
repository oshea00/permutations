using System.Diagnostics;

// Test list to permutate
var list = new List<char>{'A','B','C','D','E'};

// Test implementations
Profile(new PermutationsHeaps(), list, print: true);
//Profile(new PermutationsRecursive(),list, print: true);

// Test Harness
void Profile<T>(Permutations p, List<T> list, bool print) {
    var stopwatch = new Stopwatch();
    stopwatch.Start();
    var tokens = p.GetPermutations(list).ToList();
    stopwatch.Stop();
    if (print)
        foreach(var t in tokens)
           System.Console.WriteLine(string.Join("",t));  
    System.Console.WriteLine($"Profiling {p.GetType().Name}:\nExecution time {stopwatch.ElapsedMilliseconds} millisconds");
    System.Console.WriteLine($"Executed {p.Executions} iterations");
    System.Console.WriteLine($"Created {tokens.Count} permutations\n");
}
