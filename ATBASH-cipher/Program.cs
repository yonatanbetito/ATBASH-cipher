namespace ATBASH_cipher;

internal class Program
{
    /// <summary>
    /// Detecting dengerous words in the input message, and calculates the number of threat points.
    /// </summary>
    /// <param name="input">The decrypted input message.</param>
    /// <returns>The number of threat points.</returns>
    static int DetectDangerousWords(string input)
    {
        string[] dengerousWords = ["bomb", "nukhba", "fighter", "rocket", "secret"];
        string[] stringToWords = input.Split([' ', '\n', '\r'], StringSplitOptions.RemoveEmptyEntries);
        int conterWords = 0;
        List<string> WordsAppearing = [];
        
        foreach (string word in stringToWords)
        {
            // Checking if dangerous words apearing in the message,
            // also in uppercase letters or in plural form.
            if (dengerousWords.Contains(word.ToLower()) || dengerousWords.Contains(word[..^1].ToLower()))
            {
                conterWords += 1;
                if (!WordsAppearing.Contains(word))
                    WordsAppearing.Add(word);
            }
        }

        
        System.Console.WriteLine($"Words Appearing: {string.Join(", ", WordsAppearing)}");
        System.Console.WriteLine($"Number of Points: {conterWords}");
        return conterWords;
    }

    /// <summary>
    /// Summering the analysis on the input to a string of status report.
    /// Adding warning according to the sum of the threat point.
    /// </summary>
    /// <param name="decryptedInput">The decrypted input string.</param>
    /// <param name="points">Number of threat points detected.</param>
    /// <returns>The status report.</returns>
    static string ReportStatus(string decryptedInput, int points)
    {
        string warningLevel = points switch
        {
            > 0 and <= 5 => "WARNING",
            > 5 and <= 10 => "DANGER!",
            > 10 and <= 15 => "ULTRA ALERT!",
            _ => "NO THREAT DETECTED",
        };
        return $"\nStatus report:\n\n- Decrypted message:\n{decryptedInput}\n\n- Warning level:{warningLevel}\n\n-Number of threat points: {points}";
    }

    /// <summary>
    /// Decrypting string using ATBASH cipher.
    /// </summary>
    /// <param name="message">The string to decrypt</param>
    /// <returns>the decrypted string.</returns>
    static string Decrypt(string message)
    {
        string result = "";
        foreach (char character in message)
        {
            if (char.IsLetter(character))
            {
                char baseChar = char.IsUpper(character) ? 'A' : 'a';
                char decryptedChar = (char)(baseChar + ('Z' - char.ToUpper(character)));
                result += char.IsUpper(character) ? decryptedChar : char.ToLower(decryptedChar);
            }
            else
                result += character;
        }
        return result;
    }

    /// <summary>
    /// Main with the test cases for the decrypting system.
    /// </summary>
    /// <param name="args">Arguments from the user.</param>
    static void Main(string[] args)
    {
        string encryptedMessage = @"Lfi ulixvh ziv kivkzirmt uli z nzqli zggzxp lm gsv Arlmrhg vmvnb.
Gsv ilxpvg fmrgh ziv ivzwb zmw dzrgrmt uli gsv hrtmzo.
Ylnyh szev yvvm kozxvw mvzi pvb olxzgrlmh.
Mfpsyz urtsgvih ziv hgzmwrmt yb uli tilfmw rmurogizgrlm.
Gsv zggzxp droo yv hfwwvm zmw hgilmt -- gsvb dlm’g hvv rg xlnrmt.
Dv nfhg hgzb srwwvm zmw pvvk gsv kozm hvxivg fmgro gsv ozhg nlnvmg.
Erxglib rh mvzi. Hgzb ivzwb.";

        Console.WriteLine($"Before decryption:\n{encryptedMessage}\n");
        string decryptedMessage = Decrypt(encryptedMessage);
        int threatPoint = DetectDangerousWords(decryptedMessage);
        Console.WriteLine(ReportStatus(decryptedMessage, threatPoint));
    }
    
}
