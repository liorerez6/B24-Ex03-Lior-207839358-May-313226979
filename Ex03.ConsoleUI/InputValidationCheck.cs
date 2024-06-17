//using Ex03.GameLogic;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Ex03.ConsoleUI
//{
//    internal class InputValidationCheck
//    {
//        private static void throwException(string i_Input)
//        {
//            InputOutOfRangeException valueOutOfRangeException = new InputOutOfRangeException("Exception: " + i_Input + " is not valid!");
//            throw valueOutOfRangeException;
//        }

//        public static void AreAllCharactersDigits(string i_Input)
//        {
//            bool isValidInput = string.IsNullOrEmpty(i_Input);

//            if (!isValidInput)
//            {
//                foreach (char c in i_Input)
//                {
//                    if (!char.IsDigit(c))
//                    {
//                        isValidInput = true;
//                    }
//                }
//            }

//            if (isValidInput)
//            {
//                throwException(i_Input);
//            }
//        }

//        public static void AreAllCharactersChars(string i_Input)
//        {
//            bool isValidInput = string.IsNullOrEmpty(i_Input);

//            if (!isValidInput)
//            {
//                foreach (char c in i_Input)
//                {
//                    if (!char.IsLetter(c))
//                    {
//                        isValidInput = true;
//                    }
//                }
//            }

//            if (isValidInput)
//            {
//                throwException(i_Input);
//            }
//        }

//        public static void IsVehicleTypeValid(string i_Input)
//        {
//            if (!Enum.TryParse(i_Input, out Enums.EVehicleTypes getType))
//            {
//                throwException(i_Input);
//            }
//        }

//        public static void IsInputIncludesDigitsInSpecificRange(string i_Input, int i_Start, int i_End)
//        {
//            AreAllCharactersDigits(i_Input);
            
//            if(int.TryParse(i_Input, out int getNumber))
//            {
//                if(!(getNumber >= i_Start && getNumber <= i_End))
//                {
//                    throwException(i_Input);
//                }
//            }
//        }
//    }
//}
