public class ScopeDemo {
    public static void main(String[] args) {
        int outVariable = 15;
        System.out.println("OUTPUT:");
        System.out.println("Outer Variable: " + outVariable);
        
        {
            int inVariable = 30;
            System.out.println("Inner Variable: " + inVariable);
            System.out.println("Outer Variable inside inner blocks: " + outVariable);
        }
    }
    
}

// Activity Task
// Reflective Questions:

// 1. What happens when you try to access a variable outside its scope?
// Answer: If I access a variable outside its scope, the program won't even run and get some errors

// 2. Why is proper variable scoping important in debugging programs?
// Answer: Because it limits where variables can be changed. It make trace errors easier.

// 3. How does scope prevent unintended data conflicts in large applications?
// Answer: Scope prevents unintended data conflicts in large applications by limiting variable visibility.
