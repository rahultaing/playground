/*
Given an unsorted integer array, find the first missing positive integer.

For example,
Given [1,2,0] return 3,
and [3,4,-1,1] return 2.

Your algorithm should run in O(n) time and uses constant space.
*/

public class Solution {
    public int FirstMissingPositive(int[] nums) {
    	int n=nums.Length;
	
	if (n==0)
		return 1;
		
	int i=0;
	
	while (i < n)
	{
		if (nums[i] == i+1 || nums[i] <=0 || nums[i] > n) i++;
		else if (nums[nums[i] - 1] != nums[i]) swap(nums, nums[i] - 1, i);
		else i++;
	}
	
	i=0;
	
	while (i<n && nums[i] == i+1)
	{	
		i++;
	}
	
	return i+1;
}

private void swap(int[] nums, int i, int j)
{
	int t = nums[i];
	nums[i] = nums[j];
	nums[j] = t;
}
}