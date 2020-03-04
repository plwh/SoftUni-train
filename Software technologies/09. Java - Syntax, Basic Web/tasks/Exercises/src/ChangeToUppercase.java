import java.util.Scanner;

public class ChangeToUppercase {
    public static void main(String [] args){
        Scanner scan = new Scanner(System.in);

        String input = scan.nextLine();
        String openingTag = "<upcase>";
        String closingTag = "</upcase>";
        String strToReplace = "";
        int startIndex = 0;
        int endIndex = 0;

        while(input.indexOf(openingTag) != -1){
            startIndex = input.indexOf(openingTag)+ openingTag.length();
            endIndex = input.indexOf(closingTag);

            strToReplace = input.substring(startIndex,endIndex);
            input = input.replaceFirst("<upcase>","").replaceFirst("</upcase>",""); // remove tags
            input = input.replaceFirst(strToReplace, strToReplace.toUpperCase()); // replace string with uppercase
        }

        System.out.print(input);
    }
}
