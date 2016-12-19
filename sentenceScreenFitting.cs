

void Main()
{
	
}

// Define other methods and classes here
public int SentenceFitting(int[] sa, int rows, int cols)
{
	string s = string.Join(" ", sa) + " ";
	int start = 0;
	int n = s.Length;
	
	for (int i=0; i < rows; i++)
	{
		start+=cols;
		
		if (s[start % n] == ' ')
		{
			start++;
		}
		else
		{
			while (start > 0 && s[(start-1) % n] != ' ')
				start--;
		}
	}
	
	return start/n;
}