public class Solution {
    public bool LeadsToDestination(int n, int[][] edges, int source, int destination) {
        List<int>[] graph = new List<int>[n];
        
        for(int i = 0; i < n; i++){
            graph[i] = new List<int>();
        }
        
        foreach(int[] edge in edges){
            graph[edge[0]].Add(edge[1]);
        }

        if(graph[destination].Count > 0){
            return false;
        }
        
        return DFS(graph, source, destination, new int[n]);
    }
    
    private bool DFS(List<int>[] graph, int source, int destination, int[] visitedState){
        // if visiting, cycle detected
        if(visitedState[source] == 1){
            return false;
        }
        
        // already processed completely
        if(visitedState[source] == 2){
            return true;
        }
        
        // reached end but not destination
        if(graph[source].Count == 0 && source != destination){
            return false;
        }
        
        // visiting in progress
        visitedState[source] = 1;
        
        foreach(int d in graph[source]){
            if(!DFS(graph, d, destination, visitedState)){
                return false;
            }
        }
        
        visitedState[source] = 2;
        return true;
    }
}