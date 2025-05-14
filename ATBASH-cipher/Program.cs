namespace ATBASH_cipher;

internal class Program
{
    static int CalculateDangerousWords(string input)
    {
        string[] dengerousWords = { "bomb", "nukhba", "fighter", "rocket", "secret" };
        string[] stringToWords = input.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        int conterWords = 0;
        List<string> WordsAppearing = new List<string>();
        
        foreach (string word in stringToWords)
        {
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
    
    static string AddWarning(string decryptedInput, int points)
    {
        string warningLevel = "";
        switch (points)
        {
            case > 0 and <= 5:
                warningLevel += "WARNING";
                break;
            case > 5 and <= 10:
                warningLevel += "DANGER!";
                break;
            case > 10 and <= 15:
                warningLevel += "ULTRA ALERT!";
                break;
            default:
                warningLevel += "NO THREAT DETECTED";
                break;
        }
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

    static void Main(string[] args)
    {
        string encryptedMessage = @"Lfi ulixvh ziv kivkzirmt uli z nzqli zggzxp lm gsv Arlmrhg vmvnb.
Gsv ilxpvg fmrgh ziv ivzwb zmw dzrgrmt uli gsv hrtmzo.
Ylnyh szev yvvm kozxvw mvzi pvb olxzgrlmh.
Mfpsyz urtsgvih ziv hgzmwrmt yb uli tilfmw rmurogizgrlm.
Gsv zggzxp droo yv hfwwvm zmw hgilmt -- gsvb dlm’g hvv rg xlnrmt.
Dv nfhg hgzb srwwvm zmw pvvk gsv kozm hvxivg fmgro gsv ozhg nlnvmg.
Erxglib rh mvzi. Hgzb ivzwb.";

        Console.WriteLine($"before encreyption:\n{encryptedMessage}\n");
        string decryptedMessage = Decrypt(encryptedMessage);
        int threatPoint = CalculateDangerousWords(decryptedMessage);
        Console.WriteLine(AddWarning(decryptedMessage, threatPoint));
    }
    
}
