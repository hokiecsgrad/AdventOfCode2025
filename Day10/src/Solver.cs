using AdventOfCode.Common;

namespace AdventOfCode.Day10;

public class Solver
{
    public string SolvePart1(string[] data)
    {
        List<string> runningPattern = new();
        List<List<string>> buttons = new();
        List<string> joltage = new();
        (runningPattern, buttons, joltage) = ParseData(data);

        List<List<int>>? shortestButtonPresses = new();
        for (int i = 0; i < runningPattern.Count; i++)
            shortestButtonPresses.Add(FindFewestButtonPresses(runningPattern[i], buttons[i]));

        return shortestButtonPresses?.Sum(sol => sol.Count).ToString();
    }

    public string SolvePart2(string[] data)
    {
        return String.Empty;
    }

    private List<int>? FindFewestButtonPresses(string runningPattern, List<string> buttons)
    {
        bool[] targetState = new bool[runningPattern.Length];
        for (int i = 0; i < runningPattern.Length; i++) targetState[i] = runningPattern[i] == '#' ? true : false;
        bool[] initialState = new bool[runningPattern.Length];
        List<int> initialButtons = new List<int>();
        List<List<int>> allSolutions = new();
        TryPresses(targetState, buttons, 0, initialState, initialButtons, allSolutions);

        return allSolutions.OrderBy(s => s.Count).FirstOrDefault();
    }

    private void TryPresses(bool[] targetState, List<string> buttons, int currButtonIndex, bool[] currentState, List<int> currentPresses, List<List<int>> allSolutions)
    {
        if (currButtonIndex == buttons.Count)
        {
            if (StatesMatch(currentState, targetState))
                allSolutions.Add(new List<int>(currentPresses));
            return;
        }

        // button off, go to next button
        TryPresses(targetState, buttons, currButtonIndex + 1, currentState, currentPresses, allSolutions);

        // button on, go to next button
        PressButton(buttons[currButtonIndex], currentState);
        currentPresses.Add(currButtonIndex);
        TryPresses(targetState, buttons, currButtonIndex + 1, currentState, currentPresses, allSolutions);

        // backtrack the button press before exiting
        currentPresses.RemoveAt(currentPresses.Count - 1);
        PressButton(buttons[currButtonIndex], currentState);
    }

    private void PressButton(string button, bool[] state)
    {
        List<int> lights = button.Split(",").Select(int.Parse).ToList<int>();
        foreach (int lightIndex in lights)
            state[lightIndex] = !state[lightIndex];
    }

    private bool StatesMatch(bool[] a, bool[] b)
    {
        for (int i = 0; i < a.Length; i++)
            if (a[i] != b[i]) return false;

        return true;
    }

    private (List<string>, List<List<string>>, List<string>) ParseData(string[] data)
    {
        List<string> runningPattern = new();
        List<List<string>> buttons = new();
        List<string> joltage = new();
        foreach (string line in data)
        {
            List<string> buttonsParsed = new();
            string[] parts = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            runningPattern.Add(parts[0].Substring(1, parts[0].Length - 2));
            List<string> rawButtons = new List<string>(parts[1..^1]);
            foreach (string button in rawButtons)
                buttonsParsed.Add(button.Substring(1, button.Length - 2));
            buttons.Add(buttonsParsed);
            joltage.Add(parts[^1]);
        }
        return (runningPattern, buttons, joltage);
    }
}