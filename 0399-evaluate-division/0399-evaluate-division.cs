public class Solution {
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        // construct the graph
        List<double> output = new List<double>();
        Dictionary<string, Dictionary<string, double>> graph = new Dictionary<string, Dictionary<string, double>>();
        int n = equations.Count();

        for(int i = 0; i < n; i++){
            string source = equations[i][0];
            string destination = equations[i][1];
            double value = values[i];

            if(!graph.ContainsKey(source)){
                graph[source] = new Dictionary<string, double>();
            }

            if(!graph.ContainsKey(destination)){
                graph[destination] = new Dictionary<string, double>();
            }

            graph[source][destination] = value;
            graph[destination][source] = 1.0 / value;
        }

        // query the graph- DFS
        foreach(var q in queries){
            double result = DFS(graph, q[0], q[1], new HashSet<string>());
            output.Add(result);
        }

        return output.ToArray();
    }

    private double DFS(Dictionary<string, Dictionary<string, double>> graph, string source, string destination, HashSet<string> visited){
        if(!graph.ContainsKey(source) || !graph.ContainsKey(destination)){
            return -1.0;
        }

        if(source == destination){
            return 1.0;
        }

        visited.Add(source);

        // perform DFS
        foreach(var neighbor in graph[source]){
            string nextNode = neighbor.Key;
            double value = neighbor.Value;

            if(!visited.Contains(nextNode)){
                double result = DFS(graph, nextNode, destination, visited);

                if(result != -1.0){
                    return value * result;
                }
            }
        }

        return -1.0;
    }
}