
void Main()
{
	
}

// Define other methods and classes here
public bool IsStrobogrammatic(string num) 
{
	Dictionary<char, char> map = new Dictionary<char, char>();
	map['0'] = '0';
	map['1'] = '1';
	map['8'] = '8';
	map['6'] = '9';
	map['9'] = '6';
	
	int start = 0;
	int end = num.Length-1;
	while (start<end)
	{
		if (!map.CotainsKey(num[start]))
			return false;
			
		if (map[num[start]] != num[end])
			return false;
		else
		{
			start++;
			end--;
		}
	}
	
	return true;
}