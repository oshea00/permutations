class PermutationsRecursive : Permutations
{
    public override IEnumerable<IEnumerable<T>> GetPermutations<T>(List<T> items)
    {
        var perms = new List<List<T>>();
        void PermsHelp(T[] a,int start, int end) {
            ++Executions;
            if (start == end)
            {
                perms.Add(new List<T>(a));
            }
            for (int i=start; i<end; i++) {
                (a[i], a[start]) = (a[start], a[i]);
                PermsHelp(a, start + 1, end);
                (a[i], a[start]) = (a[start], a[i]);
            }
        }
        PermsHelp(items.ToArray(),0,items.Count);
        foreach (var p in perms) {
            yield return p;
        }
    }
}
