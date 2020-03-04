import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class AverageGrades {
    public static void main(String [] args) {
        Scanner scan = new Scanner(System.in);
        ArrayList<Student> studentsInfo = new ArrayList<Student>();

        int numberOfStudents = Integer.parseInt(scan.nextLine());

        for(int i=0; i<numberOfStudents;i++) {
            String[] input = scan.nextLine().trim().split(" ");
            String studentName = input[0];
            ArrayList<Double> grades = new ArrayList<>();

            for(int j = 1; j<input.length;j++){
                grades.add(Double.parseDouble(input[j]));
            }

            studentsInfo.add(new Student(studentName,grades));
        }

        studentsInfo.stream()
                .filter(s -> s.getAverage() >= 5.00)
                .sorted((a, b) -> {

                    int result = a.getName().compareTo(b.getName());

                    if (result == 0) {
                        result = Double.compare(b.getAverage(), a.getAverage());
                    }

                    return result;
                })
                .forEach(s -> {
                    System.out.printf("%s -> %.2f%n", s.getName(), s.getAverage());
                });
    }
}

class Student {
    public Student(String name, ArrayList<Double> grades) {
        this.name = name;
        this.grades = grades;

        Double total = 0.0;
        for(Double grade : grades){
            total += grade;
        }
        this.average = total / grades.size();
    }

    public Student() {
    }

    public String getName() {
        return name;
    }

    public ArrayList<Double> getGrades() {
        return grades;
    }

    public Double getAverage() {
        return average;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setGrades(ArrayList<Double> grades) {
        this.grades = grades;
    }

    private String name;
    private ArrayList<Double> grades = new ArrayList<>();
    private Double average;
}