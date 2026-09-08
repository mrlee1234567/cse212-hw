public static class MysteryStack2 {
    private static bool IsFloat(string text) {
        return float.TryParse(text, out _);
    }

    public static float Run(string text) {
        var stack = new Stack<float>();
        foreach (var item in text.Split(' ')) {//splits the input along spaces
            if (item == "+" || item == "-" || item == "*" || item == "/") {//if it is +,-,*, or /
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!"); //if there are less than two items, exception

                var op2 = stack.Pop();//last item
                var op1 = stack.Pop();//second to last item
                float res;
                if (item == "+") {
                    res = op1 + op2;//if plus, add
                }
                else if (item == "-") {//if minus, subtract
                    res = op1 - op2;
                }
                else if (item == "*") {//if multiply, multiply
                    res = op1 * op2;
                }
                else {
                    if (op2 == 0)//if last item is 0, cannot divide by 0, exception
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;//if slash, divide
                }

                stack.Push(res);//push the results to the stack
            }
            else if (IsFloat(item)) {//if the item is otherwise a float, push to stack
                stack.Push(float.Parse(item));
            }
            else if (item == "") {//is the item is otherwise somehow blank, skip
            }
            else {//if all else fails, exception
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1)//at the end, if the stack does not have only one item, exception
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop();//return the last item
    }
}
/*
test input determinations:
5 3 7 + * -- stack3: 5,3,7; 5,10; 50, final answer: 50
6 2 + 5 3 - / -- stack2: 6,2; 8; 8,5,3; 8,2; 4, final answer: 4
invalid cases:
1 - if the stack has less than two items in it when iterating through the input
2 - if the last item in the stack is 0 and the operation is divide, meaning that you would be trying to divide by 0
3 - if the current iterator is not a valid number or operator, or otherwise blank
4 - if the stack has more or less than one item left in it at the end of the process
*/