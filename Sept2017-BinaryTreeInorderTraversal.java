/*
Step 1: Initialize current as root
Step 2: While current is not NULL,
If current does not have left child
a. Add current’s value
b. Go to the right, i.e., current = current.right
Else
a. In current's left subtree, make current the right child of the rightmost node
b. Go to this left child, i.e., current = current.left
*/

public class TreeNode
  {
      int val;
      TreeNode left;
      TreeNode right;
      TreeNode(int x) { val = x; }
  }

// using recursion is simple
  // using morris traversal
    class Solution
    {
        public List<Integer> inorderTraversal(TreeNode root)
        {
            List<Integer> res = new ArrayList<>();
            TreeNode cur = root;

            while (cur != null)
            {
                if (cur.left == null)
                {
                    res.add(cur.val);
                    cur = cur.right;
                }
                else
                {
                    TreeNode prev = cur.left;

                    while (prev.right != null)
                    {
                        prev = prev.right;
                    }

                    prev.right = cur;

                    TreeNode temp = cur;
                    cur = cur.left;
                    temp.left = null;
                }
            }

            return res;
        }
    }
