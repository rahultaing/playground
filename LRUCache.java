class LRUCache {

 class Node{
		private int val;
		private int key;
		private Node next;
		private Node prev;
		public Node(int key, int val){
			this.key = key;
			this.val = val;
		}
	}

	private HashMap<Integer, Node> map = new HashMap<>();
	private int count;
	private int capacity;
	private Node head;
	private Node tail;

    public LRUCache(int capacity) {
    
    	this.count = 0;
    	this.capacity = capacity;
    	this.head = new Node(0,0);
    	this.tail = new Node(0,0);
    	this.head.next = this.tail;
    	this.tail.prev = this.head;
    }
    
    private void deleteNode(Node node){
    	node.next.prev = node.prev;
    	node.prev.next = node.next;
    }

    private void addToHead(Node node){
    	node.next = this.head.next;
    	node.prev = this.head;
    	this.head.next.prev = node;
    	this.head.next = node;
    }

    public int get(int key) {
        
        if (map.containsKey(key)){

        	Node node = map.get(key);
        	int v = node.val;
        	this.deleteNode(node);
        	this.addToHead(node);
        	return v;
        }

        return -1;
    }
    
    public void put(int key, int value) {
        if (map.containsKey(key)){
        	Node node = map.get(key);
        	node.val = value;
        	this.deleteNode(node);
        	this.addToHead(node);
        }
        else{
        	Node node = new Node(key, value);
        	map.put(key, node);
        	if (this.count>=this.capacity){
        		map.remove(this.tail.prev.key);
        		this.deleteNode(this.tail.prev);
        		this.addToHead(node);
        	}
        	else{
        		this.addToHead(node);
        		this.count++;
        	}
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.get(key);
 * obj.put(key,value);
 */