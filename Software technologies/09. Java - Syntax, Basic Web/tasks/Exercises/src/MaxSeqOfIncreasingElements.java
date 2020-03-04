import java.util.Scanner;

public class MaxSeqOfIncreasingElements {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] arr = scan.nextLine().trim().split("\\s");

        int maxstart = 0;
        int max = 1;
        int start = 0;
        for (int i = 1; i < arr.length; i++)
        {
            if (arr[i].charAt(0) > arr[i - 1].charAt(0))
            {
                if (i - start + 1 > max)
                {
                    max = i - start + 1;
                    maxstart = start;
                }
            }
            else
            {
                start = i;
            }
        }

        for (int i = 0; i < max; i++)
        {
            System.out.print(arr[maxstart + i] + " ");
        }
    }
}
