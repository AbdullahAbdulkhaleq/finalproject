﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finelproject
{
    class category
    {
        int categoryId;
        string categoryName;


        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }
        public string CategoryName
        {
            get { return categoryName; }

            set { categoryName = value; }
        }
    }
}
