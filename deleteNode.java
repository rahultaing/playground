public class TreeNode {
      int val;
      TreeNode left;
      TreeNode right;
      TreeNode(int x) { val = x; }
  }
 
 class Solution {
    public TreeNode deleteNode(TreeNode root, int key) {
 		
 		if (root == null)
 			return null;

 		if (root.val < key){

 			root.right = deleteNode(root.right, key);
		}

		else if (root.val > key){
			root.left = deleteNode(root.left, key);
		}

		else if (root.val == key){
			if (root.left == null) return root.right;
			if (root.right == null) return root.left;

			TreeNode t = root;
			root = findMin(t.right);
			root.right = deleteMin(t.right);
			root.left = t.left;
		}

		return root;
    }

	private TreeNode findMin(TreeNode root){

		if (root.left == null) return root;

		return findMin(root.left);
	}

    private TreeNode deleteMin(TreeNode root){

    	if (root.left == null)
    		return root.right;

    	root.left = deleteMin(root.left);

    	return root;
    }
}