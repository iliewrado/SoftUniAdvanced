﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public string Title { get; private set; }
        public int Year { get; private set; }
        public IReadOnlyList<string> Autors { get; private set; }
        public Book(string title, int year, params string[] autors)
        {
            Title = title;
            Year = year;
            Autors = autors;
        }

        public int CompareTo(Book other)
        {
            int result = Year.CompareTo(other.Year);
            if (result == 0)
            {
                result = Title.CompareTo(other.Title);
            }
            return result;
        }
        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
