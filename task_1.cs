using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Xml;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else tail.next = _item;
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            
            List<Node> nodes = new List<Node>();
            if (head == null) return nodes;
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            if (head == null) return false;
            Node node = head;
            if (node.value == _value)
            {       
                if (node.next == null)
                {
                    tail = null;
                }
                    head = head.next;
                    return true;                        
            }
                
                while (node.next != null)
            {
                if (node.next.value == _value) 
                {
                    if (node.next.next == null) tail = node;
                    node.next = node.next.next;
                    return true; 
                } 
                node = node.next;
                    
            }

            return false;
        }

        public void RemoveAll(int _value)
        {
            if (head == null) return;           
            while (head != null && head.value == _value)
            {   
                head = head.next;
            }
            if (head == null)
            {
                tail = null;
                return;
            }
            Node node = head;
            while (node.next != null)
            {
                if (node.next.value == _value)
                {
                    node.next = node.next.next;
                    if (node.next == null) tail = node;
                }
                else
                {
                    node = node.next;
                }
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
        {
            if (head == null) return 0;
            Node node = head;
            int count = 0;
            while (node != null)
            {
                count += 1;
                node = node.next;
            }
            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeToInsert == null) return;
            if (_nodeAfter == null)
            {
                AddInTail(_nodeToInsert); 
                return;
            }
            if (_nodeAfter == tail)
            {
                tail.next = _nodeToInsert;
                tail = _nodeToInsert;
                return;
            }
            if (_nodeAfter == tail)
             _nodeToInsert.next = _nodeAfter.next;   
            _nodeAfter.next = _nodeToInsert;
        }

    }
}
