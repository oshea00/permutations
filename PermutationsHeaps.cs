class PermutationsHeaps : Permutations
{
    public override IEnumerable<IEnumerable<T>> GetPermutations<T>(List<T> items)
    {
        var a = items.ToArray();
        var c = new int[items.Count];        
        int i = 0;

        for (i=0; i<items.Count; i++)
            c[i]=0;
        
        ++Executions;
        yield return new List<T>(a);
        
        i=1;
        while (i<items.Count) {
            ++Executions;
            if (c[i] < i) {
                if (i%2 == 0) {
                    (a[0], a[i]) = (a[i], a[0]);
                } else {
                    (a[c[i]], a[i]) = (a[i], a[c[i]]);
                }
                yield return new List<T>(a);
                c[i] += 1;
                i = 1;
            } else {
                c[i] = 0;
                i += 1;
            }
        }
    }
}