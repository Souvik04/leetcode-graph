//DFS
public class Solution {

  public int ans = Int32.MaxValue;
  public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K) {

      var map = new Dictionary<int, List<int[]>>();
      foreach(var f in flights)
      {
        if(map.ContainsKey(f[0]))
        {
          map[f[0]].Add(new int[]{f[1], f[2]});
        }
        else{
          map.Add(f[0], new List<int[]>());
          map[f[0]].Add(new int[]{f[1], f[2]});
        }
      }  
      
      DFS(map, src, dst, K+1, 0);
      
      return ans == Int32.MaxValue? -1 : ans;
  }


  public void DFS(Dictionary<int, List<int[]>> map, int start, int dst, int K, int cost){
   if(K == 0)
   {
     if(start == dst) ans = Math.Min(cost, ans);
     return;
   }

   if(start == dst) {
    if(start == dst) ans = Math.Min(cost, ans);
    return;
   }
      
   if(!map.ContainsKey(start))
   {
       return;
   }
      
   var temp = map[start];
      
   foreach(var r in temp)
   {
     if(cost + r[1] >= ans) continue;
     DFS(map, r[0], dst, K-1, cost + r[1]);
   }
  }
}
