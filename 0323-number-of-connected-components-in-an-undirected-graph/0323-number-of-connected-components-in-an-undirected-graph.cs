public class Solution {
    Node[] nodes = null;
    
    public int CountComponents(int n, int[][] edges) {
        if(n == 0 || edges.Length == 0){
            return 0;
        }
        
        int components = n;
        
        nodes = new Node[n];
        
        for(int i = 0; i < n; i++){
            nodes[i] = new Node(i);
        }
        
        for(int i = 0; i < edges.Length; i++){
            if(Find(edges[i][0]) != Find(edges[i][1])){
                Union(edges[i][0], edges[i][1]);
                components--;
            }
        }
        
        return components;
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
                nodes[rootY].parent = nodes[rootX].parent;
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