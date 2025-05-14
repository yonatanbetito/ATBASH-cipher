namespace ATBASH_cipher;

internal class Program
{
    
    static object CalculateDangerousWords(string input)
    {
        string[] dengerousWords = { "bomb", "nukhba", "fighter", "rocket", "secret" };
        string[] stringToWords = input.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        int conterWords = 0;
        List<string> WordsAppearing = new List<string>();
        
        foreach (string word in stringToWords)
        {
            if (dengerousWords.Contains(word.ToLower()) || dengerousWords.Contains(word.ToLower() + "s"))
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
    static void Main(string[] args)
    {
        CalculateDangerousWords(
            "Our forces are preparing for a major attack on the Zionist enemy.\nThe rocket units are ready and waiting for the signal.\nBombs have been placed near key locations.\nNukhba fighters are standing by for ground infiltration.\nThe attack will be sudden and strong -- they won't see it coming.\nWe must stay hidden and keep the plan secret until the last moment.\nVictory is near. Stay ready.");
    }
    
}
