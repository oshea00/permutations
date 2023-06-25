interface IPermutations {
    IEnumerable<IEnumerable<T>> GetPermutations<T>(List<T> items);
}