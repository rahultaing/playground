public class Solution {
    public IList<IList<string>> SolveNQueens(int n) {
     
		if (n == 0)
			return new List<IList<string>>();
			
		int[] A = new int[n];
		var outerList = NQueen(A, 0, n, new List<IList<string>>());
		
		
    	foreach (List<string> list in outerList)
    	{
    		foreach (string s in list)
    			Console.WriteLine("s - {0}", s);
    	}
    	
		return outerList;
    }
	
private IList<IList<string>> NQueen(int[] A, int k, int n, IList<IList<string>> outerList)
{
	//IList<IList<string>> outerList = new List<IList<string>>();
	
	if (k == n)
	{
		IList<string> innerList = new List<string>();
		for (int i = 0; i < n; i++)
		{
			string s1 = string.Empty;
			
			// print board
			for (int j=0; j<n; j++)
			{
				if (A[i] == j)
				{
					//Console.Write("Q ");
					s1+="Q";
				}
				else
				{
					//Console.Write(". ");
					s1+=".";
				}
			}
			
			innerList.Add(s1);
			
			Console.WriteLine();
		}
		
		Console.WriteLine();
		Console.WriteLine();
		outerList.Add(innerList);
	}
	else
	{		
		for (int i=0; i < n; i++)
		{
			if (canPlace(A, k, i))
			{
				A[k] = i;		
				outerList = NQueen(A, k+1, n, outerList);
			}
		}
	}

	return outerList;
}

private bool canPlace(int[] A, int k, int i)
{
	for (int j=0; j<k; j++)
	{
		if (A[j] == i || Math.Abs(k-j) == Math.Abs(A[j] -i))
			return false;
	}
	
	return true;
}
}