import java.util.Scanner;

public class URLParser {
    public static void main(String [] args) {
        Scanner scan = new Scanner(System.in);

        String input = scan.next();
        String protocol = "";
        String server = "";
        String resource = "";

        if(input.contains("://")){
            protocol = input.substring(0,input.indexOf("://"));
            if(input.indexOf('/',8) != -1){
                server = input.substring(input.indexOf("://")+3,input.indexOf('/',8));
                if(input.indexOf('/',input.indexOf(protocol))!= -1){
                        resource = input.substring(input.indexOf(server) + server.length(), input.length());
                        if(input.indexOf('/',input.indexOf(resource)+1) == -1){
                            resource = resource.substring(1,resource.length());
                    }
                }
            } else {
                server = input.substring(input.indexOf("://")+3,input.length());
            }
        }
        else {
            server = input;
        }

        System.out.println("[protocol] = "+"\""+protocol+"\"");
        System.out.println("[server] = "+"\""+ server + "\"");
        System.out.println("[resource] = "+"\""+resource+"\"");
    }
}
