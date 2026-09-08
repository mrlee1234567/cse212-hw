public static class MysteryStack1 {
    public static string Run(string text) {
        var stack = new Stack<char>();
        foreach (var letter in text)//pushes each letter into the stack sequentially
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)//pulls out the last letter, effectivelly reversing the output
            result += stack.Pop();

        return result;
    }
}
/*
test input determinations:
racecar - racecar
stressed - desserts
a nut for a jar of tuna - anut fo raj a rof tun a
*/