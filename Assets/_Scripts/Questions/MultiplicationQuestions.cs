//Alexander Maynard (301170707)
//COMP395 - Project 2 - Part 2

//MultiplicationQuestions.cs
//Created Date: 03/24/2025
//Last Modified: 03/24/2025

//Description: This script holds all the multiplication questions for the game, along with index (for future use), hints and answers
//for times tables 1 - 9.

//Log:
//03/24/2025: Created and implemented the full functionality for this script.

//03/24/2025: Finished basic functionlity for this script

//04/04/2025: Added hints to the Lists.

using System.Collections.Generic;
using UnityEngine;

public class MultiplicationQuestions : MonoBehaviour
{
    public readonly List<(int, string, int, string)> _timesTable_1 = new()
    {
        (1, $"1 x 1", 1, "Hint: When multiplying by 1, the answer is the other number that is not 1."),
        (2, $"1 x 2", 2, ""),
        (3, $"1 x 3", 3, ""),
        (4, $"1 x 4", 4, ""),
        (5, $"1 x 5", 5, ""),
        (6, $"1 x 6", 6, ""),
        (7, $"1 x 7", 7, ""),
        (8, $"1 x 8", 8, ""),
        (9, $"1 x 9", 9, ""),
        (10, $"1 x 10", 10, ""),
    };
    public readonly List<(int, string, int, string)> _timesTable_2 = new()
    {
        (1, $"2 x 1", 2, "Hint: When multiplying by 2, double the other number."),
        (2, $"2 x 2", 4, ""),
        (3, $"2 x 3", 6, ""),
        (4, $"2 x 4", 8, ""),
        (5, $"2 x 5", 10, ""),
        (6, $"2 x 6", 12, ""),
        (7, $"2 x 7", 14, ""),
        (8, $"2 x 8", 16, ""),
        (9, $"2 x 9", 18, ""),
        (10, $"2 x 10", 20, ""),
    };
    public readonly List<(int, string, int, string)> _timesTable_3 = new()
    {
        (1, $"3 x 1", 3, "Hint: When multiplying by 3, try skip couting by 3."),
        (2, $"3 x 2", 6, ""),
        (3, $"3 x 3", 9, ""),
        (4, $"3 x 4", 12, ""),
        (5, $"3 x 5", 15, ""),
        (6, $"3 x 6", 18, ""),
        (7, $"3 x 7", 21, ""),
        (8, $"3 x 8", 24, ""),
        (9, $"3 x 9", 27, ""),
        (10, $"3 x 10", 30, "")
    };

    public readonly List<(int, string, int, string)> _timesTable_4 = new()
    {
        (1, $"4 x 1", 4, "When multiplying by 4, try doubling 2 times."),
        (2, $"4 x 2", 8, ""),
        (3, $"4 x 3", 12, ""),
        (4, $"4 x 4", 16, ""),
        (5, $"4 x 5", 20, ""),
        (6, $"4 x 6", 24, ""),
        (7, $"4 x 7", 28, ""),
        (8, $"4 x 8", 32, ""),
        (9, $"4 x 9", 36, ""),
        (10, $"4 x 10", 40, "")
    };
    public readonly List<(int, string, int, string)> _timesTable_5 = new()
    {
        (1, $"5 x 1", 5, "When multiplying by 5, try skip countinng by 5."),
        (2, $"5 x 2", 10, ""),
        (3, $"5 x 3", 15, ""),
        (4, $"5 x 4", 20, ""),
        (5, $"5 x 5", 25, ""),
        (6, $"5 x 6", 30, ""),
        (7, $"5 x 7", 35, ""),
        (8, $"5 x 8", 40, ""),
        (9, $"5 x 9", 45, ""),
        (10, $"5 x 10", 50, "")
    };
    public readonly List<(int, string, int, string)> _timesTable_6 = new()
    {
        (1, $"6 x 1", 6, "When multiplying by 6, try skip counting by 5.\nAfter that, add the other number that is not 6 to the total (unless it is 6x6)."),
        (2, $"6 x 2", 12, ""),
        (3, $"6 x 3", 18, ""),
        (4, $"6 x 4", 24, ""),
        (5, $"6 x 5", 30, ""),
        (6, $"6 x 6", 36, ""),
        (7, $"6 x 7", 42, ""),
        (8, $"6 x 8", 48, ""),
        (9, $"6 x 9", 54, ""),
        (10, $"6 x 10", 60, "")
    };
    public readonly List<(int, string, int, string)> _timesTable_7 = new()
    {
        (1, $"7 x 1", 7, "When multiplying by 7, try skip counting by 7.\nThis is considered the hardest multiplication table by some."),
        (2, $"7 x 2", 14, ""),
        (3, $"7 x 3", 21, ""),
        (4, $"7 x 4", 28, ""),
        (5, $"7 x 5", 35, ""),
        (6, $"7 x 6", 42, ""),
        (7, $"7 x 7", 49, ""),
        (8, $"7 x 8", 56, ""),
        (9, $"7 x 9", 63, ""),
        (10, $"7 x 10", 70, "")
    };
    public readonly List<(int, string, int, string)> _timesTable_8 = new()
    {
        (1, $"8 x 1", 8, "When multiplying by 8, try doubling 3 times."),
        (2, $"8 x 2", 16, ""),
        (3, $"8 x 3", 24, ""),
        (4, $"8 x 4", 32, ""),
        (5, $"8 x 5", 40, ""),
        (6, $"8 x 6", 48, ""),
        (7, $"8 x 7", 56, ""),
        (8, $"8 x 8", 64, ""),
        (9, $"8 x 9", 72, ""),
        (10, $"8 x 10", 80, "")
    };
    public readonly List<(int, string, int, string)> _timesTable_9 = new()
    {
        (1, $"9 x 1", 9, ""),
        (2, $"9 x 2", 18, ""),
        (3, $"9 x 3", 27, ""),
        (4, $"9 x 4", 36, ""),
        (5, $"9 x 5", 45, ""),
        (6, $"9 x 6", 54, ""),
        (7, $"9 x 7", 63, ""),
        (8, $"9 x 8", 72, ""),
        (9, $"9 x 9", 81, ""),
        (10, $"9 x 10", 90, "")
    };
}