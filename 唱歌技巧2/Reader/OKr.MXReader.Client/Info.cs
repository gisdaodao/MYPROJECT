﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 股票新闻
{
    public class Info
    {
        public string text { get; set; }
        public string info { get; set; }
        public string dataurl { get; set; }
        public string picurl { get; set; }
    }
    public class NewsInfo
    {
        public string content { get; set; }
        public string title { get; set; }
        public string from { get; set; }
        public string date { get; set; }
        public string kind { get; set; }
        public string picurl { get; set; }

        public string dataurl { get; set; }
    } 
}
