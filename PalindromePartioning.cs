/* 
	Palindrome Partioning
	Given a string s, partition s such that every substring of the partition is a palindrome.
	Return all possible palindrome partitioning of s.
	For example, given s = "aab",
	Return
	[
  		["aa","b"],
  		["a","a","b"]
	]
*/
public class Solution
{
	private IList<IList<string>> result = new List<IList<string>>();
	private List<string> current = new List<string>(); 
	
	public IList<IList<string>> Partition(string s)
	{
		Backtrack(s, 0);
		return this.result;
	}
	
	private void Backtrack(string s, int l)
	{
		if (l>=s.Length && this.currnet.Count > 0)
		{
			this.result.Add(new List<string>(this.current));
			return;
		}
		
		for (int i=l; i<s.Length; i++)
		{
			if (IsPalindrome(s, l, i))
			{
				if (i==l)
					this.current.Add(s[l].ToString());
				else
					this.current.Add(s.Substring(l, i+1-l));
				
				Backtrack(s, i+1);
				this.current.Remove(this.current.Count - 1);
			}
		}
	}
	
	private bool IsPalindrome(string s, int l, int r)
	{
		while (l<r)
		{
			if (s[l] != s[r])
				return false;
				
			l++;
			r--;
		}
		
		return true;
	}
}