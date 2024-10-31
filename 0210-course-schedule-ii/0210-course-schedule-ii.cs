public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        List<int> courses = new List<int>();
        List<int>[] graph = new List<int>[numCourses];
        int[] inDegrees = new int[numCourses];
        Queue<int> queue = new Queue<int>();

        for(int i = 0; i < numCourses; i++){
            graph[i] = new List<int>();
        }

        foreach(int[] p in prerequisites){
            graph[p[1]].Add(p[0]);
            inDegrees[p[0]]++;
        }

        for(int i = 0; i < numCourses; i++){
            if(inDegrees[i] == 0){
                queue.Enqueue(i);
            }
        }

        while(queue.Count > 0){
            int cur = queue.Dequeue();
            courses.Add(cur);
            
            foreach(int neighbor in graph[cur]){
                inDegrees[neighbor]--;

                if(inDegrees[neighbor] == 0){
                    queue.Enqueue(neighbor);
                }
            }
        }

        return courses.Count == numCourses ? courses.ToArray() : new int[0];
    }
}


/*

Kahn's algorithm

• Initialize in-degree array: Count in-degrees for all vertices (number of incoming edges).
• Enqueue zero in-degree vertices: Add vertices with in-degree 0 to a queue, as they have no dependencies.
• Process vertices in queue:
	• Remove a vertex from the queue and add it to the topological order.
	• Decrease the in-degree of all its neighbors by 1.
	• If a neighbor's in-degree becomes 0, add it to the queue.
• Check for cycles:
If the topological order list doesn’t include all vertices, a cycle exists (sorting isn’t possible).

Time complexity: O(V + E)
Space complexity: O(V + E)

*/