using System;
using System.Collections.Generic;
using System.Threading;

namespace zmejka
{
    class Program
    {
        //static private int score;

        public void game_draw(int ymap)
        {
            Console.Clear();
            Console.Title = "Snake";
            Console.SetWindowSize(100, ymap);
            //HorizontalLine upline = new HorizontalLine(0, ymap - 1, 0, '+');
            //HorizontalLine downline = new HorizontalLine(0, ymap - 1, 25, '+');
            //VerticalLine leftline = new VerticalLine(1, 25, 0, '+');
            //VerticalLine rightline = new VerticalLine(1, 25, ymap - 1, '+');
            //upline.Draw();
            //downline.Draw();
            //leftline.Draw();
            //rightline.Draw();
            Walls walls = new Walls(56, ymap);
            walls.Draw();

            Parametrs settings = new Parametrs();
            Sounds sound = new Sounds(settings.GetResourceFolder());
            sound.Play("stardust.mp3");
            Sounds soundeat = new Sounds(settings.GetResourceFolder());

            Point p = new Point(2, 5, '*', ConsoleColor.Red);
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            FoodCreator foodCreator = new FoodCreator(56, ymap, '¤', ConsoleColor.Green);
            Point food = foodCreator.CreateFood();
            food.Draw();
            Score score = new Score(0, 1);//score =0, level=1
            score.speed = 200;
            score.ScoreWrite();
            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    soundeat.Play("lost.mp3");
                    score.ScoreUp();
                    score.ScoreWrite();
                    food = foodCreator.CreateFood();
                    food.Draw();
                    sound.Stop("stardust.mp3");
                    if (score.ScoreUp())
                    {
                        score.speed -= 10;
                    }
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(score.speed);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }

            }
        }

        static void Main(string[] args)
        {

            Start start = new Start();
            int ymap = start.choice();
            if (ymap == 26 || ymap == 34)
            {
                Program prog = new Program();
                prog.game_draw(ymap);
            }
            else
            {
                start.Game_stop();
            }


            //Console.ReadLine();
        }
    }
}