using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Windows.Forms;
using System.Media;

namespace DrunkPC
{
    public class DrunkProgram
    {
        public static Random _random = new Random();

        public static int _startupDelaySeconds = 10;
        public static int _totalDurationSeconds = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("DrunkPC Application");

            // Check for command line arguments and assign the new values
            if( args.Length >= 2 )
            {
                _startupDelaySeconds = Convert.ToInt32(args[0]);
                _totalDurationSeconds = Convert.ToInt32(args[1]);
            }

            // Create all threads that manipulate all of the inputs and outputs to the system
            Thread drunkMouseThread = new Thread(new ThreadStart(DrunkMouseThread));
            Thread drunkKeyboardThread = new Thread(new ThreadStart(DrunkKeyboardThread));
            Thread drunkSoundThread = new Thread(new ThreadStart(DrunkSoundThread));
            Thread drunkPopupThread = new Thread(new ThreadStart(DrunkPopupThread));

            
            DateTime future = DateTime.Now.AddSeconds(_startupDelaySeconds);
            Console.WriteLine("Waiting 10 seconds before starting threads");
            while (future > DateTime.Now)
            {
                Thread.Sleep(100);
            }
            

            //Start all of the threads
            drunkMouseThread.Start();
            drunkKeyboardThread.Start();
            drunkSoundThread.Start();
            drunkPopupThread.Start();
            
            /*
            future = DateTime.Now.AddSeconds(_totalDurationSeconds);
            while( future > DateTime.Now)
            {
                Thread.Sleep(1000);
            }
            

            Console.WriteLine("Terminating all threads");

            //Kill all threads and exit application
            drunkMouseThread.Abort();
            drunkKeyboardThread.Abort();
            drunkSoundThread.Abort();
            drunkPopupThread.Abort();
            */
        }

        public void GetDrunk()
        {
            Thread drunkMouseThread = new Thread(new ThreadStart(DrunkMouseThread));
            drunkMouseThread.Start();
        }

        #region Thread Functions
        public static void DrunkMouseThread()
        {
            Console.WriteLine("DrunkMouseThread Started");

            int moveX = 0;
            int moveY = 0;

            while(true)
            {
                // Console.WriteLine(Cursor.Position.ToString());

                if (_random.Next(100) > 50)
                {
                    // Generate the random amount to move the cursor on X and Y
                    moveX = _random.Next(20) - 10;
                    moveY = _random.Next(20) - 10;

                    // Change mouse cursor position to new random coordinates
                    Cursor.Position = new System.Drawing.Point(
                        Cursor.Position.X + moveX,
                        Cursor.Position.Y + moveY);
                }

                Thread.Sleep(50);
            }
        }

        public static void DrunkKeyboardThread()
        {
            Console.WriteLine("DrunkKeyboardThread Started");

            while (true)
            {
                if (_random.Next(100) > 95)
                {
                    // Generate a random capitol letter
                    char key = (char)(_random.Next(25) + 65);

                    // 50/50 make it lower case
                    if (_random.Next(2) == 0)
                    {
                        key = Char.ToLower(key);
                    }

                    SendKeys.SendWait(key.ToString());
                }

                Thread.Sleep(_random.Next(500));
            }
        }

        public static void DrunkSoundThread()
        {
            Console.WriteLine("DrunkSoundThread Started");

            while (true)
            {
                // Determine if we're going to play a sound this time through the loop (20% odds)
                if (_random.Next(100) > 80)
                {
                    // Randomly select a system sound
                    switch(_random.Next(5))
                    {
                        case 0:
                            SystemSounds.Asterisk.Play();
                            Console.WriteLine("Asterisk Played");
                            break;
                        case 1:
                            SystemSounds.Beep.Play();
                            Console.WriteLine("Beep Played");
                            break;
                        case 2:
                            SystemSounds.Exclamation.Play();
                            Console.WriteLine("Exclamation Played");
                            break;
                        case 3:
                            SystemSounds.Hand.Play();
                            Console.WriteLine("Hand Played");
                            break;
                        case 4:
                            SystemSounds.Question.Play();
                            Console.WriteLine("Asterisk Played");
                            break;
                    }
                }
                
                Thread.Sleep(1000);
            }
        }

        public static void DrunkPopupThread()
        {
            Console.WriteLine("DrunkPopupThread Started");

            while (true)
            {
                // Every 10 seconds roll the dice and 10% of the time show a dialog
                if (_random.Next(100) > 90)
                {
                    // Determine which message to show user
                    switch(_random.Next(2))
                    {
                        case 0:
                            MessageBox.Show(
                               "Internet explorer has stopped working",
                                "Internet Explorer",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            break;
                        case 1:
                            MessageBox.Show(
                               "Your system is running low on resources",
                                "Microsoft Windows",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            break;
                    }
                }

                Thread.Sleep(10000);
            }
        }
        #endregion
    }
}
