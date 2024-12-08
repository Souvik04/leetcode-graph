public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        int minDelay = int.MinValue;
        k--;
        int[] distances = new int[n];
        PriorityQueue<(int node, int distance), int> minHeap = new PriorityQueue<(int node, int distance), int>();
        List<(int targetNode, int weight)>[] graph = new List<(int targetNode, int weight)>[n];
        
        for(int i = 0; i < n; i++){
            graph[i] = new List<(int targetNode, int weight)>();
        }
        
        foreach(int[] time in times){
            graph[time[0] - 1].Add((time[1] - 1, time[2]));
        }
        
        Array.Fill(distances, int.MaxValue);
        distances[k] = 0;
        minHeap.Enqueue((k, 0), 0);
        
        while(minHeap.Count > 0){
            var cur = minHeap.Dequeue();
            int currentNode = cur.node;
            int currentDistance = cur.distance;
            
            if(distances[currentNode] < currentDistance){
                continue;
            }
            
            // explore neighbors
            foreach(var nbr in graph[currentNode]){
                int newDistance = currentDistance + nbr.weight;
                
                // du + w < dv
                if(newDistance < distances[nbr.targetNode]){
                    distances[nbr.targetNode] = newDistance;
                    minHeap.Enqueue((nbr.targetNode, newDistance), newDistance);
                }
            }
        }
        
        foreach(int d in distances){
            if(d == int.MaxValue){
                return -1;
            }
            
            minDelay = Math.Max(minDelay, d);
        }
        
        return minDelay;
    }
}

/*

Time complexity: O(ElogV + VlogV) = O((V + E)logV)
Space complexity: O(V + E)

*/