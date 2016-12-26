void Main()
{
	
}

// Define other methods and classes here
public int[] GetModifiedArray(int length, int[] updates)
{
	int n = updates.GetUpperBound(0);
	
	if(length == 0 || n == 0)
		return new int[0];
		
	int[] arr = new int[length];
	
	for (int i=0; i<=n; i++)
	{
		int start = updates[i,0];
		int end = updates[i,1];
		int val = updates[i,2];
		
		arr[start] += val;
		
		if (end+1 < length)
			arr[end+1] -= val;
	}
	
	for (int i=1; i<length; i++)
		arr[i] += arr[i-1];
		
	return arr;
}