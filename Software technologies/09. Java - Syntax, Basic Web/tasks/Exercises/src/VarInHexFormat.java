import java.util.Scanner;

public class VarInHexFormat{
    public static void main(String[] args){
        Scanner scan = new Scanner(System.in);

        String number = scan.next();
        System.out.println(Integer.parseInt(number,16));
    }
}