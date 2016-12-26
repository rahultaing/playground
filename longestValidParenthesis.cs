public class Solution {
    public int LongestValidParentheses(string s) {
          int n = s.Length;
		if (n == 0)
			return 0;
		
		Stack<int> stack = new Stack<int>();
		for (int i=0; i<n; i++)
		{
			if (s[i] == '(')
				stack.Push(i);
				
			if (s[i] == ')')
			{
				if (stack.Count != 0 && s[stack.Peek()] == '(')
				{
					stack.Pop();
				}
				else
				{
					stack.Push(i);
				}
			}
		}
		
		int a = n; 
		int b = 0;
		int longest = 0;
		
		if (stack.Count == 0)
			return n;
			
		while (stack.Count != 0)
		{
			b = stack.Pop();
			Console.WriteLine("b = {0}", b);
			longest = Math.Max(longest, a-b-1);
			a=b;
		}
		
		return Math.Max(longest, a);
    }
}