public class InterestCalculator {
    public static void calculation(double balance, double rate) {
        System.out.println("Interest: " + balance * rate);
    }

    public static void calculation(double balance, int rate) {
        System.out.println("Interest: " + balance * (rate / 100.0));
    }

    public static void main(String[] args) {
        calculation(140.6, 5);
        calculation(1400, 10);
    }
}

// Activity Task 2

// Reflective Questions:

// 1. How does Java decide which overloaded method to execute?
/* Answer:
 * Java decides which overloaded method to execute at compile time,
 * based on the method signature that best matches the arguments passed 
 * in the method call.
*/

 // 2. Why can overloaded methods sometimes lead to ambiguity?
/* Anser:
 * Overloaded methods can lead to ambiguity when the compiler cannot 
 * clearly decide which version of the method best matches the arguments, 
 * often due to type conversions, autoboxing, or equally valid matches.
 */

// 3. How can developers avoid ambiguous method overloading?
/* Answer:
 * Developers can avoid ambiguous method overloading by making method 
 * signatures clear and distinct—using different numbers of parameters, 
 * avoiding confusing type conversions, and not relying on both autoboxing and 
 * varargs in overloads.
 */

