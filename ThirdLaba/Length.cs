using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThirdLaba
{
    public enum MeasureType { bi, oc, de, he }; //двочиная, восьмеричная, десятичная, шестнадцатеричная

    public class Length
    {
        private string value;
        private MeasureType type;

        public Length(string value, MeasureType type)
        {
            this.value = value;
            this.type = type;
        }

        public string Verbose()
        {
            string typeVerbose = "";
            switch (this.type)
            {
                case MeasureType.bi:
                    typeVerbose = "(2)";
                    break;
                case MeasureType.oc:
                    typeVerbose = "(8)";
                    break;
                case MeasureType.de:
                    typeVerbose = "(10)";
                    break;
                case MeasureType.he:
                    typeVerbose = "(16)";
                    break;
            }
            return this.value + typeVerbose;
        }

        //Перевод из десятичного в любой
        public static string DeToAny(string value, int num)
        {
            int CoolValue = int.Parse(value);
            bool negative = false;

            if (CoolValue < 0) {
                CoolValue = Math.Abs(CoolValue);
                negative = true;
            }
            if (CoolValue == 0)
            {
                return "0";
            }

            StringBuilder result = new StringBuilder();
            const string digits = "0123456789ABCDEF";

            while (CoolValue > 0)
            {
                int digit = CoolValue % num;
                result.Insert(0, digits[digit]);
                CoolValue /= num;
            }

            if (negative)
            {
                result.Insert(0, "-");
            }

            return result.ToString();
        }

        //Перевод из любого в десятичный
        public static string AnyToDe(string value, int num)
        {
            int CoolValue = 0;
            bool negative = false;

            if (value.StartsWith("-"))
            {
                value = value.Substring(1);
                negative = true;
            }
            if (value == "0")
            {
                return "0";
            }

            const string digits = "0123456789ABCDEF";

            foreach (char c in value)
            {
                int digit = digits.IndexOf(char.ToUpper(c));
                if (digit == -1 || digit >= num)
                    return "Неправильный ввод";

                CoolValue = CoolValue * num + digit;
            }

            StringBuilder result = new StringBuilder(CoolValue.ToString());

            if (negative)
            {
                result.Insert(0, "-");
            }

            return result.ToString();
        }


        // Измерения
        public Length To(MeasureType newType)
        {
            var newValue = this.value;
            if (this.type == MeasureType.de)
            {
                switch (newType)
                {
                    case MeasureType.de:
                        newValue = this.value;
                        break;
                    case MeasureType.bi:
                        newValue = DeToAny(this.value, 2);
                        break;
                    case MeasureType.oc:
                        newValue = DeToAny(this.value, 8);
                        break;
                    case MeasureType.he:
                        newValue = DeToAny(this.value, 16);
                        break;
                }
            }
            else if (newType == MeasureType.de)
            {
                switch (this.type) 
                {
                    case MeasureType.de:
                        newValue = this.value;
                        break;
                    case MeasureType.bi:
                        newValue = AnyToDe(this.value, 2);
                        break;
                    case MeasureType.oc:
                        newValue = AnyToDe(this.value, 8);
                        break;
                    case MeasureType.he:
                        newValue = AnyToDe(this.value, 16);
                        break;
                }
            }
            else 
            {
                newValue = this.To(MeasureType.de).To(newType).value;
            }
            return new Length(newValue, newType);
        }

        //---------------------------------------
        // сложение
        public static Length operator +(Length instance, int number)
        {
            int result;
            if (instance.type == MeasureType.de)
            {
                result = int.Parse(instance.value) + number;
            }
            else
            {
                result = int.Parse(instance.To(MeasureType.de).value) + number;
            }

            string final = result.ToString();
            Length goal = new Length(final, MeasureType.de);

            return new Length(goal.To(instance.type).value, instance.type);
        }

        public static Length operator +(int number, Length instance)
        {
            return instance + number;
        }

        // умножение
        public static Length operator *(Length instance, int number)
        {
            int result;
            if (instance.type == MeasureType.de)
            {
                result = int.Parse(instance.value) * number;
            }
            else
            {
                result = int.Parse(instance.To(MeasureType.de).value) * number;
            }

            string final = result.ToString();
            Length goal = new Length(final, MeasureType.de);

            return new Length(goal.To(instance.type).value, instance.type); 
        }

        public static Length operator *(int number, Length instance)
        {
            return instance * number;
        }

        // вычитание
        public static Length operator -(Length instance, int number)
        {
            int result;
            if (instance.type == MeasureType.de)
            {
                result = int.Parse(instance.value) - number;
            }
            else
            {
                result = int.Parse(instance.To(MeasureType.de).value) - number;
            }

            string final = result.ToString();
            Length goal = new Length(final, MeasureType.de);

            return new Length(goal.To(instance.type).value, instance.type);
        }

        public static Length operator -(int number, Length instance)
        {
            return instance - number;
        }

        // деление
        public static Length operator /(Length instance, int number)
        {
            int result;
            if (instance.type == MeasureType.de)
            {
                result = int.Parse(instance.value) / number;
            }
            else
            {
                result = int.Parse(instance.To(MeasureType.de).value) / number;
            }

            string final = result.ToString();
            Length goal = new Length(final, MeasureType.de);

            return new Length(goal.To(instance.type).value, instance.type);
        }

        public static Length operator /(int number, Length instance)
        {
            return instance / number;
        }

        //----------------------------------------
        // операции над другими измерениями
        // сложение двух длин  
        public static Length operator +(Length instance1, Length instance2)
        {
            int result = int.Parse(instance1.To(MeasureType.de).value) + int.Parse(instance2.To(MeasureType.de).value);
            Length goal = new Length(result.ToString(), MeasureType.de);
            return new Length(goal.To(instance1.type).value, instance1.type);
        }

        // вычитание двух длин
        public static Length operator -(Length instance1, Length instance2)
        {
            int result = int.Parse(instance1.To(MeasureType.de).value) - int.Parse(instance2.To(MeasureType.de).value);
            Length goal = new Length(result.ToString(), MeasureType.de);
            return new Length(goal.To(instance1.type).value, instance1.type);
        }

        public static Length operator *(Length instance1, Length instance2)
        {
            int result = int.Parse(instance1.To(MeasureType.de).value) * int.Parse(instance2.To(MeasureType.de).value);
            Length goal = new Length(result.ToString(), MeasureType.de);
            return new Length(goal.To(instance1.type).value, instance1.type);
        }

        // вычитание двух длин
        public static Length operator /(Length instance1, Length instance2)
        {
            int result = int.Parse(instance1.To(MeasureType.de).value) / int.Parse(instance2.To(MeasureType.de).value);
            Length goal = new Length(result.ToString(), MeasureType.de);
            return new Length(goal.To(instance1.type).value, instance1.type);
        }
    }
}
        