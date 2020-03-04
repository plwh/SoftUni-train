import java.util.Scanner;

public class CompareCharArrays {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] arr1 = scan.nextLine().trim().split("\\s");
        String[] arr2 = scan.nextLine().trim().split("\\s");

        if (arr1.length == arr2.length)
        {
            if (arr1[0].charAt(0) < arr2[0].charAt(0))
            {
                PrintArray(arr1);
                PrintArray(arr2);
            }
            else
            {
                PrintArray(arr2);
                PrintArray(arr1);
            }
        }
        else if (arr1.length < arr2.length)
        {
            PrintArray(arr1);
            PrintArray(arr2);
        }
        else
        {
            PrintArray(arr2);
            PrintArray(arr1);
        }
    }

    public static void PrintArray(String[] arr) {
        for (int i = 0; i < arr.length; i++) {
            System.out.print(arr[i]);
        }

        System.out.println();
    }
}
