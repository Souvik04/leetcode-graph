public class Solution {
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        // create adjacency list
        List<int>[] graph = new List<int>[n];
        
        for(int i = 0; i < n; i++){
            graph[i] = new List<int>();
        }

        foreach(var e in edges){
            graph[e[0]].Add(e[1]);
            graph[e[1]].Add(e[0]);
        }

        // perform DFS
        return DFS(graph, source, destination, new HashSet<int>());
    }

    private bool DFS(List<int>[] graph, int source, int destination, HashSet<int> visited){
        if(source == destination){
            return true;
        }

        visited.Add(source);

        foreach(var neighbour in graph[source]){
            if(!visited.Contains(neighbour)){
                if(DFS(graph, neighbour, destination, visited)){
                    return true;
                }
            }
        }

        return false;
    }
}