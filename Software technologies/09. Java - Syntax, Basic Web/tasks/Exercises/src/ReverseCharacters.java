import java.util.Scanner;

public class ReverseCharacters {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String result = "";
        for(int i=0; i<3; i++) {
            String input = scan.next();
            result = input + result;
        }

        System.out.println(result);
    }
}
