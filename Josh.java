public class Josh {
    private int id;
    private double gpa;

    Josh(int id, double gpa) {
        this.id = id;
        this.gpa = gpa;
    }

    Josh() {
        this(999,0.0);
    }

    public void display() {
        System.out.println("Student ID: " + id + ", GPA: " + gpa);
    }

    public static void main(String[] args) {
        Josh j1 = new Josh(202404957,1.00);
        
        j1.display();
    }
}

// Activity Task 3

// Reflective Questions:

// 1. What role does the this key word play inside constructors?
/* Answer:
 *  The mainly use of this keyword is to differentiate between instance variables
 *  and parameters with the same name and also call 
 *  another constructor in the same class
 */

 // 2. How does constructor overloading improve program design?
 /* Answer:
  * Constructor overloading improves program design by allowing objects to be 
    created in different ways with different initial data, making code more flexible, 
    readable, and easier to maintain.
  */

  // 3. When should you prefer default constructors over parameterized ones?
  /* Answer:
   * Use parameterized constructors when the object must be initialized with 
   * specific data at creation time.
   */