namespace P04_BubbleSort
{
    public class Bubble
    {
        public Bubble(int[] data)
        {
            this.Data = data;
        }

        public int[] Data { get; private set; }

        public void Sort()
        {
            for (int i = this.Data.Length - 1; i >= 0; i--)
            {
                for (int j = 1; j < this.Data.Length; j++)
                {
                    if (this.Data[j - 1] > this.Data[j])
                    {
                        int temp = this.Data[j - 1];
                        this.Data[j - 1] = this.Data[j];
                        this.Data[j] = temp;
                    }
                }
            }
        }
    }
}
