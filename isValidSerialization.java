class Solution {
    public boolean isValidSerialization(String preorder) {
    	if (preorder == null){
    		return false;
    	}

        Stack<String> stack = new Stack<>();
        String[] sa = preorder.split(",");

        for (int i = 0; i < sa.length; i++){
        	String cur = sa[i];
        	while (cur.equals("#") && !stack.isEmpty() && stack.peek().equals("#")){

        		stack.pop();
        		if (stack.isEmpty()){
        			return false;
        		}

        		stack.pop();
        	}

        	stack.push(sa[i]);
        }

        return stack.size() == 1 && stack.peek().equals("#");
    }
}