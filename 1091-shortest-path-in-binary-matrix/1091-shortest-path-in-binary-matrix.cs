public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        
        if(m == 1 && n == 1 && grid[0][0] == 0){
            return 1;
        }

        if(grid[0][0] == 1 || grid[m - 1][n - 1] == 1){
            return -1;
        }

        int shortestPath = 1;
        Queue<(int i, int j)> queue = new Queue<(int i, int j)>();
        queue.Enqueue((0, 0));
        HashSet<(int, int)> visited = new HashSet<(int, int)>();

        // 8 possible directions
        int[] dirX = new int[8]{0, -1, -1, -1, 0, 1, 1, 1};
        int[] dirY = new int[8]{-1, -1, 0, 1, 1, 1, 0, -1};
        
        while(queue.Count > 0){
            int level = queue.Count;

            for(int i = 0; i < level; i++){
                var cur = queue.Dequeue();

                if(cur.i == m - 1 && cur.j == n - 1){
                    return shortestPath;
                }

                visited.Add(cur);

                // perform BFS in 8 directions
                for(int d = 0; d < 8; d++){
                    int newX = cur.i + dirX[d];
                    int newY = cur.j + dirY[d];

                    // boundary conditions
                    if(newX >= 0 && newX < m && newY >= 0 && newY < n
                        && grid[newX][newY] == 0 && !visited.Contains((newX, newY))){
                        queue.Enqueue((newX, newY));
                        visited.Add((newX, newY));
                    }
                }
            }

            shortestPath++;
        }

        return -1;
    }
}