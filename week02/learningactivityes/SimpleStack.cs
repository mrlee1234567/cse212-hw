
using System;
using System.Collections.Generic;

Console.WriteLine("\n======================\nSimple Stack\n======================");

var stack = new Stack<int>();
stack.Push(1);//1
stack.Push(2);//12
stack.Push(3);//123
stack.Pop();//12
stack.Pop();//1
stack.Push(4);//14
stack.Push(5);//145
stack.Pop();//14
stack.Push(6);//146
stack.Push(7);//1467
stack.Push(8);//14678
stack.Push(9);//146789
stack.Pop();//14678
stack.Pop();//1467
stack.Push(10);//1467;0
stack.Pop();//1467
stack.Pop();//146
stack.Pop();//14
stack.Push(11);//14;1
stack.Push(12);//14;12
stack.Pop();//14;1
stack.Pop();//14
stack.Pop();//1
stack.Push(13);//1;3
stack.Push(14);//1;34
stack.Push(15);//1;345
stack.Push(16);//1;3456
stack.Pop();//1;345
stack.Pop();//1;34
stack.Pop();//1;3
stack.Push(17);//1;37
stack.Push(18);//1;378
stack.Pop();//1;37
stack.Push(19);//1;379
stack.Push(20);//1;379;;0
stack.Pop();//1;379
stack.Pop();//1;37
//the final stack is: 1, 13, 17
Console.WriteLine("Final contents:");
Console.WriteLine(String.Join(", ", stack.ToArray()));
//upon running, it was correct, but the order i was in was backwards relative to the results