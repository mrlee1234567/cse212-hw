/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    private int TrueMod(int input, int mod)
    {
        int res = ((input % mod) + mod) % mod;
        return res;
        // it bothers me that % doesnt do modulus in c#
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        /// (x,y) : [left, right, up, down]
        bool[] moves = _mazeMap[(_currX,_currY)];
        if (moves[0])
        {
            _currX -= 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        // FILL IN CODE
        // int nx = _currX - 1;
        // if (nx == 0)
        // {
        //     throw new InvalidOperationException("Can't go that way!");
        // }
        // ValueTuple<int,int> vt = new ValueTuple<int,int>(nx,_currY);
        //     if (!_mazeMap[vt][3])
        //     {
        //         throw new InvalidOperationException("Can't go that way!");
        //     }
        // foreach (bool i in _mazeMap[vt])
        // {
        //     if (!i)
        //     {
        //         throw new InvalidOperationException("Can't go that way!");
        //     }
        // }
        // _currX = nx;
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE
        /// (x,y) : [left, right, up, down]
        bool[] moves = _mazeMap[(_currX, _currY)];
        if (moves[1])
        {
            _currX += 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        // int nx = _currX + 1;
        // if (nx == 6)
        // {
        //     throw new InvalidOperationException("Can't go that way!");
        // }
        // ValueTuple<int, int> vt = new ValueTuple<int, int>(nx, _currY);
        // if (!_mazeMap[vt][3])
        // {
        //     throw new InvalidOperationException("Can't go that way!");
        // }
        // foreach (bool i in _mazeMap[vt])
        // {
        //     if (!i)
        //     {
        //         throw new InvalidOperationException("Can't go that way!");
        //     }
        // }
        // _currX = nx;
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE
        /// (x,y) : [left, right, up, down]
        bool[] moves = _mazeMap[(_currX, _currY)];
        if (moves[2])
        {
            _currY -= 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        // int ny = _currY - 1;
        // if (ny == 0)
        // {
        //     throw new InvalidOperationException("Can't go that way!");
        // }
        // ValueTuple<int, int> vt = new ValueTuple<int, int>(_currX,ny);
        // if (!_mazeMap[vt][3])
        // {
        //     throw new InvalidOperationException("Can't go that way!");
        // }
        // foreach (bool i in _mazeMap[vt])
        // {
        //     if (!i)
        //     {
        //         throw new InvalidOperationException("Can't go that way!");
        //     }
        // }
        // _currY = ny;
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE
        /// (x,y) : [left, right, up, down]
        bool[] moves = _mazeMap[(_currX, _currY)];
        if (moves[3])
        {
            _currY += 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        // int ny = _currY + 1;
        // if (ny == 7)
        // {
        //     throw new InvalidOperationException("Can't go that way!");
        // }
        // ValueTuple<int, int> vt = new ValueTuple<int, int>(_currX, ny);
        // if (!_mazeMap[vt][3])
        // {
        //     throw new InvalidOperationException("Can't go that way!");
        // }
        // foreach (bool i in _mazeMap[vt])
        // {
        //     if (!i)
        //     {
        //         throw new InvalidOperationException("Can't go that way!");
        //     }
        // }
        // _currY = ny;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}