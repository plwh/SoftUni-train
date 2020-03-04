import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class BombNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] seq = scan.nextLine().trim().split("\\s");
        ArrayList<String> sequence = new ArrayList<String>(Arrays.asList(seq));
        String[] bombAndPower = scan.nextLine().trim().split("\\s");

        String bomb = bombAndPower[0];
        int power = Integer.parseInt(bombAndPower[1]);
        int sum = 0;

        while (sequence.indexOf(bomb) != -1)
        {
            // find bomb index
            int indexOfBomb = sequence.indexOf(bomb);

            // remove left neighbors
            for (int i = 1; i <= power; i++)
            {
                int currIndex = indexOfBomb - i;

                if (currIndex >= 0)
                {
                    sequence.remove(currIndex);
                }
                else
                {
                    break;
                }
            }

            // find bomb index after removing left neighbors
            indexOfBomb = sequence.indexOf(bomb);

            // remove right neighbors
            for (int i = 1; i <= power; i++)
            {
                int currIndex = indexOfBomb + 1;

                if (currIndex < sequence.size())
                {
                    sequence.remove(currIndex);
                }
                else
                {
                    break;
                }
            }

            // remove bomb
            sequence.remove(bomb);
        }

        for(String i : sequence) {
            sum += Integer.parseInt(i);
        }

        System.out.println(sum);
    }
}
