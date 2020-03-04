import java.util.Scanner;

public class ReverseString {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.next();
        String result = "";

        for(int i=0; i<input.length();i++){
            result = input.charAt(i) + result;
        }

        System.out.print(result);
    }
}
