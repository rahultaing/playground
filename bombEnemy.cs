
void Main()
{
	
}

// Define other methods and classes here
public int BombEnemy(char[,] grid)
{
  int n = grid.GetUpperBound(0);
	    int m = grid.GetUpperBound(1);
	
	    int result = 0;
	    int rowHits = 0;
	    int[] colHits = new int[m+1];
	
	for (int i=0; i<=n ; i++)
	{
		for (int j=0; j<=m; j++)
		{
			if (j==0 || grid[i,j-1] == 'W')
			{
				rowHits = 0;
				for (int k=j; k<=m && grid[i, k] != 'W'; k++)
				{
					if (grid[i,k] == 'E')
						rowHits += 1;
				}
			}
			
			if (i==0 || grid[i-1, j] == 'W')
			{
				colHits[j] = 0;
				for(int k=i; k<=n && grid[k, j] != 'W'; k++)
				{
					if (grid[k,j] == 'E')
						colHits[j] += 1;
				}
			}
			
			if (grid[i,j] == '0')
				result = Math.Max(result, rowHits + colHits[j]);
		}
	}
	
	return result;
}