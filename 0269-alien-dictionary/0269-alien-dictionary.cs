public class Solution {
    public string AlienOrder(string[] words) {
        if(words.Length == 0){
            return "";
        }
        
        StringBuilder result = new StringBuilder();
        HashSet<char>[] graph = new HashSet<char>[26];
        int[] inDegrees = new int[26];
        HashSet<char> validCharacters = new HashSet<char>();
        Queue<char> queue = new Queue<char>();

        // build the graph
        for(int i = 0; i < 26; i++){
            graph[i] = new HashSet<char>();
        }

        for(int i = 0; i < words.Length; i++){
            foreach(char c in words[i]){
                validCharacters.Add(c);
            }

            if(i > 0){
                string prev = words[i - 1];
                string cur = words[i];
                int minLen = Math.Min(prev.Length, cur.Length);
                bool isDiff = false;

                for(int idx = 0; idx < minLen; idx++){
                    if(prev[idx] != cur[idx]){
                        int from = prev[idx] - 'a';
                        int to = cur[idx] - 'a';
                        char val = (char)(to + 'a');

                        if(!graph[from].Contains(val)){
                            graph[from].Add(val);
                            inDegrees[to]++;
                        }

                        isDiff = true;
                        break;                        
                    }
                }

                // words are out of order. e.g.: abc, ab
                if(!isDiff && prev.Length > cur.Length){
                    return "";
                }                
            }
        }

        // enqueue 0 in-degrees into queue
        foreach(char c in validCharacters){
            if(inDegrees[c - 'a'] == 0){
                queue.Enqueue(c);
            }
        }

        // perform topological sort (Kahn's algorithm)
        while(queue.Count > 0){
            char cur = queue.Dequeue();
            result.Append(cur);

            foreach(char c in graph[cur - 'a']){
                inDegrees[c - 'a']--;

                if(inDegrees[c - 'a'] == 0){
                    queue.Enqueue(c);
                }
            }
        }

        return result.Length == validCharacters.Count ? result.ToString() : "";
    }
}