using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CustomLinkedList<T> : IEnumerable<T>
{
    private class Node
    {
        public Node(T data)
        {
            this.Data = data;
            this.Next = null;
        }

        public Node(T data, Node prevNode)
        {
            this.Data = data;
            prevNode.Next = this;
        }

        public T Data { get; set; }

        public Node Next { get; set; }

    }

    private Node head;
    private Node tail;
    private int count;

    public CustomLinkedList()
    {
        this.head = null;
        this.tail = null;
        this.count = 0;
    }

    public int Count
    {
        get { return count; }
    }

    public void Add(T item)
    {
        if (head == null)
        {
            head = new Node(item);
            tail = head;
        }
        else
        {
            Node newNode = new Node(item, tail);
            tail = newNode;
        }
        count++;
    }

    public int Remove(T item)
    {
        int currentIndex = 0;

        Node currentNode = head;
        Node prevNode = null;

        while (currentNode != null)
        {
            if ((currentNode.Data != null && currentNode.Data.Equals(item)) || (currentNode.Data == null) && (item == null))
                break;

            prevNode = currentNode;

            currentNode = currentNode.Next;
            currentIndex++;
        }

        if (currentNode != null)
        {
            count--;

            if (count == 0)
            {
                head = null;
            }
            else if (prevNode == null)
            {
                head = currentNode.Next;
            }
            else
            {
                prevNode.Next = currentNode.Next;
            }

            Node lastElement = null;

            if (this.head != null)
            {
                lastElement = this.head;

                while (lastElement.Next != null)
                {
                    lastElement = lastElement.Next;
                }
            }

            tail = lastElement;

            return currentIndex;
        }
        else
        {
            return -1;
        }
    }

    public int IndexOf(object item)
    {
        Node current = head;
        for (int i = 0; i < count; i++)
        {
            if (current.Data.Equals(item))
            {
                return i;
            }
            current = current.Next;
        }
        return -1;
    }

    public bool Contains(object item)
    {
        return IndexOf(item) != -1;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
