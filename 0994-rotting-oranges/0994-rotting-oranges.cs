public class Solution {
    public int OrangesRotting(int[][] grid) {
        int minutes = 0;
        int m = grid.Length;
        int n = grid[0].Length;
        int freshOrangeCount = 0;
        Queue<(int i, int j)> queue = new Queue<(int i, int j)>();

        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(grid[i][j] == 2){
                    queue.Enqueue((i, j));
                }
                else if(grid[i][j] == 1){
                    freshOrangeCount++;
                }
            }
        }

        if(freshOrangeCount == 0){
            return 0;
        }

        // directions
        int[] dr = new int[4]{0, -1, 0, 1};
        int[] dc = new int[4]{-1, 0, 1, 0};

        while(queue.Count > 0){
            int level = queue.Count;

            for(int i = 0; i < level; i++){
                var cur = queue.Dequeue();

                for(int d = 0; d < 4; d++){
                    int newX = cur.i + dr[d];
                    int newY = cur.j + dc[d];

                    // check boundary conditions
                    if(newX >= 0 && newX < m && newY >= 0 && newY < n && grid[newX][newY] == 1){
                            queue.Enqueue((newX, newY));
                            grid[newX][newY] = 2;
                            freshOrangeCount--;                            
                        }
                }
            }

            minutes++;
        }

        return freshOrangeCount == 0 ? minutes - 1 : -1;
    }
}