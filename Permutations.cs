public class Permutations
{ 
    public static IEnumerable<string> GetPermutations(string item) {
        foreach (var p in GetPermutations(item.ToList())) {
            yield return String.Join("",p);
        }
    }

    public static IEnumerable<IList<T>> GetPermutations<T>(IList<T> items) {
        if (items.Count == 0) {
            yield break;
        }
        if (items.Count == 1) {
            yield return new List<T> {items[0]};
        }

        for (var i=0; i<items.Count; i++)
        {
            var sublist = new List<T>();
            for (var j=0; j<items.Count; j++)
            {
                if (j!=i)
                    sublist.Add(items[j]);
            }
            foreach (var s in GetPermutations(sublist)) {
                s.Add(items[i]);
                yield return s;
            }            
        }
    } 
}
