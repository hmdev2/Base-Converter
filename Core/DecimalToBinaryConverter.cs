using System;
using System.Globalization;
using BaseConverter.Exceptions;
using BaseConverter.Models;

namespace BaseConverter.Core
{
    class DecimalToBinaryConverter
    {
       public static string Convert(Number number)
       {
        if (number.GetValue() == "")
        {
            throw new ConverterException("Escreva um pelo menos um número!");
        }
        if(!int.TryParse(number.GetValue(), out var intNum)) {
            if(!double.TryParse(number.GetValue(), out var doubNum)) {
                throw new ConverterException("Escreva somente números!");
            }
        }
        int integerPart = int.Parse(number.GetIntegerPart());
        string IntegerPartBinary = IntegerPartConverter(integerPart);

        double fractionalPart = double.Parse("0." + number.GetFractionalPart(), CultureInfo.InvariantCulture);
        string fractionalPartBinary = FractionalPartConverter(fractionalPart);

        return IntegerPartBinary + fractionalPartBinary;
       }

       private static string IntegerPartConverter(int integerPart)
       {
        bool isNegative = integerPart < 0;
        if(isNegative)
        {
            integerPart *= -1;
        }

        List<int> IntegerPartBinaryAux = new List<int>();

        if(integerPart == 0)
        {
            IntegerPartBinaryAux.Add(0);
        }

        while(integerPart > 0)
        {
            IntegerPartBinaryAux.Add(integerPart % 2);
            integerPart /= 2;
        }

        IntegerPartBinaryAux.Reverse();

        string IntegerPartBinary = string.Join("", IntegerPartBinaryAux);
        return isNegative ? "-" + IntegerPartBinary : IntegerPartBinary;
       }

       private static string FractionalPartConverter(double fractionalPart)
       {
        if(fractionalPart > 0)
        {
            List<int> FractionalBinaryPartAux = new List<int>();

            
            int count = 0;
            while(fractionalPart > 0 && count < 15)
            {
                double aux = fractionalPart * 2;
                int integerPartFromFractional = (int)Math.Floor(aux);

                FractionalBinaryPartAux.Add(integerPartFromFractional);
                fractionalPart = aux - integerPartFromFractional;
                count++;
            }
            string fractionalPartBinary = string.Join("", FractionalBinaryPartAux);
            if(count == 15)
            {
                return $".{fractionalPartBinary}...";
            }
            return $".{fractionalPartBinary}";
        }
        else
        {
            return "";
        }
       }

    }
}