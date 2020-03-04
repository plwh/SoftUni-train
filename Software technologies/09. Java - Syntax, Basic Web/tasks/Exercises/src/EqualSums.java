import java.util.Scanner;

public class EqualSums {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] arr = scan.nextLine().trim().split("\\s");

        int leftSum = 0;
        int rightSum = 0;
        int index = -1;

        for (int i = 0; i < arr.length; i++)
        {

            //calc left sum
            for (int j = i; j > 0; j--)
            {
                leftSum += Integer.parseInt(arr[j - 1]);
            }

            //calc right sum
            for (int k = i; k < arr.length-1; k++)
            {
                rightSum += Integer.parseInt(arr[k + 1]);
            }


            //check if sums are equal
            if (leftSum == rightSum) index = i;

            // change sums value to the default one
            leftSum = 0;
            rightSum = 0;
        }

        System.out.println((index != -1) ? String.valueOf(index) : "no");
    }
}
