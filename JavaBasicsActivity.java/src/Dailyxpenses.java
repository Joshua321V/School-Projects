import java.util.ArrayList;
import java.util.Scanner;

public class Dailyxpenses {
    public static void main(String[] args) {
        Scanner amount = new Scanner(System.in);
        ArrayList<Double> expenses = new ArrayList<>();

        System.out.println("=============(Daily Expenses)====================");
        
        System.out.println("Enter your daily expenses. Then type 'done' if finish.");
        
        while (true) {
            System.out.print("Enter Your exepenses amount: ");
            String input = amount.nextLine();
            
            if (input.equalsIgnoreCase("done")) {
                break;
            }
            
            try {
                double expense = Double.parseDouble(input);
                if (expense < 0) {
                    System.out.println("Expense cannot be negative. Can you try again.");
                    continue;
                }
                expenses.add(expense);
            } catch (NumberFormatException e) {
                System.out.println("Invalid input. Please enter a valid number or 'done'.");
            }
        }
        
        double total = 0;
        for (double expense : expenses) {
            total += expense;
        }
        
        System.out.printf("Total daily expenses: Pesos %.2f\n", total);
        System.out.println("================================================");
        
        amount.close();
    }
}
