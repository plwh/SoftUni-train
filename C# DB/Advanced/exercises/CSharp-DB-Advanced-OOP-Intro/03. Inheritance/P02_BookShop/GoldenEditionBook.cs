﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P02_BookShop
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string author, string title, decimal price) 
            : base(author, title, price)
        {
            this.Price *= 1.3m;
        }
    }
}
