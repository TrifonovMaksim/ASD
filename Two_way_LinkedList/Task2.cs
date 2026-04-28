using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Permissions;
using System.Xml;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
        }

        public Node Find(int _value)
        {
            if (Count() == 0) return null;
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    return node;
                }
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            if (Count() == 0) return nodes;
            while (node != null)
            {
                if (node.value == _value) nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            if (Count() == 0) return false;
            Node node = head;
            if (node.value == _value && Count() == 1)
            {
                head = null;
                tail = null;
                return true;
            }
            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node == head)
                    {
                        head = head.next;
                        head.prev = null;
                        return true;
                    }
                    if (node == tail)
                    {
                        tail = tail.prev;
                        tail.next = null;
                        return true;
                    }
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                    return true;
                }
                node = node.next;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            if (Count() == 0) return;
            Node node = head;
            if (node.value == _value && Count() == 1)
            {
                head = null;
                tail = null;
                return;
            }
            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node == head)
                    {
                        head = head.next;
                        head.prev = null;
                        node = head;
                        continue;
                    }
                    if (node == tail)
                    {
                        tail = tail.prev;
                        tail.next = null;
                        return;
                    }
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                    node = node.next;
                    continue;
                }
                node = node.next;
            }
            return;
        }

        public void Clear()
        {
            head = tail = null;
        }

        public int Count()
        {
            Node node = head;
            int counter = 0;
            while (node != null)
            {
                counter++;
                node = node.next;
            }
            return counter;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeToInsert == null) return;
            _nodeToInsert.prev = _nodeToInsert.next = null;
            if (_nodeAfter == null)
            {
                if (head != null)
                {
                    head.prev = _nodeToInsert;
                    _nodeToInsert.next = head;
                    head = _nodeToInsert;
                    return;
                }
                else
                {
                    head = tail = _nodeToInsert;
                    return;
                }
            }
            Node node = head;
            if (_nodeAfter == tail)
            {
                tail.next = _nodeToInsert;
                _nodeToInsert.prev = tail;
                tail = _nodeToInsert;
                return;
            }
            while (node != null)
            {
                if (node == _nodeAfter)
                {
                    _nodeToInsert.next = node.next;
                    _nodeToInsert.prev = node;
                    node.next.prev = _nodeToInsert;
                    node.next = _nodeToInsert;
                    return;
                }
                node = node.next;
            }

        }
        public void InsertFirst(Node _nodeToInsert)
        {
            if (_nodeToInsert == null) return;
            _nodeToInsert.prev = _nodeToInsert.next = null;
            if (head != null)
            {
                head.prev = _nodeToInsert;
                _nodeToInsert.next = head;
                head = _nodeToInsert;
                return;
            }
            else
            {
                head = tail = _nodeToInsert;
                return;
            }
        }
    }
}

