using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace CollectionClass
{
    class Books:IEnumerable
    {
        public ArrayList m_booktitles;
        public Books()
        {
            m_booktitles = new ArrayList();
        }
        public void Add(string booktitle)
        {
            m_booktitles.Add(booktitle);
        }
        public void Remove(string booktitle)
        {
            m_booktitles.Remove(booktitle);
        }

        public IEnumerator GetEnumerator()
        {
            return new BooksEnumerator(this);
        }
    }
    class BooksEnumerator:IEnumerator
    {
        private int position = -1;
        private Books books;

        public BooksEnumerator(Books books)
        {
            this.books = books;
        }

        public bool MoveNext()
        {
            if (position < books.m_booktitles.Count - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                return books.m_booktitles[position];
            }
        }
    }
}