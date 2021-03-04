using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList2
{
    class Iterator
    {
        private Node currentNode;

        public Iterator(Node currentNode)
        {
            this.currentNode = currentNode;
        }

        public Iterator(Iterator iterator)
        {
            currentNode = iterator.currentNode;
        }

        public bool hasNext()
        {
            return currentNode != null;
        }

        public int next()
        {
            int data = currentNode.getData();

            currentNode = currentNode.getNext();

            return data;
        }

        public Node getCurrentNode()
        {  // modificador de acceso se llama -> package-private
            return currentNode;
        }
    }
}
