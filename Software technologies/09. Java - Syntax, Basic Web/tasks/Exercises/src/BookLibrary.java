import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;

public class BookLibrary {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        Library library = new Library("MyLibrary", new ArrayList<Book>());
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
            Book bookToAdd = new Book(title, author, publisher, releaseDate, isbn, price);
            library.getBooks().add(bookToAdd);
        }

        PrintSortedBooks(library);
    }

    private static void PrintSortedBooks(Library library) {
        HashMap<String, Double> authorAndPrice = new HashMap<String, Double>();

        for(Book book : library.getBooks()){
            String currAuthor = book.getAuthor();
            if(!authorAndPrice.containsKey(currAuthor)){
                authorAndPrice.put(currAuthor,book.getPrice());
                continue;
            }

            authorAndPrice.put(currAuthor, authorAndPrice.get(currAuthor)+ book.getPrice());
        }

        Map<String, Double> sortedAuthorAndPrice = new LinkedHashMap<>();
        authorAndPrice.entrySet().stream()
                .sorted(Map.Entry.<String,Double>comparingByValue().reversed())
                .forEachOrdered(x-> sortedAuthorAndPrice.put(x.getKey(),x.getValue()));

        sortedAuthorAndPrice.forEach((key,val) -> System.out.printf("%s -> %1.2f\n",key,val));
    }

    static class Library {
        private String Name;
        private ArrayList<Book> Books;

        public Library(String name, ArrayList<Book> books) {
            Name = name;
            Books = books;
        }

        public String getName() {
            return Name;
        }

        public void setName(String name) {
            Name = name;
        }

        public ArrayList<Book> getBooks() {
            return Books;
        }

        public void setBooks(ArrayList<Book> books) {
            Books = books;
        }
    }

    static class Book {
        private String Title;
        private String Author;
        private String Publisher;
        private Calendar ReleaseDate;
        private String ISBN;
        private double Price;

        public Book(String title, String author, String publisher, Calendar releaseDate, String isbn, double price) {
            Title = title;
            Author = author;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            ISBN = isbn;
            Price = price;
        }

        public String getTitle() {
            return Title;
        }

        public void setTitle(String title) {
            Title = title;
        }

        public String getAuthor() {
            return Author;
        }

        public void setAuthor(String author) {
            Author = author;
        }

        public String getPublisher() {
            return Publisher;
        }

        public void setPublisher(String publisher) {
            Publisher = publisher;
        }

        public Calendar getReleaseDate() {
            return ReleaseDate;
        }

        public void setReleaseDate(Calendar releaseDate) {
            ReleaseDate = releaseDate;
        }

        public String getISBN() {
            return ISBN;
        }

        public void setISBN(String isbn) {
            ISBN = isbn;
        }

        public double getPrice() {
            return Price;
        }

        public void setPrice(double price) {
            Price = price;
        }
    }
}

