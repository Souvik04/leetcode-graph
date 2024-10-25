public class Solution {
    IList<IList<int>> paths = null;
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        paths = new List<IList<int>>();
        Backtrack(graph, new List<int>(){0}, 0);
        return paths;
    }

    private void Backtrack(int[][] graph, List<int> temp, int source){
        if(source == graph.Length - 1){
            paths.Add(temp.ToList());
        }
        else{
            foreach(var n in graph[source]){
                temp.Add(n);
                Backtrack(graph, temp, n);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}