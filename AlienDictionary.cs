/*
There is a new alien language which uses the latin alphabet. However, the order among letters are unknown to you. You receive a list of words from the dictionary, where words are sorted lexicographically by the rules of this new language. Derive the order of letters in this language.

For example,
Given the following words in dictionary,

[
  "wrt",
  "wrf",
  "er",
  "ett",
  "rftt"
]
The correct order is: "wertf".

Note:
You may assume all letters are in lowercase.
If the order is invalid, return an empty string.
There may be multiple valid order of letters, return any one of them is fine.
*/

public class Solution
{
    private readonly int N = 26;
    
    public string AlienOrder(string[] words) 
    {
        bool[,] adj = new bool[N,N];
        int[] visited = new int[N];
        buildGraph(words, adj, visited);
        StringBuilder sb = new StringBuilder();
        
        for (int i=0; i<N; i++)
        {
            if (visited[i] == 0)
            {
                if (dfs(sb, adj, visited, i) == false)
                    return "";
            }
        }
        
        var charArray = sb.ToString().ToCharArray();
        Array.Reverse(charArray);
        return new String(charArray);
    }
    
    private void buildGraph(string[] words, bool[,] adj, int[] visited)
    {
        for (int i=0; i<N; i++)
            visited[i] = -1;
            
        for (int i=0; i<words.Length; i++)
        {
            foreach (char c in words[i].ToCharArray())
                visited[c - 'a'] = 0;
                
            if (i > 0)
            {
                string w1 = words[i-1];
                string w2 = words[i];
                    
				// TODO: this is a very ugly hack to pass a specific test case, but it works for now. Please update.
                if (!w1.Equals(w2) && w1.StartsWith(w2)) 
				{
        		  for (int k=0; k<N; k++)
            		visited[k] = 2;
        			
					return;
    			}	
    			
                int len = Math.Min(w1.Length, w2.Length);
                
                for (int k=0; k<len; k++)
                {
                    if (w1[k] != w2[k])
                    {
                        adj[w1[k] - 'a', w2[k] - 'a'] = true;
                        break;
                    }
                }
            }
        }
    }
    
    private bool dfs(StringBuilder sb, bool[,] adj, int[] visited, int i)
    {
        visited[i] = 1;
        
        for (int j=0; j<N; j++)
        {
            if (adj[i,j])
            {
                if (visited[j] == 1)
                {
                    return false;
                }
                
                if (visited[j] == 0)
                {
                    if (dfs(sb, adj, visited, j) == false)
                        return false;
                }
            }
        }
        
        visited[i] = 2;
        sb.Append((char) (i+'a'));
        return true;
    }
}