/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        return DFS(node, new Dictionary<Node, Node>());
    }

    private Node DFS(Node sourceNode, Dictionary<Node, Node> visited){
        if(sourceNode == null){
            return sourceNode;
        }
        
        if(visited.ContainsKey(sourceNode)){
            return visited[sourceNode];
        }

        Node newNode = new Node(sourceNode.val);
        visited[sourceNode] = newNode;

        foreach(Node neighbor in sourceNode.neighbors){
            Node newNeighbor = DFS(neighbor, visited);
            newNode.neighbors.Add(newNeighbor);
        }

        return newNode;
    }
}

/*

Time complexity: O(V + E)
Space complexity: O(V + E)

*/