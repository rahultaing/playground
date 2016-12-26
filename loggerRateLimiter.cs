void Main()
{
	
}

public class Solution
{
	
	private Dictionary<string, int> map = new Dictionary<string, int>();
	
// Define other methods and classes here
 bool shouldPrintMessage(int timestamp, string message) 
 {
 	if (map.ContainsKey(message))
	{
		if (timestamp < map[message])
			return false;
		else
		{
			map[message] = timestamp+10;
			return true;
		}
	}
	else
	{
		map[message] = timestamp+10;
		return true;
	}
 }
 
}