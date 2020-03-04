import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;

public class BookLibraryModification {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        BookLibrary.Library library = new BookLibrary.Library("MyLibrary", new ArrayList<BookLibrary.Book>());
        SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");
        int n = Integer.parseInt(scan.nextLine());

        for (int i = 0; i < n; i++) {
            String[] input = scan.nextLine().trim().split(" ");

            String title = input[0];
            String author = input[1];
            String publisher = input[2];
            Calendar releaseDate = Calendar.getInstance();
            try {
                releaseDate.setTime(dateFormat.parse(input[3]));
            } catch (ParseException e) {
                System.out.println("Invalid date. Please try again!");
                continue;
            }

            String isbn = input[4];
            double price = Double.parseDouble(input[5]);
            BookLibrary.Book bookToAdd = new BookLibrary.Book(title, author, publisher, releaseDate, isbn, price);
            library.getBooks().add(bookToAdd);
        }

        Calendar dateAfter = Calendar.getInstance();
        try {
            dateAfter.setTime(dateFormat.parse(scan.next()));
        } catch (ParseException e) {
            System.out.println("Invalid date. Please try again!");
        }

        PrintTitleAfterDate(library, dateAfter, dateFormat);
    }

    private static void PrintTitleAfterDate(BookLibrary.Library library, Calendar dateAfter, SimpleDateFormat dateFormat) {
        HashMap<String, Calendar> titleDate = new HashMap<String, Calendar>();

        for (BookLibrary.Book book : library.getBooks()) {
            if (book.getReleaseDate().compareTo(dateAfter) > 0) {
                titleDate.put(book.getTitle(), book.getReleaseDate());
            }
        }

        // Sorting by Date and then by Title lexicographically
        Map<String, Calendar> sortedTitlesByDate = new LinkedHashMap<>();
        titleDate.entrySet().stream()
                .sorted(Map.Entry.<String, Calendar>comparingByKey())
                .sorted(Map.Entry.<String, Calendar>comparingByValue())
                .forEachOrdered(b -> System.out.printf("%s -> %s\n", b.getKey(), dateFormat.format(b.getValue().getTime())));
    }
}
