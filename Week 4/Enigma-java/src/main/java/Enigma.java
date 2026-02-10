/// Filename: Enigma.java
// / Author: Dr. Shane Wilson
/// Description: Add a useful description of this file

import java.util.List;

public final class Enigma {

    public static String Encrypt(String message, int incrementNumber,List<String> rotors ){
        // TODO - Implement the Encrypt method
        // Steps in brief
        // 1. Apply the CAESAR shift using the increment number
        // 2. For each rotor in the list rotors
        //  2.1 Translate the message using the rotor
        // 3. Return the encrypted string

        return "Implement the encrypt method";
    }


    public static String Decrypt(String message, int incrementNumber, List<String> rotors)
    {
        // TODO - Implement the Decrypt method

        // Steps in brief
        // 1. For each rotor in the list rotors, starting with the last rotor
        //  1.1 Translate the message using the rotor
        
        // 2. Apply the CAESAR shift
        // 3. Return the decrypted string     
        
        for(int i = rotors.size() - 1; i >= 0 ; i--)
        {
            //string rotor = rotors.get(i);
            System.out.println(rotors.get(i));

            /*
            1. Take each character in the message
            2. Find out where it appears in the rotor
            3. Get the corresonding value in A..Z 
            4. Add that new character to the output string
        
        
        */

        }

        return "Implement the decrypt";

    }
}
