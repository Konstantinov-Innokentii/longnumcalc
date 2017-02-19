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
            tb_console_one.Focus();
        }
        private void button_0_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length < 84)
                tb_console_one.Text = tb_console_one.Text + "0";
        }

        private void button_1_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length < 84)
                tb_console_one.Text = tb_console_one.Text + "1";
            
        }

        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length < 84)
                tb_console_one.Text = tb_console_one.Text + "2";
        }

        private void button_3_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length < 84)
                tb_console_one.Text = tb_console_one.Text + "3";
        }

        private void button_4_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length < 84)
                tb_console_one.Text = tb_console_one.Text + "4";
        }

        private void button_5_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length < 84)
                tb_console_one.Text = tb_console_one.Text + "5";
        }

        private void button_6_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length < 84)
                tb_console_one.Text = tb_console_one.Text + "6";
        }

        private void button_7_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length < 84)
                tb_console_one.Text = tb_console_one.Text + "7";
        }

        private void button_8_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length < 84)
                tb_console_one.Text = tb_console_one.Text + "8";
        }

        private void button_9_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length < 84)
                tb_console_one.Text = tb_console_one.Text + "9";
        }
        private void button_minus_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length < 84)
                tb_console_one.Text = tb_console_one.Text + "-";
        }

        private void button_mult_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length < 84)
                tb_console_one.Text = tb_console_one.Text + "*";
        }

        private void button_div_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length < 84)
                tb_console_one.Text = tb_console_one.Text + "/";
        }

        private void button_rightbrace_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length < 84)
                tb_console_one.Text = tb_console_one.Text + ")";
        }
        private void button_plus_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length < 84)
                tb_console_one.Text = tb_console_one.Text + "+";
        }

        private void button_leftbrace_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length < 84)
                tb_console_one.Text = tb_console_one.Text + "(";
        }

        private void button_res_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                string input = tb_console_one.Text;

                if (input != String.Empty)
                {

                    tb_console_one.Text = ReversePolishNotation.PerformCalculations(input).ToString();
                    tb_console_two.Text = input + "=";
                    tb_console_one.Focus();
                }
            }
            catch (FormatException ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Неверный ввод: ");
                sb.Append(ex.Message);
                MessageBox.Show(sb.ToString(), "Warning");
                tb_console_one.Focus();
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Деление на ноль", "Warning");
                tb_console_one.Focus();
            }
        }

        private void button_del_Click(object sender, RoutedEventArgs e)
        {
            if (tb_console_one.Text.Length!=0)
            {
                tb_console_one.Text = tb_console_one.Text.Substring(0, tb_console_one.Text.Length - 1);
            }
        }

        private void button1_delall_Click(object sender, RoutedEventArgs e)
        {
            tb_console_one.Text = "";
            tb_console_two.Text = "";
        }

        private  void tb_console_one_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled= "0123456789+-*/() ".IndexOf(e.Text) < 0;
        }

        private void tb_console_one_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Space)//запрет ввода пробела
            {
                e.Handled = true;
            }
            if (e.Key==Key.Enter)
            {
                try
                {

                    string input = tb_console_one.Text;

                    if (input != String.Empty)
                    {
                      
                        tb_console_one.Text = ReversePolishNotation.PerformCalculations(input).ToString();
                        tb_console_two.Text = input + "=";
                        tb_console_one.Focus();
                    }
                }
                catch (FormatException ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Неверный ввод: ");
                    sb.Append(ex.Message);
                    MessageBox.Show(sb.ToString(), "Warning");
                    tb_console_one.Focus();
                }
                catch (DivideByZeroException)
                {
                    MessageBox.Show("Деление на ноль", "Warning");
                    tb_console_one.Focus();
                }
            }
        }
        private void button_reference_Click(object sender, RoutedEventArgs e)
        {
            string message;
            message = "Отрицательные числа вводятся в скобках.\nПри целочисленном делении остаток отбрасывается.";
            MessageBox.Show(message,"Справка");
        }

    }
    ///  Класс, реализующий перевод входного выражения в рпн и вычисление его значения
    public class ReversePolishNotation
    {
        static private bool IsOperatorNotBrace(char c) 
        {
            if (("+-/*".IndexOf(c) != -1))
                return true;
            return false;
        }

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

        static public void CheckInput(string input) // метод реализующий проверку корректности входного выражения
        {
            
            if (!IsOperator(input[input.Length-1]) && !Char.IsDigit(input[input.Length-1]))
            {
                throw new FormatException("Неверный символ");
            }
            if (IsOperatorNotBrace(input[0]) || IsOperatorNotBrace(input[input.Length - 1])) // если или последний символы-операторы но не скобки
            {
                throw new FormatException("Неверная расстановка операторов");
            }
           
            Stack<char> s = new Stack<char>();
            for (int i = 0; i < input.Length - 1; i++)
            {

                if (!IsOperator(input[i]) && !Char.IsDigit(input[i])) 
                {
                    throw new FormatException("Недопустимый символ");
                }
                if (IsOperatorNotBrace(input[i]) && IsOperatorNotBrace(input[i + 1])) //если два оператора, но не скобки, идут подряд
                {
                    throw new FormatException("Неверная расстановка операторов");
                }

                if (input[i] == '(' && (input[i + 1] != '-' && !Char.IsDigit(input[i + 1]) && input[i + 1] != '(')) 
                {
                    throw new FormatException("Неверная расстановка операторов");
                }
                if (input[i]==')' && input[i+1]=='(')
                { 
                    throw new FormatException("Неверная расстановка скобок");
                }
                if (input[i+1]=='(' && input[i]==')')
                {
                    throw new FormatException("Неверная расстановка скобок");
                }
                if (input[i] == '-' && input[i + 1] == ')')
                {
                    throw new FormatException("Неверная расстановка операторов");
                }
                if ((input[i] == ')' && !IsOperator(input[i + 1])))
                {
                    throw new FormatException("Неверная расстановка операторов");
                }
                if ((input[i+1]=='(') && !IsOperator(input[i]))
                {
                    throw new FormatException("Неверная расстановка операторов"); //??
                }

            }
            int j = 0;
            while (j < input.Length)
            {
                if (input[j] == '(')
                {
                    s.Push(input[j]);
                }
                if (input[j] == ')')
                {
                    if (s.Count == 0)
                    {
                        throw new FormatException("Неверная расстановка скобок");
                    }
                    else
                    {
                        s.Pop();
                    }
                }
                j++;
            }
            if (s.Count != 0)
            {
                throw new FormatException("Неверная расстановка скобок");
            }

        }

        static public BigInt PerformCalculations(string input) 
        {
            CheckInput(input);
            string output = GetExpression(input); 
            BigInt result = CalculationRpn(output); 
            return result;
        }
        static private string GetExpression(string input)
        {
            input = input.Replace(" ", String.Empty);
            string output = string.Empty; 
            Stack<char> operStack = new Stack<char>(); 
            for (int i = 0; i < input.Length; i++) 
            {
                //Если символ -цифра-считываю число
                if (Char.IsDigit(input[i])) 
                {   //!IsDelimeter(input[i]) &&
                    //Считывание до оператора
                    while ( !IsOperator(input[i]))
                    {
                        output += input[i]; //Запись числа в строку
                        i++; //К след символу
                        if (i == input.Length)
                            break; //Если символ - последний, то выход из цикла
                    }
                    output += " "; //Пробел после числа в выходной строке
                    i--; //Возвращаемся на один символ назад, к символу перед разделителем(предотвращение выхода индекса за пределы массива)
                }
                //Если символ - оператор
                if (IsOperator(input[i])) //Если оператор
                {
                    if (operStack.Count != 0)
                    {
                        //реализация унарного минуса
                        if (input[i] == '-' && operStack.Peek() == '('  && !Char.IsDigit(input[i - 1])) // HACK : for correct work with x*(y-y) types
                        {
                            operStack.Push('!');
                            continue;
                        }
                    }
                    if (input[i] == '(') 
                        operStack.Push(input[i]); //Запись в стек
                    else if (input[i] == ')') //Если символ - закрывающая скобка
                    {
                        //Выбрасываю все операторы до открывающей скобки в строку
                        char s = operStack.Pop();
                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else //Если любой другой оператор
                    {
                        if (operStack.Count > 0)//Если в стеке есть элементы
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek())) //Если приоритет  оператора меньше или равен приоритету оператора на вершине стека
                                output += operStack.Pop().ToString() + " "; //То добавляем последний оператор из стека в строку с выражением
                        operStack.Push(char.Parse(input[i].ToString())); //Если стек пуст, или  приоритет оператора выше - добавляем операторов на вершину стека
                    }
                }
            }
            //выбрасываю из стека все  операторы в строку
            while (operStack.Count > 0)
            {
                output += operStack.Pop() + " ";
            }
            return output;
        }
        static private BigInt CalculationRpn(string input)
        {
            BigInt result = new BigInt();
            Stack<BigInt> temp = new Stack<BigInt>(); // стек для решения
            for (int i = 0; i < input.Length; i++) // иду по строке
            {
                //Если символ - цифра, то читаю все число и записываю на вершину стека
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i])) 
                    {
                        a += input[i]; //Добавляем
                        i++;
                        if (i == input.Length)
                        {
                            break;
                        }
                    }
                    BigInt A = new BigInt(a);
                    temp.Push(A); //Записываем в стек
                    i--;
                }
                if (input[i] == '!')// вычисления для унарного минуса
                {
                    BigInt a = temp.Pop();
                    a.ChangeSign();
                    result = a;
                    temp.Push(result);
                }
                else if (IsOperator(input[i]) && input[i] != '!') //Если символ - оператор (кроме унарного минуса)
                {
                    //Берем два последних значения из стека
                    BigInt a = temp.Pop();
                    BigInt b = temp.Pop();
                    switch (input[i]) //И производим над ними действие, согласно оператору
                    {
                        case '+':
                            result = BigInt.Addition(b, a);
                            break;
                        case '-':
                            result = BigInt.Substraction(b, a);
                            break;
                        case '*':
                            result = BigInt.Multiplication(b, a);
                            break;
                        case '/':
                            result = BigInt.Division(b, a);
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
            if (string_values[0] == '-') // реализация считывания отрицательного числа
            {
                sign = false;
                string_values = string_values.Remove(0, 1);
            }
            
            for (int i = string_values.Length - 1; i >= 0; i--) //запись в представление длинного числа
            {
                values.Add(int.Parse(string_values[i].ToString()));
            }
            //удаление лидирующих нулей (ввод 00x)
            int k = this.values.Count - 1;
            while (this.values[k] == 0)
            {
               if (k == 0)
               {
                   break;
               }
               this.values.RemoveAt(k);
               k--;

            }
        }
        public BigInt()
        {

        }
        public override string ToString()
        {
            //HACK: удаление лишних нулей
            if (this.values.Count > 0)
            {
                int k = this.values.Count - 1;
                while (this.values[k] == 0)
                {
                    if (k == 0)
                    {
                        break;
                    }
                    this.values.RemoveAt(k);
                    k--;

                }
            }
            StringBuilder sb = new StringBuilder();
            if (sign == false) //реализация корректного вывода отрицательного числа
            {
                sb.Append("(");
                sb.Append("-");
            }
            for (int i = values.Count - 1; i >= 0; i--)
            {
                sb.Append(values[i]);
            }
            if (sign == false)
            {
                sb.Append(")");
            }

            return sb.ToString();
        }
        public void ChangeSign() //смена знака на противоположный
        {
            if (sign == true)
            {
                sign = false;
                return;
            }
            if (sign == false)
            {
                sign = true;
                return;
            }
        }
        public void ChangeSign(bool sign) //смена знака на заданный
        {
            this.sign = sign;
        }

        public int CompareTo(BigInt other)
        {
            if (this.sign && other.sign)//оба положительных
            {
                return AbsCompareTo(other);
            }
            if (this.sign && !other.sign)//первое число положительное
            {
                return 1;
            }
            if (!this.sign && other.sign)//второе число положительное
            {
                return -1;
            }
            return -1 * AbsCompareTo(other);

        }
        private int AbsCompareTo(BigInt other)
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
        public static BigInt Addition(BigInt A, BigInt B)
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
            if (!A.sign && !B.sign)
            {
                result = BigInt.AbsAddition(A, B);
                result.ChangeSign();
            }

            return result;
        }
        public static BigInt Substraction(BigInt A, BigInt B)
        {
            BigInt result = new BigInt();
            if (A.sign && B.sign)
            {
                result = BigInt.AbsSubstraction(A, B);
            }
            if (!A.sign && B.sign)
            {
                result = BigInt.AbsAddition(A, B);
                result.ChangeSign();
            }
            if (A.sign && !B.sign)
            {
                result = BigInt.AbsAddition(A, B);
            }
            if (!A.sign && !B.sign)
            {
                result = BigInt.AbsSubstraction(B, A);
            }

            return result;
        }
        private static BigInt AbsAddition(BigInt A, BigInt B)
        {
            int temp = 0;
            BigInt result = new BigInt();
            int counter = A.values.Count <= B.values.Count ? A.values.Count : B.values.Count; // кол-во итераций для сложения (меньшее)
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
            //запись оставшихся разрядов в результат
            if (A.values.Count == B.values.Count && temp != 0)
            {
                result.values.Add(temp);
            }
            if (A.values.Count > B.values.Count)
            {
                for (int i = counter; i < A.values.Count; i++)//<=
                {
                   
                    temp = temp + A.values[i];
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
                result.values.Add(temp);
            }
            if (B.values.Count > A.values.Count)
            {
                for (int i = counter; i < B.values.Count; i++)
                {
                    temp = temp + B.values[i];
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
                result.values.Add(temp);

            }
            return result;
        }
        private static BigInt AbsSubstraction(BigInt A, BigInt B)
        {
            BigInt result = new BigInt();

            if (A.AbsCompareTo(B) == 0)
            {
                result.values.Add(0);
            }
            if (A.AbsCompareTo(B) == 1)
            {

                int temp = 0;

                while (B.values.Count < A.values.Count) //дополнение более короткого числа нулями
                {
                    B.values.Add(0);
                }
                for (int i = 0; i < A.values.Count; i++)
                {
                    result.values.Add(A.values[i] - B.values[i] - temp);
                    if (result.values[i] < 0)
                    {
                        result.values[i] += 10; //заеи из соседнего разряда
                        temp = 1;
                    }
                    else
                    {
                        temp = 0;
                    }
                }
                // HACK: удаление лишних нулей из результата
                if (result.values.Count > 0)
                {
                    int k = result.values.Count - 1;
                    while (result.values[k] == 0)
                    {
                        result.values.RemoveAt(k);
                        k--;
                    }
                }
            }
            if (A.AbsCompareTo(B) == -1) 
            {
                result = BigInt.AbsSubstraction(B, A);
                result.ChangeSign();
            }
            // HACK: удаление лишних нулей из вычитаемоего 
            if (B.values.Count > 0)
            {
                int k = B.values.Count - 1;
                while (B.values[k] == 0)
                {
                    if (k == 0)
                    {
                        break;
                    }
                    B.values.RemoveAt(k);
                    k--;

                }
            }
            return result;

        }
        public static BigInt Multiplication(BigInt A, int b)
        {
            BigInt result = new BigInt();
            if ((A.sign && b >= 0) || (!A.sign && b < 0))
            {
                result.sign = true;
            }
            else
            {
                result.sign = false;
            }
            b = Math.Abs(b);
            int temp = 0;
            for (int i = 0; i < A.values.Count; i++)
            {
                temp = A.values[i] * b + temp;
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
            if (temp != 0)
            {
                result.values.Add(temp);
            }
            return result;
        }
        public static BigInt Multiplication(BigInt A, BigInt B)
        {
            bool new_sign;
            if ((A.sign && B.sign) || (!A.sign && !B.sign))
            {
                new_sign = true;
            }
            else
            {
                new_sign = false;
            }
            A.ChangeSign(true);
            B.ChangeSign(true);
            BigInt result = new BigInt();

            for (int i = 0; i < A.values.Count; i++)
            {
                BigInt temp = BigInt.Multiplication(B, A.values[i]);//умножаем текущий разряд числа на другое длинное число
                for (int j = 0; j < i; j++)//сдвигаем его
                {
                    temp.values.Insert(0, 0);
                }
                result = BigInt.Addition(result, temp);//складываем с другими
            }
            if (result.values.Count > 0)
            {
                int k = result.values.Count - 1;
                while (result.values[k] == 0) //удаление возможных лишних нулей
                {
                    if (k == 0)
                    {
                        result.ChangeSign(true);
                        break;
                    }
                    result.values.RemoveAt(k);
                    k--;
                }
            }
            result.ChangeSign(new_sign);
            return result;
        }
        public static BigInt Division(BigInt A, BigInt B)
        {
            BigInt zero = new BigInt("0");
            if (B.CompareTo(zero) == 0)
            {
                throw new DivideByZeroException("Division by zero");
            }
            bool new_sign;
            if ((A.sign && B.sign) || (!A.sign && !B.sign))
            {
                new_sign = true;
            }
            else
            {
                new_sign = false;
            }
            A.ChangeSign(true);
            B.ChangeSign(true);
            BigInt temp = new BigInt();
            BigInt res = new BigInt();
            while (res.values.Count < A.values.Count)
            {
                res.values.Add(0);
            }

            int i = A.values.Count - 1;
            while (i >= 0)
            {

                temp.values.Insert(0, A.values[i]);
                // HACK: удаление лишних нулей из temp
                if (temp.values.Count > 0)
                {
                    int k = temp.values.Count - 1;
                    while (temp.values[k] == 0)
                    {
                        if (k == 0)
                        {
                            break;
                        }
                        temp.values.RemoveAt(k);
                        k--;
                    }
                }
                while (temp.CompareTo(B) >= 0)
                {
                    temp = BigInt.Substraction(temp, B);
                    res.values[i]++;
                }
                if (temp.CompareTo(B) == -1)
                {
                    i--;
                }
            }
            res.ChangeSign(new_sign);
            // HACK: удаление лишних нулей из res
            if (res.values.Count > 0)
            {
                int k = res.values.Count - 1;
                while (res.values[k] == 0)
                {
                    if (k == 0)
                    {
                        res.ChangeSign(true);
                        break;
                    }
                    res.values.RemoveAt(k);
                    k--;
                }
            }
            return res;
        }
    }
}

   

