using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace actual_snake_race
{
    public partial class Form1 : Form
    {
        Brush body = new SolidBrush(Color.Green);
        Brush head = new SolidBrush(Color.DarkGreen);
        Brush checker1 = new SolidBrush(Color.White);
        Brush checker2 = new SolidBrush(Color.Black);
        Graphics paper;
        Random rand = new Random();
        int counter = 0;
        int gamble = 0;
        int money = 100;
        int gambleamount = 0;
        int[] snakepos;

        public Form1()
        {
            InitializeComponent();
            paper = pictureBox1.CreateGraphics();
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            if (gamble == 0)
            {
                MessageBox.Show("eerst gamblen 🤑🤑🤑🤑🤑🤑");
                return;
            }
            timer1.Start();

            draw();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;

            if (counter >= 50)
            {
                int index = rand.Next(0, Convert.ToInt32(textBox3.Text));

                snakepos[index] -= 55;

                draw();
                counter = 0;

                for (int i = 0; i < Convert.ToInt32(textBox3.Text); i++)
                {
                    if (snakepos[i] <= -55 * 9)
                    {
                        timer1.Stop();

                        if (i + 1 == gamble)
                        {
                            MessageBox.Show("Snake " + (i + 1) + " wins!, you win ");
                            money += gambleamount * 2;
                        }
                        else
                        {
                            MessageBox.Show("Snake " + (i + 1) + " wins!, you lose");
                        }
                        gamble = 0;
                        gambleamount = 0;

                        if (money == 0)
                        {
                            MessageBox.Show("you are broke, you lose");
                            Application.Exit();
                        }
                        for (int ii = 0; ii < Convert.ToInt32(textBox3.Text); ii++)
                        {
                            snakepos[ii] = 0;
                        }
                        draw();
                    }
                }
            }
        }

        private void draw()
        {
            paper.Clear(Color.Gray);

            label3.Text = "geld: " + money;
            for (int i = 0; i < 5; i++)
            {
                for (int ii = 0; ii < 15 + Convert.ToInt32(textBox3.Text) * 20; ii++)
                {
                    if (i % 2 == 1)
                    {
                        if (ii % 2 != 1)
                        {
                            paper.FillRectangle(checker1, 750 + 10 * i, 50 + 10 * ii, 10, 10);
                        }
                        else
                        {
                            paper.FillRectangle(checker2, 750 + 10 * i, 50 + 10 * ii, 10, 10);
                        }
                    }
                    else
                    {
                        if (ii % 2 != 0)
                        {
                            paper.FillRectangle(checker1, 750 + 10 * i, 50 + 10 * ii, 10, 10);
                        }
                        else
                        {
                            paper.FillRectangle(checker2, 750 + 10 * i, 50 + 10 * ii, 10, 10);
                        }
                    }
                }
            }
            for (int i = 0; i < Convert.ToInt32(textBox3.Text); i++)
            {
                for (int ii = 0; ii < 5; ii++)
                {
                    if (ii == 0)
                    {
                        paper.FillRectangle(
                            head,
                            250 - 55 * ii - snakepos[i],
                            150 + 100 * i,
                            50,
                            50
                        );
                    }
                    if (ii != 0)
                    {
                        paper.FillRectangle(
                            body,
                            250 - 55 * ii - snakepos[i],
                            150 + 100 * i,
                            50,
                            50
                        );
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gamble == 0)
            {
                gamble = Convert.ToInt32(textBox1.Text);

                if (Convert.ToInt32(textBox2.Text) <= money)
                {
                    gambleamount = Convert.ToInt32(textBox2.Text);
                    money -= gambleamount;

                    snakepos = new int[Convert.ToInt32(textBox3.Text)];
                    for (int i = 0; i < Convert.ToInt32(textBox3.Text); i++)
                    {
                        snakepos[i] = 0;
                    }
                }
                else
                {
                    MessageBox.Show("broooke");
                }

                draw();
            }
            else
            {
                MessageBox.Show("holy addict you already gambled");
            }
        }
    }
}
