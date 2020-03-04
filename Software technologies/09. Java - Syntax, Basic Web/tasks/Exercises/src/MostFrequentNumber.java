import java.sql.Array;
import java.util.Arrays;
import java.util.Scanner;

public class MostFrequentNumber {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] arr = scan.nextLine().trim().split("\\s");
        Arrays.sort(arr);

        int currIndex = 0;
        int currLength = 0;
        int bestLength = 0;
        int bestElement = 0;
        for (int i = 0; i < arr.length; i++)
        {
            if (arr[i].equals(arr[currIndex]))
            {
                currLength++;
            }
            else
            {
                currIndex = i;
                currLength = 1;
            }
            if (currLength > bestLength)
            {
                bestLength = currLength;
                bestElement = Integer.parseInt(arr[i]);
            }
        }
        System.out.print(String.format("%1$d",bestElement));
    }
}
