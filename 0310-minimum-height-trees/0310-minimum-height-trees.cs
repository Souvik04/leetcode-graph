public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        if(n == 0){
            return new List<int>();
        }

        if(n == 1 && edges.Length == 0){
            return new List<int>(){0};
        }

        IList<int> output = new List<int>();
        List<int>[] graph = new List<int>[n];
        int[] inDegrees = new int[n];
        Queue<int> queue = new Queue<int>();

        for(int i = 0; i < n; i++){
            graph[i] = new List<int>();
        }

        foreach(var edge in edges){
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
            inDegrees[edge[1]]++;
            inDegrees[edge[0]]++;
        }

        for(int i = 0; i < n; i++){
            if(inDegrees[i] == 1){
                queue.Enqueue(i);
            }
        }

        int remainingNodes = n;

        while(remainingNodes > 2){
            int leaves = queue.Count;
            remainingNodes -= leaves;

            for(int i = 0; i < leaves; i++){
                int leaf = queue.Dequeue();
            
                foreach(int neighbor in graph[leaf]){
                    inDegrees[neighbor]--;

                    if(inDegrees[neighbor] == 1){
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        output = new List<int>();

        while(queue.Count > 0){
            output.Add(queue.Dequeue());
        }

        return output;
    }
}

/*

Time complexity: O(V + E)
Space complexity: O(V + E)

*/