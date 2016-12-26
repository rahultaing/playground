void Main()
{
	
}

// Define other methods and classes here
public void GameOfLife(int[,] board)
{
	int n = board.GetUpperBound(0);
	int m = board.GetUpperBound(1);
	
	for (int i=0; i<=n; i++)
	{
		for (int j=0; j<=m; j++)
		{
			int lives = GetLives(board, n, m, i, j);
			
			if (board[i,j] == 1 && lives>=2 && lives <=3)
				board[i,j] = 3;
			
			if (board[i,j] == 0 && lives == 3)
				board[i,j] = 2;
		}
	}
	
	for (int i=0; i<=n; i++)
		for (int j=0; j<=m; j++)
			board[i,j] >>=1;
}


private int GetLives(int[,] board, int n, int m, int i, int j)
{
	int lives = 0;
	for (int x = i-1; x>=0 && x<=i+1 && x<=n; x++)
		for (int y=j-1; y>=0 && y<=m && y<=j+1; j++)
			lives += board[x,y] & 1;
			
	lives -= board[i,j] & 1;
	
	return lives;
}
