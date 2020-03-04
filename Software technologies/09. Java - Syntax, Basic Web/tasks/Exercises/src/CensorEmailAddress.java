import java.util.Scanner;

public class CensorEmailAddress {
    public static void main(String [] args) {
        Scanner scan = new Scanner(System.in);

        String strToReplace = scan.nextLine();
        String text = scan.nextLine();

        String replacementString = "";

        for(int i= 0; i<strToReplace.length();i++){
            if(strToReplace.charAt(i) == '@'){
                replacementString += strToReplace.substring(strToReplace.indexOf('@'),strToReplace.length());
                break;
            } else {
                replacementString += '*';
            }
        }

        text = text.replaceAll(strToReplace,replacementString);

        System.out.print(text);
    }
}
