<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
 public int FindNthDigit(int n) 
 {
 	int len = 1;
 	int count = 9;
 	int start = 10;
	
	while (n > len*count)
	{
		n -= len*count;
		len += 1;
		count *= 10;
		start *= 10;
	}
	
	start += (n-1)/len;
	string s = Convert.ToString(start);
	return Convert.ToInt32(s[(n-1)%len];
 }