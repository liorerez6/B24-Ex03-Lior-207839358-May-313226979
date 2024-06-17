using System;

namespace Ex03.ConsoleUI
{
    internal class InputOutOfRangeException : Exception
    {
       public InputOutOfRangeException(Exception i_InnerException, string i_Message) : base(i_Message, i_InnerException)
       {

       }

        public InputOutOfRangeException(string i_Message) : base(i_Message)
        {

        }
    }
}
