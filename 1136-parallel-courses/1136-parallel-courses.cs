public class Solution {
    public int MinimumSemesters(int n, int[][] relations) {
        int minSemesters = 0;
        List<int>[] graph = new List<int>[n + 1];
        int[] inDegrees = new int[n + 1];
        Queue<int> queue = new Queue<int>();
        
        // build graph
        for(int i = 1; i <= n; i++){
            graph[i] = new List<int>();
        }
        
        foreach(int[] r in relations){
            graph[r[0]].Add(r[1]);
            inDegrees[r[1]]++;
        }
        
        // enqueue 0 in-degrees into queue
        for(int i = 1; i <= n; i++){
            if(inDegrees[i] == 0){
                queue.Enqueue(i);
            }
        }
        
        // perform topological sort
        int courseCount = 0;
        
        while(queue.Count > 0){
            int count = queue.Count;
            minSemesters++;
            
            for(int i = 0; i < count; i++){
                int cur = queue.Dequeue();
                courseCount++;
                
                foreach(int nbr in graph[cur]){
                    inDegrees[nbr]--;
                    
                    if(inDegrees[nbr] == 0){
                        queue.Enqueue(nbr);
                    }
                }
            }
        }
        
        // courseCount should be equal to n if all nodes processed
        return courseCount == n ? minSemesters : -1;
    }
}

/*

Time complexity: O(V + E)
Space complexity: O(V + E)

*/