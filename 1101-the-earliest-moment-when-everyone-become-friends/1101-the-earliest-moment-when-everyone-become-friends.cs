public class Solution {
    Node[] nodes = null;
    
    public int EarliestAcq(int[][] logs, int n) {
        nodes = new Node[n];
        int groupCount = n;
        
        for(int i = 0; i < n; i++){
            nodes[i] = new Node(i);
        }
        
        Array.Sort(logs, (a, b) => a[0].CompareTo(b[0]));
        
        for(int i = 0; i < logs.Length; i++){
            if(Find(logs[i][1]) != Find(logs[i][2])){
                Union(logs[i][1], logs[i][2]);
                groupCount--;
            }
            
            if(groupCount == 1){
                return logs[i][0];
            }
        }
        
        return -1;
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