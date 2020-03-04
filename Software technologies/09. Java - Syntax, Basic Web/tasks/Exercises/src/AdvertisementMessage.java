import java.util.Random;
import java.util.Scanner;

public class AdvertisementMessage {
    public static void main(String [] args){

        Scanner scan = new Scanner(System.in);

        String[] p = new String[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
        String[] e = new String[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"};
        String[] a = new String[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
        String[] t = new String[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

        int numberOfMessages = Integer.parseInt(scan.next());

        Random rand = new Random();

        for (int i = 0; i < numberOfMessages; i++)
        {
            System.out.println(p[rand.nextInt(p.length)] + " " + e[rand.nextInt(e.length)] + " " + a[rand.nextInt(a.length)] + " - " + t[rand.nextInt(t.length)]);
        }
    }
}
