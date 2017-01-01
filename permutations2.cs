/*
Given a collection of numbers that might contain duplicates, return all possible unique permutations.

For example,
[1,1,2] have the following unique permutations:
[
  [1,1,2],
  [1,2,1],
  [2,1,1]
]
*/

public class Solution
{
    private IList<IList<int>> result = new List<IList<int>>();
    
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        int n = nums.Length;
        Array.Sort(nums);
        Backtrack(new List<int>(), nums, new bool[n]);
        return this.result;
    }
    
    private void Backtrack(List<int> current, int[] nums, bool[] used)
    {
        if (current.Count == nums.Length)
        {
            this.result.Add(new List<int>(current));
            return;
        }
        
        for (int i=0; i<nums.Length; i++)
        {
            if (used[i] || (i>0 && nums[i] == nums[i-1] && !used[i-1]))
                continue;
            
            used[i] = true;
            current.Add(nums[i]);
            Backtrack(current, nums, used);
            used[i] = false;
            current.RemoveAt(current.Count - 1);
        }
    }
}