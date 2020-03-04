import java.util.Scanner;

public class VowelOrDigit {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        char input = scan.next().charAt(0);

        if(Character.isDigit(input)){
            System.out.println("digit");
        } else {
            switch(Character.toLowerCase(input)){
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    System.out.print("vowel");
                    break;
                default:
                    System.out.println("other");
                    break;
            }
        }
    }
}
