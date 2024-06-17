using Ex03.GameLogic;
using System;

namespace Ex03.GameLogic
{
    public class LogicInputValidationCheck
    {
        private static void throwException(string i_Input)
        {
            ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException("Exception: " + i_Input + " is not valid!");
            throw valueOutOfRangeException;
        }

        private static void throwException(float i_End, float i_Start, string i_Message)
        {
            ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException(i_Start, i_End, "Exception: " + i_Message + " is not valid!");

            throw valueOutOfRangeException;
        }

        public static void AreAllCharactersDigits(string i_Input)
        {
            bool isValidInput = string.IsNullOrEmpty(i_Input);

            if (!isValidInput)
            {
                isValidInput = !(float.TryParse(i_Input, out float FloatInput));
                
                //foreach (char c in i_Input)
                //{
                //    if (!char.IsDigit(c)
                //    { 
                //        isValidInput = true;
                //    }
                //}
            }

            if (isValidInput)
            {
                throwException(i_Input);
            }
        }

        public static void AreAllCharactersChars(string i_Input)
        {
            bool isValidInput = string.IsNullOrEmpty(i_Input);

            if (!isValidInput)
            {
                foreach (char c in i_Input)
                {
                    if (!char.IsLetter(c))
                    {
                        isValidInput = true;
                    }
                }
            }

            if (isValidInput)
            {
                throwException(i_Input);
            }
        }

        public static void IsVehicleTypeValid(string i_Input)
        {
            if (!Enum.TryParse(i_Input, out EVehicleTypes getType))
            {
                throwException(i_Input);
            }
        }

        public static void IsInputIncludesDigitsInSpecificRange(string i_Input, string i_Message, float i_Start, float i_End)
        {
            AreAllCharactersDigits(i_Input);

            float getNumber = float.Parse(i_Input);
            
            if (!(getNumber >= i_Start && getNumber <= i_End))
            {
                throwException(i_End, i_Start, i_Message);
            }
            
        }
        
        public static void CompareInputToStrings(string i_Input, string i_Message, string i_FisrtCompare, string i_SecondCompare)
        {
            AreAllCharactersChars(i_Input);

            if (!(i_Input.ToLower().Equals(i_FisrtCompare)) && !(i_Input.ToLower().Equals(i_SecondCompare)))
            {
                throwException(i_Message);
            }
        }
    }
}
