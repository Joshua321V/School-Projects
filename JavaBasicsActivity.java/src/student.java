public class student {
    
    String name;
    int age;
    String course;

    void setDetails(String n, int a, String c) {
        name = n;
        age = a;
        course = c;
    }
    void dispalyInfo() {
        System.out.println("Name: " + name);
        System.out.println("Age: " + age);
        System.out.println("Course: " + course);
    }
}

