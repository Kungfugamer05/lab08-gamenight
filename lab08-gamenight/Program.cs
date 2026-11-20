/*
* Name: James Gavin Ballard
* Course: CSCI 1250, Section 001
* Assignment: Lab 08, Game Night
* Date: November 19, 2026
* Description: Keeps a game night leaderboard in three text files. Shows the
* season so far, records tonight's points, saves the new totals,
* and adds tonight's result to a history that grows every week.
*/

using System;
using System.IO;

const string PLAYERS_FILE = "players.txt";
const string POINTS_FILE = "points.txt";
const string HISTORY_FILE = "history.txt";
const int MAX_POINTS = 20;

//Find the text files in project folder
string projectFolder = Path.GetFullPath(
    Path.Combine(AppContext.BaseDirectory, "..", "..",".."));
Directory.SetCurrentDirectory(projectFolder);

System.Console.WriteLine("=== GAME NIGHT LEADERBOARD ===");

//Part 1: Read the players and show the standings 
string[] players = File.ReadAllLines(PLAYERS_FILE);
string[] points = File.ReadAllLines(POINTS_FILE);

System.Console.WriteLine("PLAYER".PadRight(11) + "POINTS");

// for: The name and score use the same position in two arrays
for (int i = 0; i < players.Length; i++)
{
    System.Console.WriteLine(players[i].PadRight(11) + points[i]);
}

int leader = LeaderIndex(points);
System.Console.WriteLine("Leader: " + players[leader] + "with" + points[leader]);
System.Console.WriteLine("Season total: " + TotalPoints(points));

// Returns the position of the highest season score
static int LeaderIndex(string[] points)
{
    int leader = 0;

    // for: We need the index, not just the score itself
    for (int i = 1; i < points.Length; i++)
    {
        if (Convert.ToInt32(points[i]) > Convert.ToInt32(points[leader]))
        {
            leader = i;
        }
    }

    return leader;
}

// Returns the total of all the season scores
static int TotalPoints(string[] points)
{
    int total = 0;

    // foreach: Every score is added and the index isn't needed
    foreach (string score in points)
    {
        total = total + Convert.ToInt32(score);
    }

    return total;
}