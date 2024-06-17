using System;

namespace Ex03.GameLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(Exception i_InnerException, string i_Message) : base(i_Message, i_InnerException)
        {

        }

        public ValueOutOfRangeException(string i_Message) : base(i_Message)
        {
            
        }

        public ValueOutOfRangeException(string i_Message, float i_Start, float i_End) : base(i_Message)
        {

        }
    }
}
