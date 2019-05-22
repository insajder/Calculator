using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public delegate float FloatOperation(float val1, float val2);

        public Form1()
        {
            InitializeComponent();
        }

        float num, ans;
        int count;

        private void btn1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cannot divide by zero")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 1;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cannot divide by zero")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 2;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cannot divide by zero")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 3;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cannot divide by zero")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 4;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cannot divide by zero")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 5;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cannot divide by zero")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 6;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cannot divide by zero")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 7;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cannot divide by zero")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 8;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cannot divide by zero")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 9;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cannot divide by zero")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 0;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cannot divide by zero")
                textBox1.Text = "";
            if (textBox1.Text != string.Empty)
            {
                    float n;
                    if (float.TryParse(textBox1.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out n))
                    {
                        num = float.Parse(textBox1.Text);
                        textBox1.Clear();
                        textBox1.Focus();
                        count = 1;
                        history.Text = num.ToString(CultureInfo.InvariantCulture) + "+";
                    }
                    else
                    {
                        history.Text = history.Text.Substring(0, history.Text.Length - 1);
                        history.Text += "+";
                    }
                
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cannot divide by zero")
                textBox1.Text = "";
            if (textBox1.Text != string.Empty)
            {
                float n;
                if (float.TryParse(textBox1.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out n))
                {
                    num = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    textBox1.Focus();
                    count = 2;
                    history.Text = num.ToString(CultureInfo.InvariantCulture) + "-";
                }
                else
                {
                    history.Text = history.Text.Substring(0, history.Text.Length - 1);
                    history.Text += "-";
                }
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cannot divide by zero")
                textBox1.Text = "";
            if (textBox1.Text != string.Empty)
            {
                float n;
                if (float.TryParse(textBox1.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out n))
                {
                    num = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    textBox1.Focus();
                    count = 3;
                    history.Text = num.ToString(CultureInfo.InvariantCulture) + "*";
                }
                else
                {
                    history.Text = history.Text.Substring(0, history.Text.Length - 1);
                    history.Text += "*";
                }
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cannot divide by zero")
                textBox1.Text = "";
            if (textBox1.Text != string.Empty)
            {
                float n;
                if (float.TryParse(textBox1.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out n))
                {
                    num = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    textBox1.Focus();
                    count = 4;
                    history.Text = num.ToString(CultureInfo.InvariantCulture) + "/";
                }
                else
                {
                    history.Text = history.Text.Substring(0, history.Text.Length - 1);
                    history.Text += "/";
                }
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cannot divide by zero")
                textBox1.Text = "";
            if (!textBox1.Text.Contains("."))
            {
                textBox1.Text = textBox1.Text + ".";
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (history.Text != string.Empty)
            {
                if (textBox1.Text != string.Empty)
                {
                    float n;
                    if (float.TryParse(textBox1.Text, out n))
                    {
                        Compute();
                        if (textBox1.Text != "Cannot divide by zero")
                        {
                            textBox1.Text = num.ToString(CultureInfo.InvariantCulture);
                            num = ans;
                            history.Text = "";
                        }
                        history.Text = "";
                    }
                }
            }
        }

        FloatOperation[] operations = {
          MathOperation.Add,
          MathOperation.Subtract,
          MathOperation.Multyply,
          MathOperation.Divide
        };

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            history.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }

        public void Compute()
        {
            float num2;
            if (float.TryParse(textBox1.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out num2))
            {
                if (count == 4 && num2 == 0)
                    textBox1.Text = "Cannot divide by zero";
                else
                {
                    //num = operations[count - 1](num, num2);
                    switch (count)
                    {
                        case 1:
                            FloatOperation o1 = new FloatOperation(MathOperation.Add);
                            ans = o1(num, float.Parse(textBox1.Text));
                            textBox1.Text = (ans).ToString();
                            num = ans;
                            history.Text = ans.ToString();
                            break;
                        case 2:
                            FloatOperation o2 = new FloatOperation(MathOperation.Subtract);
                            ans = o2(num, float.Parse(textBox1.Text));
                            textBox1.Text = (ans).ToString();
                            num = ans;
                            break;
                        case 3:
                            FloatOperation o3 = new FloatOperation(MathOperation.Multyply);
                            ans = o3(num, float.Parse(textBox1.Text));
                            textBox1.Text = (ans).ToString();
                            num = ans;
                            break;
                        case 4:
                            if (ans == 0)
                            {
                                textBox1.Text = "Cannot divide by zero";
                            }
                            else
                            {
                                FloatOperation o4 = new FloatOperation(MathOperation.Divide);
                                ans = o4(num, float.Parse(textBox1.Text));
                                textBox1.Text = (ans).ToString();
                                num = ans;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
