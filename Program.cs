var tokens = Permutations.GetPermutations(new List<char>{'A','B','C','D'}).ToList();
var dict = new Dictionary<string,List<char>>();
var stack = new Stack<TreeNode>();

void BuildTree() {
    while (stack.Count>0)
    {
        var node = stack.Pop();
        if (node.Children.Count>0)
        {
            foreach (var c in node.Children) {
                stack.Push(c);
            }
        }
        else
        {
            var t = node.Value;        
            for (int i=0; i < t.Count; i++) {
                for (int j=i+1; j < t.Count; j++) {
                    var tag = new List<char> { t[0],t[1],t[2],t[3] };
                    (tag[i], tag[j]) = (tag[j], tag[i]);
                    if (!dict.ContainsKey(String.Join("",tag)))
                    {
                        dict[String.Join("",tag)] = tag;
                        var child = new TreeNode { Value = tag , Tag = String.Join("",tag)};
                        node.Children.Add(child);
                    }
                }
            }
            stack.Push(node);
        }
    }
}

var node = new TreeNode { Value = tokens[0], Tag = String.Join("",tokens[0])};
stack.Push(node);
BuildTree();
foreach (var s in stack)
{
    System.Console.WriteLine(s.Tag);
}
System.Console.WriteLine(node.Value);


class TreeNode {
    public IList<char> Value { get; set; } = null!;
    public string Tag { get; set; } = null!;
    public List<TreeNode> Children { get; set; } = new List<TreeNode>();
}

// foreach (var perm in perms)
// {
//     foreach (var p in perm)
//     {
//         Console.Write(p);
//     }
//     Console.WriteLine();
// }
