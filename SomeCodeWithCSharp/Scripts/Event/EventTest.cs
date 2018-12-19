using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SomeCodeWithCSharp.Scripts.Event
{
    public class EventTest
    {
        public static EventTest Instance = new EventTest(); //单例

        public void Test()
        {
            Print();
        }

        public void Print()
        {
            Ball ball = new Ball();
            Pitcher pitcher = new Pitcher(ball);
            BallEventArgs e = new BallEventArgs(12, 100);
            ball.OnBallInPlay(e);
        }


        public class Ball
        {
            public event EventHandler<BallEventArgs> BallInPlay;

            public void OnBallInPlay(BallEventArgs e)
            {
                Console.WriteLine("Ball Play");

                // BallInPlay?.Invoke(this, e);
                // c# headfirst 708
                EventHandler<BallEventArgs> ballInPlay = BallInPlay;
                if (ballInPlay != null)
                    ballInPlay(this, e);
            }

        }

        public class Pitcher
        {
            public ObservableCollection<string> PitcherSays = new ObservableCollection<string>();
            public int pitchNumber = 0;

            public Pitcher(Ball ball)
            {
                ball.BallInPlay += Ball_BallInPlay;
            }

            private void Ball_BallInPlay(object sender, EventArgs e)
            {
                Console.WriteLine("Pitcher");
                if (e is BallEventArgs)
                {
                    BallEventArgs ballEventArgs = e as BallEventArgs;
                    if (ballEventArgs.Distance < 95 && ballEventArgs.Tragectory < 60)
                        CatchBall();
                    else
                        CoverFirstBase();
                }
            }

            private void CoverFirstBase()
            {
                PitcherSays.Add("Pitch #" + pitchNumber + ": I caught the ball");
            }

            private void CatchBall()
            {
                PitcherSays.Add("Pitch #" + pitchNumber + ": I covered first base");
            }
        }
    }


    public class BallEventArgs : EventArgs
    {
        public int Tragectory { get; private set; }
        public int Distance { get; private set; }

        public BallEventArgs(int tragectory, int distance)
        {
            Tragectory = tragectory;
            Distance = distance;
        }
    }
}
