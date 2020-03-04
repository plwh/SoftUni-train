import java.util.Scanner;

public class FitString20Chars {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line = scan.nextLine();

        if(line.length() < 20){
            int difference = 20 - line.length();

            for(int i= 0; i < difference; i++){
                line+="*";
            }
        } else {
            line = line.substring(0,20);
        }

        System.out.print(line);
    }

}
