import java.util.Scanner;

public class JavaBasicsActivity {
    
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        
        // Data types and Variables
        int age = 21;
        double height = 167.64;
        String name = "Joshua V. Reburiano";
        boolean isStudent = true;

        System.out.println("Java Basic Demonstration:");
        System.out.println("Name: " + name + "|Age: " + age + "|Height: " + height + "|Student: " + isStudent);
        System.out.println("--------------------------");

        // Input and Operators
        System.out.print("Enter first integer:");
        int num1 = input.nextInt();
        System.out.print("Enter second integer: ");
        int num2 = input.nextInt();
        System.out.println("--------------------------");
        
        System.out.println( "Arithmetic Operations:");
        System.out.println("Addition: " + (num1 + num2));
        System.out.println("Subtraction: " + (num1 - num2));
        System.out.println("Multiplication: " + (num1 * num2));
        System.out.println("Division: " + (num1 / num2));
        System.out.println("Modulo: " + (num1 % num2));
        System.out.println("--------------------------");

        // Conditionals
        System.out.println("Comparison Result:");

        if (num1 > num2) {
            System.out.println(num1 + " is greater than " + num2);
        }
        else if (num1 < num2) {
            System.out.println(num1 + " is less than " + num2);
        }
        else {
            System.out.println(num1 + " is equal to " + num2);
        }
        System.out.println("--------------------------");

        // Loop
        System.out.println("Even Numbers from 1 to " + num1 + ":");

        for (int i = 1; i <+ num1; i++) {
            if (i % 2 == 0) {
                System.out.print(i + "");
            }
        }
        input.close();
    }
}
