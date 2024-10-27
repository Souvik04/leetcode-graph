/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<IList<int>> LevelOrder(Node root) {
        IList<IList<int>> output = new List<IList<int>>();
        
        if(root == null){
            return output;
        }        
        
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        while(queue.Count > 0){
            int level = queue.Count;
            IList<int> currList = new List<int>();

            for(int i = 0; i < level; i++){
                Node node = queue.Dequeue();

                currList.Add(node.val);
                
                foreach(Node child in node.children){
                    queue.Enqueue(child);
                }
            }

            output.Add(currList);
        }

        return output;
    }
}

/*

Time complexity: O(n)
Space complexity: O(n)

*/