public class Solution {
    public int MinimumEffortPath(int[][] heights) {
        int m = heights.Length;
        int n = heights[0].Length;
        int[][] effortGrid = new int[m][];
        
        for(int i = 0; i < m; i++){
            effortGrid[i] = new int[n];
            Array.Fill(effortGrid[i], int.MaxValue);
        }
        
        PriorityQueue<(int effort, int x, int y), int> minHeap = new PriorityQueue<(int effort, int x, int y), int>();
        minHeap.Enqueue((0, 0, 0), 0);
        effortGrid[0][0] = 0;
        
        int[] dr = new int[4]{1, 0, -1, 0};
        int[] dc = new int[4]{0, -1, 0, 1};
        
        while(minHeap.Count > 0){
            var cur = minHeap.Dequeue();
            
            if(cur.x == m - 1 && cur.y == n - 1){
                return cur.effort;
            }
            
            // explore adjacent neighbors
            for(int i = 0; i < 4; i++){
                int newX = dr[i] + cur.x;
                int newY = dc[i] + cur.y;
                
                // check boundary conditions
                if(newX >= 0 && newX < m && newY >= 0 && newY < n){
                    // check if new effort is less current then update
                    int newEffort = Math.Max(cur.effort, Math.Abs(heights[newX][newY] - heights[cur.x][cur.y]));
                    
                    // update effort if its lesser than stored one for the target node
                    if(newEffort < effortGrid[newX][newY]){
                        effortGrid[newX][newY] = newEffort;
                        minHeap.Enqueue((newEffort, newX, newY), newEffort);
                    }
                }
            }
        }
        
        return -1;
    }
}

/*

Time complexity: O(m * n) * log(m * n)
Space complexity: O(m * n)

*/