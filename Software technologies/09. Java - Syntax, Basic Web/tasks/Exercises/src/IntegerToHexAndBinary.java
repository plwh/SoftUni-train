import java.util.Scanner;

public class IntegerToHexAndBinary {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int input = Integer.parseInt(scan.next());

        System.out.println(Integer.toHexString(input).toUpperCase());
        System.out.println(Integer.toBinaryString(input));
    }
}
