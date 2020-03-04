import java.util.Arrays;
import java.util.Scanner;

public class IndexOfLetters {
    public static void main(String[] args){
        Scanner scan = new Scanner(System.in);
        String input = scan.next();

        String[] alphabet = new String[]
                {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};

        for (char c : input.toCharArray()) {
            String letter = String.valueOf(c);

            if (Arrays.asList(alphabet).contains(letter)){
                System.out.println(String.format("%1$c -> %2$d",c,Arrays.asList(alphabet).indexOf(letter)));
            }
        }
    }
}
