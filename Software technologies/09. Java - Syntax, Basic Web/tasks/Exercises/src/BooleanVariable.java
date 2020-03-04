import java.util.Scanner;

public class BooleanVariable {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String input = scan.next();
        Boolean boolVar = Boolean.valueOf(input);

        System.out.println((boolVar)?"Yes":"No");
    }
}
