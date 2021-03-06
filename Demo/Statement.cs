﻿using System;

namespace TrueOrFalse
{
    [Serializable]
    public class Statement
    {
        public Statement()
        {

        }

        public Statement(string text, bool isTrue)
        {
            Text = text;
            IsTrue = isTrue;
        }

        public string Text { get; set; }
        public bool IsTrue { get; set; }
    }
}