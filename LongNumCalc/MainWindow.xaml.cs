using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LongNumCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_0_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + "0";
        }
        private void button_1_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + "1";
        }

        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + "2";
        }

        private void button_3_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + "3";
        }

        private void button_4_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + "4";
        }

        private void button_5_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + "5";
        }

        private void button_6_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + "6";
        }

        private void button_7_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + "7";
        }

        private void button_8_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + "8";
        }

        private void button_9_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + "9";
        }

        private void button_dot_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + ".";
        }

        private void button_minus_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + "-";
        }

        private void button_mult_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + "*";
        }

        private void button_div_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + "/";
        }

        private void button_rightbrace_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + ")";
        }

        private void button_plus_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + "+";
        }

        private void button_leftbrace_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = tb_console_one.Text + "(";
        }

        private void button_res_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string various = tb_console_one.Text;
                tb_console_one.Text = ReversePolishNotation.Calculate(various).ToString();
                tb_console_two.Text = various;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid values");
                tb_console_one.Text = "";
                tb_console_two.Text = "";

            }
        }
    }
    public class ReversePolishNotation
    {
        //Метод возвращает true, если проверяемый символ - разделитель ("пробел" или "равно")
        static private bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }
        static private bool IsOperator(char с)
        {
            if (("+-/*()".IndexOf(с) != -1))
                return true;
            return false;
        }
        static private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '!': return 5;
                default: return 6;
            }
        }

        static public double Calculate(string input)
        {
            string output = GetExpression(input); //Преобразовыние выражения в постфиксную запись
            double result = CalculationRpn(output); //Вычисление значения в рпн
            return result;
        }
        static private string GetExpression(string input)
        {
            int operator_count = 0;
            string output = string.Empty; //Строка для хранения выражения
            Stack<char> operStack = new Stack<char>(); //Стек для хранения операторов

            for (int i = 0; i < input.Length; i++) //Для каждого символа в входной строке
            {
                if (Char.IsLetter(input[i]))
                {
                    throw new FormatException();
                }
                //Разделители пропускаем
                if (IsDelimeter(input[i]))
                    continue; //Переходим к следующему символу

                //Если символ - цифра, то считываем все число
                if (Char.IsDigit(input[i])) //Если цифра
                {
                    //Читаем до разделителя или оператора, что бы получить число
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i]; //Добавляем каждую цифру числа к нашей строке
                        i++; //Переходим к следующему символу

                        if (i == input.Length) break; //Если символ - последний, то выходим из цикла
                    }

                    output += " "; //Дописываем после числа пробел в строку с выражением
                    i--; //Возвращаемся на один символ назад, к символу перед разделителем
                }

                //Если символ - оператор
                if (IsOperator(input[i])) //Если оператор
                {

                    if (operStack.Count != 0)
                    {
                        if (input[i] == '-' && operStack.Peek() == '(')
                        {
                            operStack.Push('!');
                            continue;
                        }
                    }
                    if (input[i] == '(') //Если символ - открывающая скобка
                        operStack.Push(input[i]); //Записываем её в стек
                    else if (input[i] == ')') //Если символ - закрывающая скобка
                    {
                        //Выписываем все операторы до открывающей скобки в строку
                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else //Если любой другой оператор
                    {
                        if (operStack.Count > 0)
                        //Если в стеке есть элементы
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek())) //И если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                            
                                output += operStack.Pop().ToString() + " "; //То добавляем последний оператор из стека в строку с выражением
                            
                        
                        operStack.Push(char.Parse(input[i].ToString())); //Если стек пуст, или же приоритет оператора выше - добавляем операторов на вершину стека

                    }
                }
            }

            //Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку
            while (operStack.Count > 0)
            {
                output += operStack.Pop() + " ";
            }

            return output; //Возвращаем выражение в постфиксной записи
        }
        static private double CalculationRpn(string input)
        {
            double result = 0;
            Stack<double> temp = new Stack<double>(); // стек для решения

            for (int i = 0; i < input.Length; i++) // иду по строке
            {
                //Если символ - цифра, то читаем все число и записываем на вершину стека
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i])) //Пока не разделитель
                    {
                        a += input[i]; //Добавляем
                        i++;

                        if (i == input.Length)
                        {
                            break;
                        }
                    }
                    temp.Push(double.Parse(a)); //Записываем в стек
                    i--;
                }
                if (input[i] == '!')// вычисления для унарного минуса
                {
                    double a = temp.Pop();
                    result = a * (-1);
                    temp.Push(result);
                }
                else if (IsOperator(input[i]) && input[i] != '!') //Если символ - оператор (кроме унарного минуса)
                {

                    //Берем два последних значения из стека
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (input[i]) //И производим над ними действие, согласно оператору
                    {
                        case '+': result = b + a;
                        break;
                        case '-': result = b - a;
                        break;
                        case '*': result = b * a;
                        break;
                        case '/': result = b / a;
                        break;
                    }
                    temp.Push(result); //Результат вычисления записываем обратно в стек
                }
            }
            return temp.Peek(); //Забираем результат всех вычислений из стека и возвращаем его
        }
    }
    public class BigInt
    {
        private List<int> values = new List<int>();
        private bool sign = true;
        public BigInt(string string_values)
        {
            if (string_values[0] == '-')
            {
                sign = false;
                string_values = string_values.Remove(0, 1);
            }

            for (int i = string_values.Length - 1; i >= 0; i--)
            {
                values.Add(int.Parse(string_values[i].ToString()));
            }
        }
        public BigInt()
        {

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (sign == false)
            {
                sb.Append("-");
            }
            for (int i = values.Count - 1; i >= 0; i--)
            {
                sb.Append(values[i]);
            }

            return sb.ToString();
        }
        public void SetNegative(BigInt A)
        {
            if (A.sign == true)
                A.sign = false;
            if (A.sign == false)
                A.sign = true;
        }
        public int CompareTo(BigInt other)
        {
            int ans = 0;
            if (this.values.Count == other.values.Count)
            {

                for (int i = this.values.Count - 1; i >= 0; i--)
                {
                    if (this.values[i] > other.values[i])
                    {
                        return ans = 1;
                    }

                    if (this.values[i] < other.values[i])
                    {
                        return ans = -1;
                    }

                }
            }
            else
            {
                if (this.values.Count > other.values.Count)
                {
                    ans = 1;
                }
                if (this.values.Count < other.values.Count)
                {
                    ans = -1;
                }
            }
            return ans;
        }
        public static BigInt Addition (BigInt A, BigInt B)
        {
            BigInt result = new BigInt();
            if (A.sign && B.sign)
            {
                result = BigInt.AbsAddition(A, B);
            }
            if (!A.sign && B.sign)
            {
                result = BigInt.AbsSubstraction(B, A);
            }
            if (A.sign && !B.sign)
            {
                result = BigInt.AbsSubstraction(A, B);
            }
            else
            {

            }
            return result;
        }
        private static BigInt AbsAddition(BigInt A, BigInt B)
        {
            int temp = 0;
            BigInt result = new BigInt();
            int counter = A.values.Count <= B.values.Count ? A.values.Count : B.values.Count;
            for (int i = 0; i < counter; i++)
            {
                temp = A.values[i] + B.values[i] + temp;
                if (temp > 9)
                {
                    result.values.Add(temp % 10);
                    temp = temp / 10;
                }
                else
                {
                    result.values.Add(temp);
                    temp = 0;
                }
            }
            if (A.values.Count == B.values.Count && temp != 0)
            {
                result.values.Add(temp);
            }
            if (A.values.Count > B.values.Count)
            {
                for (int i = counter; i < A.values.Count; i++)
                {
                    if (i == counter)
                    {
                        result.values.Add(temp + A.values[i]);
                    }
                    else
                    {
                        result.values.Add(A.values[i]);
                    }
                }
            }
            if (B.values.Count > A.values.Count)
            {
                for (int i = counter; i < B.values.Count; i++)
                {
                    if (i == counter)
                    {
                        result.values.Add(temp + B.values[i]);
                    }
                    else
                    {
                        result.values.Add(B.values[i]);
                    }
                }
            }
            return result;
        }
        public static BigInt AbsSubstraction(BigInt A, BigInt B)
        {
            BigInt result = new BigInt();

            if (A.CompareTo(B) == 0)
            {
                result.values.Add(0);
                return result;
            }

            int temp = 0;

            while (B.values.Count < A.values.Count)
            {
                B.values.Add(0);
            }


            for (int i = 0; i < A.values.Count; i++)
            {
                result.values.Add(A.values[i] - B.values[i] - temp);
                if (result.values[i] < 0)
                {
                    result.values[i] += 10;
                    temp = 1;
                }
                else
                {
                    temp = 0;
                }
            }
            if (result.values.Count > 0)
            {
                int k = result.values.Count - 1;
                while (result.values[k] == 0)
                {
                    result.values.RemoveAt(k);
                    k--;

                }
            }


            return result;

        }
    }
   
}
