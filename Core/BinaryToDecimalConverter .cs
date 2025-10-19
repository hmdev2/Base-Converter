using System;
using System.Globalization;
using BaseConverter.Exceptions;
using BaseConverter.Models;
using BaseConverter.UI;

namespace BaseConverter.Core
{
    class BinaryToDecimalConverter
    {
        public static string Convert(Number number)
        {
            if (number.GetValue() == "")
            {
                throw new ConverterException("Escreva um pelo menos um número binário!");
            }
            
            string integerPart = number.GetIntegerPart();
            string integerPartDecimal = IntegerPartConverter(integerPart);

            string fractionalPart = number.GetFractionalPart();
            string fractionalPartDecimal = FractionalPartConverter(fractionalPart);

            
            return integerPartDecimal + fractionalPartDecimal;
        }

        private static string IntegerPartConverter(string intPart)
        {
            try
            {
                
                bool isNegative = intPart[0] == '-';

                string integerPart;
                if(isNegative)
                {
                    integerPart = intPart.Substring(1);
                }
                else{
                    integerPart = intPart;
                }

                char[] integerPartStringAux = integerPart.ToCharArray();
                List<int> integerPartBinaryAux = new List<int>();

                foreach(char numb in integerPartStringAux)
                {
                    if(numb != '1' && numb != '0')
                    {
                        throw new ConverterException("Escreva um número binário válido!");
                    }
                    integerPartBinaryAux.Add(int.Parse(numb.ToString()));
                }

                integerPartBinaryAux.Reverse();
                
                int aux = 0;
                int sum = 0;
                foreach(int numb in integerPartBinaryAux)
                {
                    int digits = numb * ((int)Math.Pow(2, aux));
                    sum += digits;
                    aux++;
                }
                
                return isNegative ? '-' + sum.ToString() : sum.ToString();
            } 
            catch
            {
                throw;
            }
        }

        private static string FractionalPartConverter(string fractionalPart)
        {
            try
            {
                if (fractionalPart == "")
                {
                    return "";
                }
                
                if(int.Parse(fractionalPart) > 0)
                {
                    char[] fractionalPartStringAux = fractionalPart.ToCharArray();
                    List<double> fractionalPartBinaryAux = new List<double>();

                    foreach(char numb in fractionalPartStringAux)
                    {
                        if(numb != '1' && numb != '0')
                        {
                            throw new ConverterException("Escreva um número binário válido!");
                        }
                        fractionalPartBinaryAux.Add(int.Parse(numb.ToString()));
                    }

                    int aux = -1;
                    double sum = 0;
                    foreach(int numb in fractionalPartBinaryAux)
                    {
                        double digits = numb * ((double)Math.Pow(2, aux));
                        sum += digits;
                        aux--;
                    }

                    return sum.ToString(CultureInfo.InvariantCulture).Substring(1);
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                throw;
            }
        }
    }
}