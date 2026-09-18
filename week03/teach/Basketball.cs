/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        int biggestPt = 0;
        string biggestHolder;
        int smallestPt = 999999999;
        HashSet<string> pls = new HashSet<string>();
        while (!reader.EndOfData) {
            //0=id, 1=year, 8=oiints
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);
            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            }
            else
            {
                players.Add(playerId,points);
                pls.Add(playerId);
            }

            if (players[playerId] > biggestPt)
            {
                biggestPt = players[playerId];
                biggestHolder = playerId;
            }
            if (players[playerId] < smallestPt)
            {
                smallestPt = players[playerId];
            }

        }
        List<int> pts = new List<int>();
        Dictionary<int, string> freakyFri = new Dictionary<int, string>();

        foreach (string i in pls)
        {
            int iq = players[i];
            pts.Add(iq);
            if (freakyFri.ContainsKey(iq))
            {
                freakyFri[iq] = $"{freakyFri[iq]} + {i}";
            }
            else
            {
                freakyFri.Add(iq, i); //see, the output is hysterical, i dont know why it ended up this way, but cest la vie. i ultimately dont know how to use sort because it wasnt taught in cse 210, so you get that
            }
            
        }
        pts.Sort();

        Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");

        var topPlayers = new string[10];
        for (int i = 0; i < 10; i++)
        {
            int iq = pts[i];
            topPlayers[i] = freakyFri[iq];
        }
        Console.WriteLine($"\nTop 10: {string.Join(", ", topPlayers)}");
        //this was a nightmare and i probably did it wreong
    }
}