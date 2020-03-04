import java.util.Scanner;
import java.util.TreeMap;

public class Phonebook {
    public static void main(String [] args){
        Scanner scan = new Scanner(System.in);

        TreeMap<String,String> phonebook = new TreeMap<String, String>();

        while(true){
            String[] commands = scan.nextLine().trim().split("\\s");

            switch (commands[0])
            {

                case "A":
                    phonebook.put(commands[1], commands[2]);
                    break;
                case "S":
                    if (phonebook.containsKey(commands[1]))
                    {
                        System.out.println(commands[1] + " -> " + phonebook.get(commands[1]));
                    }
                    else
                    {
                        System.out.println(String.format("Contact %s does not exist.",commands[1]));
                    }
                    break;
                default:
                    return;
            }
        }
    }
}
