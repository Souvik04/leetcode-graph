public class Solution {
    IList<string> output = null;
    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        output = new List<string>();

        // create graph
        Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

        foreach(var ticket in tickets){
            string from = ticket[0];
            string to = ticket[1];

            if(!graph.ContainsKey(from)){
                graph[from] = new List<string>();
            }

            graph[from].Add(to);
        }

        // sort the graph for each source and destinations
        foreach(var key in graph.Keys){
            graph[key].Sort((a, b) => string.Compare(a, b));
        }

        // perform DFS
        Backtrack(graph, "JFK");

        return output;
    }

    private void Backtrack(Dictionary<string, List<string>> graph, string source){
        if(graph.ContainsKey(source)){
            List<string> destinations = graph[source];

            while(destinations.Count > 0){
                string next = destinations[0];
                destinations.RemoveAt(0);
                Backtrack(graph, next);                
            }
        }

        output.Insert(0, source);
    }
}

/*

Time complexity: O(E + V * dlogd)
Space complexity: O(E + V)

*/