void Main()
{
	
}

// Define other methods and classes here
public class MovingAverage
{
	private int[] window;
	private int insert;
	private int n;
	private long sum;
	
	public void MovingAverage(int size)
	{
		window = new int[size];
		this.n = 0;
		this.insert = 0;
		this.sum = 0;
	}
	
	public double next(long val)
	{
		if (this.n < this.window.Length)
			this.n++;
			
		this.sum -= this.window[insert];
		this.sum += val;
		this.window[insert] = val;
		this.insert = (this.insert+1)% this.window.Length;
		return (double) this.sum/this.n;
	}
}