import java.util.Scanner;

public class MaxSeqOfEqualElements {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] arr = scan.nextLine().trim().split("\\s");

        int currLength = 0;
        int bestLength = 0;
        int bestElement = 0;

        for (int i = 0; i < arr.length-1; i++)
        {
            if (arr[i].equals(arr[i+1]))
            {
                currLength++;
            }
            else
            {
                currLength = 0;
            }

            if (currLength > bestLength)
            {
                bestLength = currLength;
                bestElement = Integer.parseInt(arr[i]);
            }
        }

        for (int j = 0; j <= bestLength; j++)
        {
            System.out.print(bestElement + " ");
        }
    }
}
