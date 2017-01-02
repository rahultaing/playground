/*
Given a collection of integers that might contain duplicates, nums, return all possible subsets.

Note: The solution set must not contain duplicate subsets.

For example,
If nums = [1,2,2], a solution is:

[
  [2],
  [1],
  [1,2,2],
  [2,2],
  [1,2],
  []
]
*/

public class Solution 
{
    private List<IList<int>> outerList = new List<IList<int>>();    
    public IList<IList<int>> SubsetsWithDup(int[] nums) 
     {
     	if (nums.Length == 0)
    		return this.outerList;
    	Array.Sort(nums);
    	Backtrack(nums, new List<int>(),0);
    	
    	return this.outerList;
     }
 
    private void Backtrack(int[] nums, List<int> list, int start)
    {
        this.outerList.Add(new List<int>(list));
        for (int i=start; i<nums.Length; i++)
        {
            if (i > start && nums[i] == nums[i-1]) continue;
            
            list.Add(nums[i]);
            Backtrack(nums, list, i+1);
            list.RemoveAt(list.Count - 1);
        }
    }
}