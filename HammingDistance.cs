public class Solution {
    public int HammingDistance(int x, int y) {
        return HammingWeight(x ^ y);
    }
    
    private int HammingWeight(int n)
    {
        int count = 0;
        while(n!=0)
        {
            n = n & n-1;
            count++;
        }
        
        return count;
    }
}