/*
Find the kth largest element in an unsorted array. Note that it is the kth largest element in the sorted order, not the kth distinct element.

For example,
Given [3,2,1,5,6,4] and k = 2, return 5.
*/

public class Solution 
{
    public int FindKthLargest(int[] nums, int k) 
    {
        if (nums == null || nums.Length == 0) return Int32.MaxValue;
            return findKthLargest(nums, 0, nums.Length - 1, nums.Length - k);
    }

    public int findKthLargest(int[] nums, int start, int end, int k)
    {
        // quick select: kth smallest
	    if (start > end)
	        return Int32.MaxValue;
	
	    int pivot = nums[end];// Take A[end] as the pivot, 
	    int left = start;
	    for (int i = start; i < end; i++) 
	    {
		    if (nums[i] <= pivot) // Put numbers < pivot to pivot's left
			    swap(nums, left++, i);			
	    }
	    
	    swap(nums, left, end);// Finally, swap A[end] with A[left]
	
	    if (left == k)// Found kth smallest number
		    return nums[left];
	    else if (left < k)// Check right part
		    return findKthLargest(nums, left + 1, end, k);
	    else // Check left part
		    return findKthLargest(nums, start, left - 1, k);
    } 

    void swap(int[] A, int i, int j) 
    {
	    int tmp = A[i];
	    A[i] = A[j];
	    A[j] = tmp;				
    }
}