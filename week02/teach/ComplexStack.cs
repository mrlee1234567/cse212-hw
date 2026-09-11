public static class ComplexStack {
    public static bool DoSomethingComplicated(string line) {
        var stack = new Stack<char>();
        foreach (var item in line) {
            if (item is '(' or '[' or '{') {
                stack.Push(item);
            }
            else if (item is ')') {
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            else if (item is ']') {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            else if (item is '}') {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        }

        return stack.Count == 0;//checks if the brackets are closing properly
    }
}
/*

1

(a == 3 or (b == 5 and c == 6))
(=>stack
iter to 11
(=>stack
iter to 28
) pop
) pop
returns true

2

Input: (students]i].Grade > 80 and students[i].Grade < 90)
(=>stack
iter 9
no [ found, returns false

3

Input:(robot[id + 1].Execute(.Pass() || (!robot[id * (2 + i)].Alive && stormy) || (robot[id - 1].Alive && lavaFlowing))
(

(=>stack
iter 6
[=>stack
iter 13
] pop
iter 22
(=>stack
iter 28
(=>stack
)pop
iter34
(=>stack
iter41
[=>stack
iter47
(=>st
iter 53
) pop
] pop
iter71
) pop
iter 76
(=>st
[
]
)
)
length > 0 return false

*/