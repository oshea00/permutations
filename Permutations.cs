abstract class Permutations : IPermutations
{
    public int Executions { get; set; } = 0;
    abstract public IEnumerable<IEnumerable<T>> GetPermutations<T>(List<T> items);
}