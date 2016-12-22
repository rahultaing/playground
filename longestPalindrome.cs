void Main()
{
	
}

// Define other methods and classes here
public int LongestPalindrome(string s)
{
 	int n = s.Length;
	if (n==0)
		return 0;
		
	HashSet<char> set = new HashSet<char>();
	
	int i=0;
	int count = 0; 
	
	while (i<n)
	{
		if (set.Contains(s[i]))
		{
			set.Remove(s[i]);
			count++;
		}
		else
		{
			set.Add(s[i]);
		}
	}
	
	if (set.Count == 0)
		return count*2;
	else 
		return (count*2)+1;
}