public class Solution {
    Node[] nodes = null;
    public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes) {
        int totalCost = 0;
        List<int[]> mst = new List<int[]>();
        nodes = new Node[n + 1];

        // initialize Union-Find nodes
        for(int i = 0; i <= n; i++){
            nodes[i] = new Node(i);
        }

        List<(int src, int dest, int wt)> edges = new List<(int src, int dest, int wt)>();
        
        // add virtual vertex (index with 0) along with the new edges
        for(int i = 0; i < wells.Length; i++){
            edges.Add((0, i + 1, wells[i]));
        }

        // add existing edges
        for(int i = 0; i < pipes.Length; i++){
            edges.Add((pipes[i][0], pipes[i][1], pipes[i][2]));
        }

        // sort the edges by weight
        edges.Sort((a, b) => a.wt.CompareTo(b.wt));

        // iterate over the edges and create MST
        foreach(var edge in edges){
            if(Union(edge.src, edge.dest)){
                totalCost += edge.wt;
            }
        }

        return totalCost;
    }

    private int Find(int n){
        if(nodes[n].parent != n){
            nodes[n].parent = Find(nodes[n].parent);
        }

        return nodes[n].parent;
    }

    private bool Union(int x, int y){
        int rootX = Find(x);
        int rootY = Find(y);

        if(rootX != rootY){
            if(nodes[rootX].rank < nodes[rootY].rank){
                nodes[rootX].parent = rootY;
            }
            else if(nodes[rootX].rank > nodes[rootY].rank){
                nodes[rootY].parent = rootX;
            }
            else{
                nodes[rootX].parent = rootY;
                nodes[rootY].rank++;
            }

            return true;
        }

        return false;
    }
}

public class Node{
    public int parent;
    public int rank;

    public Node(int parent){
        this.parent = parent;
        this.rank = 0;
    }
}