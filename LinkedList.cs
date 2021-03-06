﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList2
{
    class LinkedList
    {
        private Node head;
        private Node tail;
        private int size;

        public void add(int data)
        {
            Node node = new Node(data);

            node.setPrevious(tail);

            if (tail != null)
            {
                tail.setNext(node);
            }

            if (head == null)
            {
                head = node;
            }

            tail = node;
            size++;
        }

        /**
         * @param index 0-index
         * @return data in index
         */
        public int get(int index)
        {
            Node currentNode = head;
            int currentIndex = 0;

            if (index < 0 || index >= size)
            {
                Console.WriteLine("El elemento no se encuentra en la lista actual");
                return 0;
            }

            while (currentIndex < index)
            {
                currentNode = currentNode.getNext();
                currentIndex++;
            }
            return currentNode.getData();
        }

        public void delete(int index)
        {
            Node currentNode = head;
            int currentIndex = 0;

            if (index < 0 || index >= size)
            {
                return;
            }

            size--;

            if (size == 0)
            {
                head = null;
                tail = null;
                return;
            }

            if (index == 0)
            {
                head = head.getNext();
                head.setPrevious(null);
            }

            if (index == size - 1)
            {
                tail = tail.getPrevious();
                tail.setNext(null);
            }

            if (index > 0 && index < size - 1)
            {
                while (currentIndex < index)
                {
                    currentNode = currentNode.getNext();
                    currentIndex++;
                }
                currentNode.getPrevious().setNext(currentNode.getNext());
                currentNode.getNext().setPrevious(currentNode.getPrevious());
            }
        }

        public Iterator getIterator()
        {
            return new Iterator(head);
        }

        public void insert(int data,Position position, Iterator it)
        {
            // ¿qué ofrece java para restringir los valores de position a solamente BEFORE y AFTER?

            Node newNode = new Node(data);
            Node currentNode = it.getCurrentNode();

            if (position == Position.AFTER)
            {
                newNode.setNext(currentNode.getNext());
                newNode.setPrevious(currentNode);
                currentNode.setNext(newNode);
                if (newNode.getNext() != null)
                {
                    newNode.getNext().setPrevious(newNode);
                }
                else
                {
                    tail = newNode;
                }
            }
            else if (position == Position.BEFORE)
            {
                newNode.setPrevious(currentNode.getPrevious());
                newNode.setNext(currentNode);
                currentNode.setPrevious(newNode);
                if (newNode.getPrevious() != null)
                {
                    newNode.getPrevious().setNext(newNode);
                }
                else
                {
                    head = newNode;
                }
            }
            size++;
        }


        //Iterador -> patrón de diseño

        public int getSize()
        {
            return size;
        }

        public ReverseIterator getReverseIterator()
        {
            return new ReverseIterator(tail);
        }
    }
}
