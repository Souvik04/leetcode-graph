public class Solution {
    Node[] nodes = null;
    
    public int FindCircleNum(int[][] isConnected) {
        int n = isConnected.Length;
        int numberOfProvinces = n;        
        nodes = new Node[n];

        // fill nodes array
        for(int i = 0; i < n; i++){
            nodes[i] = new Node(i);
        }

        // perform union if nodes are connected
        for(int i = 0; i < n; i++){
            for(int j = i + 1; j < n; j++){

                if(isConnected[i][j] == 1 && Find(i) != Find(j)){
                    Union(i, j);
                    numberOfProvinces--;
                }
            }
        }

        return numberOfProvinces;
    }

    private int Find(int n){
        if(n != nodes[n].parent){
            nodes[n].parent = Find(nodes[n].parent);
        }

        return nodes[n].parent;
    }

    private bool Union(int x, int y){
        int rootX = Find(x);
        int rootY = Find(y);

        if(rootX == rootY){
            return false;
        }

        if (nodes[rootX].rank < nodes[rootY].rank){
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

    public class Node{
        public int rank;
        public int parent;

        public Node(int v){
            parent = v;
        }
    }
}