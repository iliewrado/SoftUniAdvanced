﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private readonly SortedSet<Book> Books;
        public Library(params Book[] books)
        {
            Books = new SortedSet<Book>(books, new BookComparator());
        }
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(Books);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int index;
            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();
                books = new List<Book>(books);
            }

            public Book Current => books[index];

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext() => ++index < books.Count;

            public void Reset() => index = - 1;
        }
    }
}
