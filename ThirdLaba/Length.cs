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

        // Измерения
        public Length To(MeasureType newType)
        {
            // по умолчанию новое значение совпадает со старым
            var newValue = this.value;
            // если текущий тип -- это метр
            if (this.type == MeasureType.de)
            {
                // а теперь рассматриваем все другие ситуации
                switch (newType)
                {
                    // если конвертим в метр, то значение не меняем
                    case MeasureType.de:
                        newValue = this.value;
                        break;
                    // если в км.
                    /*case MeasureType.bi:
                        newValue = this.value / 1000;
                        break;
                    // если в  а.е.
                    case MeasureType.oc:
                        newValue = this.value / 149597870700;
                        break;
                    // если в парсек
                    case MeasureType.he:
                        newValue = this.value / (3.0856776 * Math.Pow(10, 16));
                        break;*/
                }
            }
            else if (newType == MeasureType.de) // если новый тип: метр
            {
                switch (this.type) // а тут уже старый тип проверяем
                {
                    case MeasureType.de:
                        newValue = this.value;
                        break;
                    /*case MeasureType.km:
                        newValue = this.value * 1000; // кстати это то же код что и выше, только / заменили на *
                        break;
                    case MeasureType.au:
                        newValue = this.value * 149597870700; // и тут / на *
                        break;
                    case MeasureType.ps:
                        newValue = this.value * (3.0856776 * Math.Pow(10, 16)); // и даже тут, просто / на *
                        break;*/
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
        /*public static Length operator +(Length instance, double number)
        {
            return new Length(instance.value + number, instance.type);
        }

        public static Length operator +(double number, Length instance)
        {
            return instance + number;
        }

        // умножение
        public static Length operator *(Length instance, double number)
        {
            return new Length(instance.value * number, instance.type); 
        }

        public static Length operator *(double number, Length instance)
        {
            return instance * number;
        }

        // вычитание
        public static Length operator -(Length instance, double number)
        {
            return new Length(instance.value - number, instance.type); 
        }

        public static Length operator -(double number, Length instance)
        {
            return instance - number;
        }

        // деление
        public static Length operator /(Length instance, double number)
        {
            return new Length(instance.value / number, instance.type); 
        }

        public static Length operator /(double number, Length instance)
        {
            return instance / number;
        }*/
    }
}
