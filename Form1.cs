using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        public Form1()
        {
           InitializeComponent();

            //Ustawiamy domyślne ustawienia
            new Settings();

            //Ustawiamy prędkość gry i starttimer
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            //Start New Game
            StartGame();
        }

        private void StartGame()
        {
            labelGameOver.Visible = false;

            //Ustawiamy domyślne ustawienia
            new Settings();

            //Tworzenie nowego obiektu gracza
            Snake.Clear();
            Circle head = new Circle();
            head.X = 10;
            head.Y = 5;
            Snake.Add(head);

            labelScore.Text = Settings.Score.ToString();
            GenerateFood();
        }

        //Losowe miejsce jedzenia
        private void GenerateFood()
        {
            int maxXPos = pbCanves.Size.Width / Settings.Width;
            int maxYPos = pbCanves.Size.Height / Settings.Height;

            Random random = new Random();
            food = new Circle();
            food.X = random.Next(0, maxXPos);
            food.Y = random.Next(0, maxYPos);
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            //Sprawdzanie game over
            if(Settings.GameOver == true)
            {
                //Sprawdzamy czy enter jest wciśnięty
                if (Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }

            }
            else
            {
                if (Input.KeyPressed(Keys.Right) && Settings.direction != Direction.Lefr)
                    Settings.direction = Direction.Right;
                else if (Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Lefr;
                else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;
                else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;

                MovePlayer();
            }
            pbCanves.Invalidate();
        }

            private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Snake_Load(object sender, EventArgs e)
        {

        }

        private void pbCanves_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pbCanves_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            
            if(!Settings.GameOver)
            {
                //Ustawienie koloru węża
                Brush snakeColour;

                //Rysuje węza
                for(int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0)
                        snakeColour = Brushes.Black; //Rysuje glowę
                    else
                        snakeColour = Brushes.Green; //Reszta ciała

                    //Rysuje węża
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(Snake[i].X * Settings.Width, Snake[i].Y * Settings.Height, Settings.Width, Settings.Height));

                    //Rysuje jedzenie
                    canvas.FillEllipse(Brushes.Red,
                        new Rectangle(food.X * Settings.Width, food.Y * Settings.Height, Settings.Width, Settings.Height));
                }
            }
            else
            {
                string gameOver = "Game over\n Twój wynik to :" + Settings.Score + "\nNaciśnij Enter by spróbowć ponownie";
                labelGameOver.Text = gameOver;
                labelGameOver.Visible = true;

            }
        }

        private void MovePlayer()
        {
            for(int i = Snake.Count -1; i>0; i--)
            {
                //Przesuwamy głowę
                if(i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            Snake[i].X++;
                            break;
                        case Direction.Lefr:
                            Snake[i].X--;
                            break;
                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                        case Direction.Down:
                            Snake[i].Y++;
                            break;
                    }

                    //Maksymalna pozycja X i Y
                    int maxXPos = pbCanves.Size.Width / Settings.Width;
                    int maxYPos = pbCanves.Size.Height / Settings.Height;

                    //Wykrywanie kolizji z granicami gry
                    if (Snake[i].X < 0 || Snake[i].Y < 0 || Snake[i].X >= maxXPos || Snake[i].Y >= maxYPos) 
                    {
                        Die();
                    }

                    //Wykrywanie kolizji z ciałem
                    for(int j=1; j< Snake.Count; j++)
                    {
                        if(Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            Die();
                        }
                    }

                    //wykrywanie kolizji z kawałkiem jedzenia
                    if(Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        //Eat();
                    }
                }
                else
                {
                    //Przesuwamy ciało
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        private void Eat()
        {
            //Dodać okrąg do ciała
            Circle food = new Circle();
            food.X = Snake[Snake.Count - 1].X;
            food.Y = Snake[Snake.Count - 1].Y;

            Snake.Add(food);

            //Aktualizacja wyniku
            Settings.Score += Settings.Points;
            labelScore.Text = Settings.Score.ToString();

            GenerateFood();
        }

        private void Die()
        {
            Settings.GameOver = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }
    }
}
