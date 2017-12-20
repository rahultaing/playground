 public class TreeNode {
      int val;
      TreeNode left;
      TreeNode right;
      TreeNode(int x) { val = x; }
  }

class Solution {
	private Integer min = Integer.MAX_VALUE;

	/*inorder traversal*/
    public int getMinimumDifference(TreeNode root) 
    {
     	if (root == null)
     		return min;

     	getMinimumDifference(root.left);

     	if (prev != null)
     	{
     		min = Math.min(min, root.val - prev.val);
     	}

     	prev = root;
		getMinimumDifference(root.right);
		return min;     	
    }
}

class Solution {
	private Integer min = Integer.MAX_VALUE;
	private TreeSet<Integer> set = new TreeSet();

	/*
		treeset solution
		preorder traversal
	*/
    public int getMinimumDifference(TreeNode root) 
    {
     	if (root == null)
     		return min;

     	if (set.floor(root.val) != null)
     	{
     		min = Math.min(min, root.val - set.floor(root.val));	
     	}

     	if (set.ceiling(root.val) != null)
     	{
     		min = Math.min(min, set.ceiling(root.val) - root.val);	
     	}
     	
     	if (!set.contains(root.val))
     		set.add(root.val);

     	getMinimumDifference(root.left);
		getMinimumDifference(root.right);
		return min;     	
    }
}