namespace Zadachki
{
    public partial class Form1 : Form
    {
        private Random random = new();
        private int[,] food = new int[5, 5];
        private Button[,] buttons;

        public Form1()
        {
            InitializeComponent();
            InitializeButtons();
            InitializeFood();
        }

        private void InitializeButtons()
        {
            buttons = new Button[,]
            {
                {button2, button3, button4, button5, button6},
                {button7, button8, button9, button10, button11},
                {button12, button13, button14, button15, button16},
                {button17, button18, button19, button20, button21},
                {button22, button23, button24, button25, button26},
            };
        }

        private void InitializeFood()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    food[i, j] = random.Next(0, 9);
                    buttons[i, j].Text = food[i, j].ToString();
                }
        }

        private async void Pytin()

        {
            int[,] dp = new int[5, 5];
            int[,] pyt = new int[5, 5]; 

            dp[0, 0] = food[0, 0];

            for (int j = 1; j < 5; j++)
            {
                dp[0, j] = dp[0, j - 1] + food[0, j];
            }
                
            for (int i = 1; i < 5; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + food[i, 0];
            }

            for (int i = 1; i < 5; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    if (dp[i - 1, j] < dp[i, j - 1])
                    {
                        dp[i, j] = dp[i - 1, j] + food[i, j];
                        pyt[i, j] = 1; 
                    }
                    else
                    {
                        dp[i, j] = dp[i, j - 1] + food[i, j];
                        pyt[i, j] = 2; 
                    }
                }
            }

            int x = 0, y = 0;
            while (x < 4 || y < 4)
            {
                buttons[x, y].BackColor = Color.Green; 
                await Task.Delay(500); 
                if (x < 4 && (y == 4 || dp[x + 1, y] < dp[x, y + 1])) x++; 
                else y++;
            }

            buttons[4, 4].BackColor = Color.Green; 
            MessageBox.Show($"Путь составил: {dp[4, 4]}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pytin();
        }
    }
}






