using System;
using System.Collections.Generic;

Console.WriteLine("\n======================\nSimple Queue\n======================");

var queue = new Queue<int>();
queue.Enqueue(1);//1
queue.Enqueue(2);//12
queue.Enqueue(3);//123
queue.Dequeue();//23
queue.Dequeue();//3
queue.Enqueue(4);//34
queue.Enqueue(5);//345
queue.Dequeue();//45
queue.Enqueue(6);//456
queue.Enqueue(7);//4567
queue.Enqueue(8);//45678
queue.Enqueue(9);//456789
queue.Dequeue();//56789
queue.Dequeue();//6789
queue.Enqueue(10);//67890
queue.Dequeue();//7890
queue.Dequeue();//890
queue.Dequeue();//90
queue.Enqueue(11);//901
queue.Enqueue(12);//9012
queue.Dequeue();//012
queue.Dequeue();//12
queue.Dequeue();//2
queue.Enqueue(13);//23
queue.Enqueue(14);//234
queue.Enqueue(15);//2345
queue.Enqueue(16);//23456
queue.Dequeue();//3456
queue.Dequeue();//456
queue.Dequeue();//56
queue.Enqueue(17);//567
queue.Enqueue(18);//5678
queue.Dequeue();//678
queue.Enqueue(19);//6789
queue.Enqueue(20);//67890
queue.Dequeue();//7890
queue.Dequeue();//890
//the final queue is 18, 19, 20
Console.WriteLine("Final contents:");
Console.WriteLine(String.Join(", ", queue.ToArray()));
//yes