public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
            {
                Left = new Node(value);
            }
            else if (Left.Data != value)
            {
                Left.Insert(value);
            }
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else if (Right.Data != value)
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        /*if (Data == value)
        {
            return true;
        }
        else if (value < Data)
        {
            if (Right is null)
            {
                return false;
            }
            else
            {
                return Right.Contains(value);
            }
        }
        else if (value > Data)
        {
            if (Left is null)
            {
                return false;
            }
            else
            {
                return Left.Contains(value);
            }
        }
        else
        {
            return true;
        }*/
        List<int> values = new List<int>();
        Contains(values);
        return values.Contains(value);
    }

    public void Contains(List<int> values)
    {
        values.Add(Data);
        if (!(Left is null))
        {
            Left.Contains(values);
        }
        if (!(Right is null))
        {
            Right.Contains(values);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // return 0;
        int l = GetHeight(Left,0);
        int r = GetHeight(Right,0);
        int res;
        if (l > r)
        {
            res = l + 1;
        }
        else
        {
            res = r + 1;
        }
        return res + 1; // Replace this line with the correct return statement(s)
    }

    public int GetHeight(Node? node, int cur)
    {
        // overload to let me keep track of the height easier
        if (node is null)
        {
            return cur;
        }
        else
        {
            int curb =cur + 1;
            int l;
            int r;
            if (node.Left is null)
            {
                l = cur;
            }
            else
            {
                l = GetHeight(node.Left,curb);
            }
            if (node.Right is null)
            {
                r = cur;
            }
            else
            {
                r = GetHeight(node.Right,curb);
            }
            if (l > r)
            {
                return l;
            }
            else
            {
                return r;
            }
        }
        // return 0;
    }
}