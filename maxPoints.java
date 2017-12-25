class Point {
      int x;
      int y;
      Point() { x = 0; y = 0; }
      Point(int a, int b) { x = a; y = b; }
  }
 
class Solution {
    public int maxPoints(Point[] points) {
 		
 		if (points.length < 2)
 			return points.length;

 		int result=0;

 		Map<Integer, Map<Integer, Integer>> map = new HashMap<>();

 		for (int i=0; i<points.length; i++){
 			map.clear();
 			int overlap=0;
 			int max=0;
 			for (int j=i+1; j<points.length; j++){

 				int x = points[i].x-points[j].x;
 				int y = points[i].y-points[j].y;

 				if (x==0 && y==0){
 					overlap++;
 					continue;
 				}

 				int gcd = generateGCD(x,y);

 				if (gcd != 0){
 					x=x/gcd;
 					y=y/gcd;
 				}

 				if (map.containsKey(x)){
 					if (map.get(x).containsKey(y)){
 						map.get(x).put(y, map.get(x).get(y)+1);
 					}
 					else{
 						map.get(x).put(y, 1);	
 					}
 				}
 				else{
 					Map<Integer, Integer> m2 = new HashMap<>();
 					m2.put(y,1);
 					map.put(x,m2);
 				}

 				max = Math.max(max, map.get(x).get(y));
 			}

 			result = Math.max(result, max);
 		}
 		return result;       
    }

    private int generateGCD(int a, int b){

    	if (b==0) return a;
    	return generateGCD(b, a%b);
    }
}