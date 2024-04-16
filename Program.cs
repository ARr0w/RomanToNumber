var input = Console.ReadLine();

if (string.IsNullOrWhiteSpace(input))
{
    return;
}

Console.WriteLine(RomanToInt(input));

int RomanToInt(string s)
{
    Dictionary<char, int> romanToNumber = new Dictionary<char, int>{
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

    Dictionary<char, List<char>> substractionPossibilities = new Dictionary<char, List<char>>{
            {'I', new List<char>{'V', 'X'}},
            {'X', new List<char>{'L', 'C'}},
            {'C', new List<char>{'D', 'M'}}
        };

    int result = 0;
    for (int i = 0; i < s.Length; i++)
    {
        if (i + 1 < s.Length
           && substractionPossibilities.TryGetValue(s[i], out var wildCardList)
           && wildCardList.Contains(s[i + 1])
          )
        {
            result += romanToNumber[s[i + 1]] - romanToNumber[s[i]];
            i++;
        }
        else
        {
            result += romanToNumber[s[i]];
        }
    }
    return result;
}
