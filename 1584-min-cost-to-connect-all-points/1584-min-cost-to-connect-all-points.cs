public class Solution {
    Node[] nodes = null;
    public int MinCostConnectPoints(int[][] points) {
        int minCost = 0;
        int n = points.Length;
        List<((int p1, int p2), int w)> pointsWithWeight = new List<((int p1, int p2), int w)>();

        // iterate over each points and calculate mahattan distance
        for(int i = 0; i < n; i++){
            for(int j = i + 1; j < n; j++){
                if(i == j){
                    continue;
                }

                int x1 = points[i][0];
                int x2 = points[j][0];
                int y1 = points[i][1];
                int y2 = points[j][1];

                int manhattanDistance = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
                pointsWithWeight.Add(((i, j), manhattanDistance));                
            }
        }

        // sort by weight
        pointsWithWeight.Sort((a, b) => a.w.CompareTo(b.w));

        // create Union-Find (disjoint set)
        nodes = new Node[n];

        for(int i = 0; i < n; i++){
            nodes[i] = new Node(i);
        }

        // create MST by performing Union-Find
        IList<((int p1, int p2), int w)> mst = new List<((int p1, int p2), int w)>();
        foreach(var pw in pointsWithWeight){
            int source = Find(pw.Item1.p1);
            int destination = Find(pw.Item1.p2);

            if(source != destination){
                mst.Add(pw);
                Union(source, destination);
            }
        }

        // iterate over MST and calculate the min cost
        foreach(var m in mst){
            minCost += m.w;
        }

        return minCost;
    }

    public class Node{
        public int parent;
        public int rank;

        public Node(int v){
            this.parent = v;
        }
    }

    public int Find(int n){
        if(n != nodes[n].parent){
            n = Find(nodes[n].parent);
        }

        return nodes[n].parent;
    }

    public bool Union(int x, int y){
        int rootX = Find(x);
        int rootY = Find(y);

        if(rootX == rootY){
            return true;
        }
        else if(nodes[rootX].rank > nodes[rootY].rank){
            nodes[rootY].parent = rootX;
        }
        else if(nodes[rootX].rank < nodes[rootY].rank){
            nodes[rootX].parent = rootY;
        }
        else{
            nodes[rootX].parent = rootY;
            nodes[rootY].rank++;
        }

        return false;
    }
}

/*

1. iterate over each points and calculate the manhattan distance between them
2. store each pair of points in a collection- (point#, weight) and sort them by weight
3. create Union-Find (disjoint set) for the pair of points
4. perform Kruskal's algorithm to get the MST
5. iterate over the MST edges and calculate the cost

Time complexity: O(n^2)
Space complexity: O(n)

*/