using System.Collections;
using System.Text.Json;
using Microsoft.VisualBasic;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        Dictionary<string, string> dic = new Dictionary<string, string>();
        // List<string> res = new List<string>();
        // HashSet<string> hs = new HashSet<string>();
        HashSet<string> hs = new HashSet<string>();
        foreach (string i in words)
        {
            // test scenario: ["am", "at", "ma", "if", "fi"]
            /*
            
            i=am, iq=ma
            i!=iq
            iq not in dic
            dic={am:ma}

            i=at, iq=ta
            i!=iq
            iq not in dic
            dic={am:ma,at:ta}
            i=ma, iq=am
            i!=iq
            iq in dict
            res=[am ma]

            i=if, iq=fi
            i!=iq
            iq not in dic
            dic={am:ma,at:ta,if:fi}

            i=fi, iq=if
            i!=iq
            iq in dic
            res=[am ma,if fi]

            */
            // char[] sary = i.ToArray();
            // sary.Reverse();
            // string iq = new string(sary);
            string iq = Strings.StrReverse(i);
            
            
            // Console.WriteLine($"{i} - {iq}");
            // int hsn = hs.Count;
            // hs.Add(i);
            // hs.Add(iq);
            if (dic.ContainsKey(iq)/* || i == iq*/)
            {
                hs.Add($"{i} & {iq}");
            }
            else/* if (i != iq)*/
            {
                if (!dic.ContainsKey(i))
                {
                    dic.Add(i, iq);
                }
                
            }
            
        }
        return hs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            // line 4 (ind 3) is degrees
            string dg = fields[3];
            if (degrees.ContainsKey(dg))
            {
                degrees[dg]++;
            }
            else
            {
                degrees[dg] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        if (word1.Contains(' '))
        {
            Console.WriteLine($"w1spc {word1}");
            word1 = word1.Replace(" ", string.Empty);
        }
        if (word2.Contains(' '))
        {
            Console.WriteLine($"w2spc {word2}");
            word2 = word2.Replace(" ", string.Empty);
        }
        Console.WriteLine($"{word1} {word2}");
        if (word1.Length != word2.Length)
        {
            Console.WriteLine("no wrong len");
            return false;
        }
        word1 = word1.ToUpper();
        word2 = word2.ToUpper();
        Console.WriteLine($"{word1} {word2}");
        HashSet<char> l1 = new HashSet<char>();
        HashSet<char> l2 = new HashSet<char>();
        Dictionary<char,int> d1 = new Dictionary<char, int>();
        Dictionary<char,int> d2 = new Dictionary<char, int>(); 
        foreach (char i in word1)
        {
            if (i != ' ')
            {
                l1.Add(i);
                if (d1.ContainsKey(i))
                {
                    d1[i]++;
                }
                else
                {
                    d1[i] = 1;
                }
            }
        }
        foreach (char i in word2)
        {
            l2.Add(i);
            if (d2.ContainsKey(i))
            {
                d2[i]++;
            }
            else
            {
                d2[i] = 1;
            }
        }
        if (l1.Count != l2.Count)
        {
            Console.WriteLine("no wrong amount of chars");
            return false;
        }
        foreach (char i in l1)
        {
            int c1 = d1[i];
            int c2;
            if (d2.ContainsKey(i))
            {
                c2 = d2[i];
            }
            else
            {
                Console.WriteLine($"no no char {i} in w2");
                return false;
            }
            if (c1 != c2)
            {
                Console.WriteLine($"no the char {i} is {c1} in w1 and {c2} in w2");
                return false;
            }
        }
        Console.WriteLine("yes\n");
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        List<string> res = new List<string>();
        foreach (Feat i in featureCollection.Features)//thisone was 197
        {
            string iq = $"{i.Properties.Place} - Mag {i.Properties.Mag}";
            res.Add(iq);
        }

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return res.ToArray();
    }
    // created to reverse strings easier for me

    // errors: 10 - 11 - 10 - 9 - 7 - 3 - 2 - 0!
    public static string Invert(string input)
    {
        Stack s = new Stack();
        foreach (char i in input)
        {
            s.Push(i);
        }
        string res = "";
        for (int i = 0; i < s.Count; i++)
        {
            res += s.Pop();
        }
        return res;
    }
}