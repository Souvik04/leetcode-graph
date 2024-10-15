public class Solution {
    Node[] nodes = null;

    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs) {
        if (s.Length == 0 || pairs.Count == 0) {
            return s;
        }

        char[] result = s.ToCharArray();
        int n = s.Length;
        nodes = new Node[n];

        // fill nodes
        for(int i = 0; i < n; i++){
            nodes[i] = new Node(i);
        }

        // perform union on pairs of indices
        foreach(var pair in pairs){
            Union(pair[0], pair[1]);
        }

        // group indices belonging to same root
        Dictionary<int, List<int>> group = new Dictionary<int, List<int>>();
        for(int i = 0; i < n; i++){
            int parent = Find(i);
            
            if(!group.ContainsKey(parent)){
                group[parent] = new List<int>();
            }

            group[parent].Add(i);
        }

        // sort the characters in each components and place them back
        foreach(var kv in group){
            List<char> chars = new List<char>();

            // collect the chars at grouped indices
            foreach(int index in kv.Value){
                chars.Add(result[index]);
            }

            chars.Sort();         

            // reconstruct the string by putting sorted characters back at respective indices
            for(int i = 0; i < kv.Value.Count; i++){
                result[kv.Value[i]] = chars[i];
            }
        }

        return new string(result);
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

    public class Node{
        public int rank;
        public int parent;

        public Node(int v){
            this.parent = v;
        }
    }
}

/*

1. Initialize: Create a parent array for Union-Find where each index is its own parent initially.
2. Union Operations: Iterate through each pair in the pairs array and perform union on the two indices.
3. Group Components: After union operations, group indices that belong to the same root.
4. Sort Components: Sort the characters in each group/component to get the smallest order.
5. Reconstruct the String: Rebuild the string by placing the sorted characters back at their respective indices.

*/