public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        // create graph
        Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();

        for(int i = 0; i < n; i++){
            graph[i] = new List<Edge>();
        }

        foreach(int[] flight in flights){
            int from = flight[0];
            int to = flight[1];
            int cost = flight[2];

            graph[from].Add(new Edge(to, cost));
        }

        // initialize prices to infinity and source price to 0
        int[] prices = new int[n];
        Array.Fill(prices, int.MaxValue);
        prices[src] = 0;

        // perform Bellman-Ford algorithm upto k + 1 iterations
        for(int i = 0; i < k + 1; i++){
            // temp prices cloned from prices for each iteration/path
            int[] temp = (int[])prices.Clone();

            foreach(var node in graph.Keys){
                foreach(var edge in graph[node]){
                    int from = node;
                    int to = edge.TargetNode;
                    int cost = edge.Weight;

                    // check if source to destination price can be minimized
                    if(prices[from] != int.MaxValue && prices[from] + cost < temp[to]){
                        temp[to] = prices[from] + cost;
                    }
                }
            }

            // update main prices
            prices = temp;
        }

        return prices[dst] == int.MaxValue ? -1 : prices[dst];
    }

    public class Edge{
        public int TargetNode {get; set;}
        public int Weight {get; set;}

        public Edge(int targetNode, int weight){
            this.TargetNode = targetNode;
            this.Weight = weight;
        }
    }
}

/*

Time complexity: O(k * E)
Space complexity: O(n)

*/