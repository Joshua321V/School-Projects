import java.util.Scanner;

public class StudentInfo {

    static class Student {
        private String name;
        private int age;
        private String course;
        private String year;
        private String id;

        public Student(String name, int age, String course, String year, String id) {
            this.name = name;
            this.age = age;
            this.course = course;
            this.year = year;
            this.id = id;
        }

        public void displayInfo() {
            System.out.println("Student Name: " + name);
            System.out.println("Age: " + age);
            System.out.println("Course: " + course);
            System.out.println("Year Level: " + year);
            System.out.println("Student ID: " + id);
            System.out.println("-----------------------");
        }
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter number of students: ");
        int numberOfStudents = scanner.nextInt();
        scanner.nextLine();

        Student[] students = new Student[numberOfStudents];

        for (int i = 0; i < numberOfStudents; i++) {
            System.out.println("Enter details for student " + (i + 1) + ":");

            System.out.print("Name: ");
            String name = scanner.nextLine();

            System.out.print("Age: ");
            int age = scanner.nextInt();
            scanner.nextLine();

            System.out.print("Course: ");
            String course = scanner.nextLine();

            System.out.print("Year Level: ");
            String year = scanner.nextLine();

            System.out.print("Student ID: ");
            String id = scanner.nextLine();

            students[i] = new Student(name, age, course, year, id);
        }

        System.out.println("----------------------");
        System.out.println("Student Information:");
        System.out.println("----------------------");
        for (Student student : students) {
            student.displayInfo();
        }

        scanner.close();
    }
    }
}
