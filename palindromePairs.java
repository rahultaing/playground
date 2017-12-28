class Solution {
     public List<List<Integer>> palindromePairs(String[] words) {

        List<List<Integer>> res = new ArrayList<>();
        HashMap<String, Integer> map = new HashMap<>();

        for (int i=0; i<words.length; i++){
            map.put(words[i], i);
        }

        for (int i=0; i<words.length; i++){
            for (int j=0; j<=words[i].length(); j++){
                String s1 = words[i].substring(0,j);
                String s2 = words[i].substring(j);

                addPair(map, s1, s2, res, i, false);

                if (s2.length()>0){
                    addPair(map, s2, s1, res, i, true);
                }
            }
        }

        return res;
    }

    private void addPair(HashMap<String, Integer> map, String s1, String s2,
                         List<List<Integer>> res, int index,
                         boolean isRev){

        if (isPalindrome(s1)){
            String s2Rev = new StringBuilder(s2).reverse().toString();
            if (map.containsKey(s2Rev) && map.get(s2Rev) != index){
                List<Integer> list = new ArrayList<>();

              if (!isRev){
                    list.add(map.get(s2Rev));
                    list.add(index);

                }
                else{
                    list.add(index);
                    list.add(map.get(s2Rev));
                }
    
                res.add(list);
            }
        }
    }

    private boolean isPalindrome(String s){
        int l = 0, r = s.length()-1;

        while (l<=r){
            if (s.charAt(l++) != s.charAt(r--)) return false;
        }

        return true;
    }
}