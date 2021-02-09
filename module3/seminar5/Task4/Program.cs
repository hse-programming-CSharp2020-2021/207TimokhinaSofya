using System;
using System.Collections.Generic;

namespace Task_3
{
    namespace A
    {
        class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node(int data)
            {
                Data = data;
            }
            public override string ToString()
            {
                return $"{Data}";
            }
        }

        class LinkedList
        {
            Node head;
            Node tail;

            public int Count { get; set; }

            public void Add(int data)
            {
                Node node = new Node(data);
                if (head == null)
                    head = node;
                else
                    tail.Next = node;
                tail = node;
                Count++;
            }
            public void AddFirst(int data)
            {
                Node node = new Node(data);

                node.Next = head;
                head = node;

                if (Count == 0)
                    tail = head;

                Count++;
            }
            public void Clear()
            {
                Count = 0;
                head = null;
                tail = null;
            }
            public bool Contains(int data)
            {
                Node current = head;
                while (current != null)
                {
                    if (current.Data == data)
                        return true;
                    current = current.Next;
                }
                return false;
            }
            public void Print()
            {
                Node current = head;
                int i = 1;
                while (current != null)
                {
                    Console.WriteLine($"{i} - {current}");
                    current = current.Next;
                    i++;
                }
            }

            public Node Max()
            {
                if (head == null)
                    throw new NullReferenceException();
                Node current = head;
                Node max = current;
                while (current != null)
                {
                    if (max.Data < current.Data)
                        max = current;
                    current = current.Next;
                }
                return max;
            }

            public Node Min()
            {
                if (head == null)
                    throw new NullReferenceException();
                Node current = head;
                Node min = current;
                while (current != null)
                {
                    if (min.Data > current.Data)
                        min = current;
                    current = current.Next;
                }
                return min;
            }

            public Node Middle()
            {
                if (head == null)
                    throw new NullReferenceException();
                Node answer = head;
                for(int i = 0; i < Count / 2; i ++)
                {
                    answer = answer.Next;
                }
                return answer;
            }

            public bool Remove(int data)
            {
                if (head == null)
                    throw new NullReferenceException();

                Node current = head;
                Node previous = null;
                while (current != null)
                {
                    if (current.Data == data)
                    {
                        if (previous != null && current.Next != null)
                            previous.Next = current.Next;
                        else if (previous != null && current.Next == null)
                            previous.Next = null;
                        return true;
                    }

                    previous = current;
                    current = current.Next;
                }

                return false;
            }

            public bool Reverse()
            {
                if (head == null)
                    throw new NullReferenceException();

                Node current = head;
                Node previous = null;
                while(current != null)
                {
                    Node tmp = current.Next;
                    current.Next = previous;
                    previous = current;
                    current = tmp;
                }
                head = previous;
                return true;
            }
        }

        class MainClass
        {
            public static void Main()
            {
                LinkedList linkedList = new LinkedList();
                linkedList.Add(1);
                linkedList.Add(2);
                linkedList.AddFirst(3);
                linkedList.Add(4);
                linkedList.Print();
                linkedList.Reverse();
                linkedList.Print();
                Console.ReadKey();
            }
        }
    }
}