import java.time.LocalTime;

public class StudentSchedule {
    public static void main(String[] args) {
        
        // Time
        LocalTime time1 = LocalTime.of(6,0);
        LocalTime time2 = LocalTime.of(7,30);
        LocalTime time3 = LocalTime.of(9,0);
        LocalTime time4 = LocalTime.of(12, 0);

        // Subjects 
        String subject1 = "OLCC03";
        String subject2 = "OLWS1";
        String subject3 = "OLCPPROG2";
        String subject4 = "OLPHYE004";
        String subject5 = "OLALTRI";
        String subject6 = "OLHUM001";


        System.out.println("====================================(My Schedule (Set A))===============================");
        System.out.println("Time ||  Monday || Tuesday || Wednesday || Thursday || Friday || Saturday || Sunday ||");
        System.out.println("----------------------------------------------------------------------------------------");
        System.out.println(time1 + "|| "+ subject1 + "  ||         ||  " + subject6 + " ||          ||" + "        || " + subject6 + " ||        ||");
        System.out.println(time2 + "|| "+ subject2 + "   ||         ||  " + subject5 + "  ||          ||" + "        || " + subject5 + "  ||        ||");
        System.out.println(time3 + "||"+ subject3 + "||         ||" + "           ||          ||" + "        ||          ||" + "        ||");
        System.out.println(time4 + "||"+ "         ||         || " + subject4 + " ||          ||" + "        ||" + "          ||        ||");
        System.out.println("========================================================================================");
    }
}
