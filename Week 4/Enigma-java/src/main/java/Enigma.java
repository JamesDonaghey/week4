/// Filename: Enigma.java
// / Author: Dr. Shane Wilson
/// Description: Add a useful description of this file

import java.util.List;

public final class Enigma {

    public static String Encrypt(String message, int incrementNumber,List<String> rotors ){
    
    String result="";
    
    for(int i = 0; i < message.length(); i++)
    {
    char letter = message.charAt(i);
    
    int position = letter - 'A';
    position = position + incrementNumber;
      if(position > 25)
      {
      position = position - 26;
      }
      
      letter=(char)('A' + position);
      
        for(int q = 0; q < rotors.size(); q++)
        {
        String rotor = rotors.get(q);
        letter = rotor.charAt(letter - 'A');
        }
        result = result + letter;
    }
        return "Implement the encrypt method: " + result;
    }


    public static String Decrypt(String message, int incrementNumber, List<String> rotors)
    {
        // TODO - Implement the Decrypt method

        // Steps in brief
        // 1. For each rotor in the list rotors, starting with the last rotor
        //  1.1 Translate the message using the rotor
        // 2. Apply the CAESAR shift
        // 3. Return the decrypted string

        return "Implement the decrypt";

    }
}
