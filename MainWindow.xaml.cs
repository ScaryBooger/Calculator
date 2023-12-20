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

namespace WpfApp13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool operand = false;   //연산자 클릭된 직후
        private bool checked_eq  =false; // =연산 직후
        private bool checked_after = false; //루트 역수 수행 직후
        private string op = ""; //연산자
        private double num = 0; //루트 연산후 사칙연산에 대입할 변수
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_click(object sender, RoutedEventArgs e)
        {
           Button btn=sender as Button;

            if (textbox_input.Text == "0" || operand == true || checked_after == true )
            {
                textbox_input.Text = btn.Content.ToString();
                operand = false;  
                checked_after = false;
            }
            else
            {
                textbox_input.Text += btn.Content.ToString();

            }
            
            
        }
        private void btn_dot(object sender, RoutedEventArgs e) {

            if (textbox_input.Text.Contains("."))
            {
                return;

            }
            else {
                textbox_input.Text += ".";
            
            }
        
        }
        private void btn_plusminus(object sender, RoutedEventArgs e) { // 플러스 마이너스 부분

            if (double.Parse(textbox_input.Text) > 0 && textbox_input.Text!="0")
            {
                textbox_input.Text = "-" + textbox_input.Text;
            }
            else if (textbox_input.Text != "0")
            {
                textbox_input.Text = textbox_input.Text.Substring(1);
            }
        }
        private void btn_click_op(object sender, RoutedEventArgs e) //사칙연산 이벤트
        {
            Button btn = sender as Button;
            operand = true;
            op = btn.Content.ToString();

            if (textbox_result.Text == "" || checked_eq == true) 
            {
                textbox_result.Text = textbox_input.Text + btn.Content.ToString();
                checked_eq = false;
            }
            else if (textbox_result.Text.IndexOf(")") != -1) //루트,역수 다음 사칙연산 부분 
            {
                
                textbox_result.Text += op;
                num = double.Parse(textbox_input.Text);

            }
            else if (textbox_result.Text.IndexOf(op) == -1)     //부호만 바꾸기 
            {
                
                textbox_result.Text = textbox_result.Text.Substring(0, textbox_result.Text.Length - 1) + op;

            }
           
            else
            {
                

                switch (op)       
                {
                    case "+":
                        textbox_input.Text = Convert.ToString(Convert.ToDouble(textbox_result.Text.Substring(0, textbox_result.Text.Length - 1)) + Convert.ToDouble(textbox_input.Text));
                        textbox_result.Text = textbox_input.Text + "+";
                        break;

                    case "-":
                        textbox_input.Text = Convert.ToString(Convert.ToDouble(textbox_result.Text.Substring(0, textbox_result.Text.Length - 1)) - Convert.ToDouble(textbox_input.Text));
                        textbox_result.Text = textbox_input.Text + "-";
                        break;
                    case "*":

                        textbox_input.Text = Convert.ToString(Convert.ToDouble(textbox_result.Text.Substring(0, textbox_result.Text.Length - 1)) * Convert.ToDouble(textbox_input.Text));
                        textbox_result.Text = textbox_input.Text + "*";
                        break;
                    case "÷":


                        textbox_input.Text = Convert.ToString(Convert.ToDouble(textbox_result.Text.Substring(0, textbox_result.Text.Length - 1)) % Convert.ToDouble(textbox_input.Text));
                        textbox_result.Text = textbox_input.Text + "÷";
                        break;
                }
            }
        }
        private void btn_equal(object sender, RoutedEventArgs e)
        {
            string pre = "";
            checked_eq= true;
            if (num == 0)
            {
                switch (op) 
                {
                    case "+":
                        pre = textbox_result.Text + textbox_input.Text;
                        textbox_input.Text = Convert.ToString(Convert.ToDouble(textbox_result.Text.Substring(0, textbox_result.Text.Length - 1)) + Convert.ToDouble(textbox_input.Text));
                        textbox_result.Text = pre + "=";

                        break;

                    case "-":
                        pre = textbox_result.Text + textbox_input.Text;
                        textbox_input.Text = Convert.ToString(Convert.ToDouble(textbox_result.Text.Substring(0, textbox_result.Text.Length - 1)) - Convert.ToDouble(textbox_input.Text));
                        textbox_result.Text = pre + "=";
                        break;
                    case "*":
                        pre = textbox_result.Text + textbox_input.Text;
                        textbox_input.Text = Convert.ToString(Convert.ToDouble(textbox_result.Text.Substring(0, textbox_result.Text.Length - 1)) * Convert.ToDouble(textbox_input.Text));
                        textbox_result.Text = pre + "=";
                        break;
                    case "÷":

                        pre = textbox_result.Text + textbox_input.Text;
                        textbox_input.Text = Convert.ToString(Convert.ToDouble(textbox_result.Text.Substring(0, textbox_result.Text.Length - 1)) % Convert.ToDouble(textbox_input.Text));
                        textbox_result.Text = pre + "=";
                        break; ;
                }
            }

            else {
                 
                


                    switch (op)
                    {
                        case "+":
                            textbox_input.Text = Convert.ToString(num + Convert.ToDouble(textbox_input.Text));
                            textbox_result.Text = textbox_input.Text + "+";
                            num = 0;
                            break;

                        case "-":
                            textbox_input.Text = textbox_input.Text = Convert.ToString(num - Convert.ToDouble(textbox_input.Text));
                            textbox_result.Text = textbox_input.Text + "-";
                            num = 0;
                            break;
                        case "*":

                            textbox_input.Text = textbox_input.Text = Convert.ToString(num * Convert.ToDouble(textbox_input.Text));
                            textbox_result.Text = textbox_input.Text + "*";
                             num = 0;
                             break;
                        case "÷":


                            textbox_input.Text = textbox_input.Text = Convert.ToString(num / Convert.ToDouble(textbox_input.Text));
                            textbox_result.Text = textbox_input.Text + "÷";
                            num = 0;
                             break;
                    }



                }

           
            operand = true;

        }

        private void btn_click_sqrt(object sender, RoutedEventArgs e)
        {
            checked_after = true;
            textbox_result.Text = "√" + "("+textbox_input.Text + ")";
            textbox_input.Text = Convert.ToString(Math.Sqrt(double.Parse(textbox_input.Text)));

        }

        private void btn_click_sqr(object sender, RoutedEventArgs e)
        {
            checked_after = true;
            textbox_result.Text="sqr("+textbox_input.Text+")";
            textbox_input.Text= Convert.ToString(double.Parse(textbox_input.Text)*double.Parse(textbox_input.Text));

        }

        private void btn_click_recip(object sender, RoutedEventArgs e)
        {
            checked_after = true;
            textbox_result.Text="1/("+textbox_input.Text+")";
            textbox_input.Text=Convert.ToString(1/double.Parse(textbox_input.Text));
        }

        private void btn_click_clear(object sender, RoutedEventArgs e)
        {
            textbox_input.Text = "0";
        }

        private void btn_click_clearall(object sender, RoutedEventArgs e)
        {
            textbox_result.Text = "";
            textbox_input.Text = "0";
            op = "";
            operand = false;   //연산자 클릭된 직후
            checked_eq = false;
        }

        private void btn_click_back(object sender, RoutedEventArgs e)
        {
            if (textbox_input.Text.Length > 2)
            {
                textbox_input.Text = textbox_input.Text.Remove(textbox_input.Text.Length - 1);
            }
            else {
                textbox_input.Text = "0";
            }
        }

        private void btn_click_percent(object sender, RoutedEventArgs e)
        {   
           
            textbox_input.Text= Convert.ToString(double.Parse(textbox_input.Text)*0.01);
           

            
        }
    }
}
