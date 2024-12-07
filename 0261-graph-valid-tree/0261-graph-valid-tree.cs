public class Solution {
    Node[] nodes = null;
    public bool ValidTree(int n, int[][] edges) {
        // A tree must have exactly n - 1 edges
        if (edges.Length != n - 1) {
            return false;
        }
        
        nodes = new Node[n];
        
        for(int i = 0; i < n; i++){
            nodes[i] = new Node(i);
        }
        
        for(int i = 0; i < edges.Length; i++){
            int x = edges[i][0];
            int y = edges[i][1];
            
            if(Find(x) == Find(y)){
                return false;               
            }

            Union(x, y); 
        }
        
        return true;
    }
    
    private int Find(int n){
        if(nodes[n].parent != n){
            nodes[n].parent = Find(nodes[n].parent);
        }
        
        return nodes[n].parent;
    }
    
    private void Union(int x, int y){
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
        }
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