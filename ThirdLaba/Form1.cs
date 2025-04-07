namespace ThirdLaba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var measureItems = new string[]
            {
            "(2)",
            "(8)",
            "(10)",
            "(16)",
            };

            comboBoxFirst.DataSource = new List<string>(measureItems);
            comboBoxSecond.DataSource = new List<string>(measureItems);
            comboBoxThird.DataSource = new List<string>(measureItems);
        }

        private MeasureType GetMeasureType(ComboBox comboBox)
        {
            MeasureType measureType;
            switch (comboBox.Text)
            {
                case "(10)":
                    measureType = MeasureType.de;
                    break;
                case "(2)":
                    measureType = MeasureType.bi;
                    break;
                case "(8)":
                    measureType = MeasureType.oc;
                    break;
                case "(16)":
                    measureType = MeasureType.he;
                    break;
                default:
                    measureType = MeasureType.de;
                    break;
            }
            return measureType;
        }

        private void Calculate()
        {
            try
            {
                string firstValue = textFirst.Text;
                string secondValue = textSecond.Text;


                MeasureType firstType = GetMeasureType(comboBoxFirst);
                MeasureType secondType = GetMeasureType(comboBoxSecond);
                MeasureType resultType = GetMeasureType(comboBoxThird);
                
                var firstLength = new Length(firstValue, firstType);
                var secondLength = new Length(secondValue, secondType);

                Length sumLength;

                switch (comboBox1.Text)
                {
                    case "+":
                        sumLength = firstLength + secondLength;
                        break;
                    case "-":
                        sumLength = firstLength - secondLength;
                        break;
                    case "*":
                        sumLength = firstLength * secondLength;
                        break;
                    case "/":
                        sumLength = firstLength / secondLength;
                        break;
                    default:
                        sumLength = new Length("0", MeasureType.de);
                        break;
                }

                //textThird.Text = sumLength.To(resultType).Verbose().ToString();
                textThird.Text = sumLength.To(resultType).GetValue().ToString();
            }
            catch (FormatException)
            {
                textThird.Text = "Не посчиталось ;)";
            }
        }

        private void onValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}
