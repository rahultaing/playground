class Solution {
    public String minWindow(String s, String t) {
     HashMap<Character,Integer> m = new HashMap<>();

        for (Character c: t.toCharArray()) {
            if (m.containsKey(c)){
                m.put(c, m.get(c)+1);
            }else{
                m.put(c,1);
            }
        }

        Integer count=t.length(), start=0, end=0, minStart=0, minLen = Integer.MAX_VALUE;
        Integer size = s.length();
        char[] s1 = s.toCharArray();

        while(end < size){
            if (m.containsKey(s1[end])){
                if (m.get(s1[end]) > 0){
                    count--;
                }
            }

            if (m.containsKey(s1[end])){
                m.put(s1[end], m.get(s1[end]) -1);
            }

            end++;

            while(count==0){

                if (minLen > end-start){
                    minLen = end-start;
                    minStart = start;
                }

                if (m.containsKey(s1[start])) {
                    m.put(s1[start], m.get(s1[start])+1);
                }
                
                if (m.containsKey(s1[start])) {
                    if (m.get(s1[start]) > 0) {
                        count++;
                    }
                }

                start++;
            }
        }

        return minLen==Integer.MAX_VALUE ? "" : s.substring(minStart, minStart+minLen);
    
    }
}