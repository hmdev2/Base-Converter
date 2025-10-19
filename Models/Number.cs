using System;

namespace BaseConverter.Models
{
    class Number
    {
       private string Value { get; set; }
       private string NumBase { get; set; }

       public Number(string value, string numBase)
       {
        Value = value;
        NumBase = numBase;
       }

       public string GetIntegerPart()
       {
        try
        {
            string[] aux = Value.Split(".");
            return aux[0];
        } catch
        {
            return Value;
        }
       }

       public string GetFractionalPart()
       {
        try
        {
            string[] aux = Value.Split(".");
            return aux[1];
        } catch
        {
            return "";
        }
       }

       public string GetValue() 
       {
        return Value;
       }
    }
}