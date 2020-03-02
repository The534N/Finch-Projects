using FinchAPI;
using System;

namespace FinchControl_Starter
{
    class Program
    {
        //------------------------------------------------------------------//
        // Application:Finch Assignments                                    //
        // Author:Sean Donovan                                              //
        // Description:Coding assingments within Mission 3                  //
        // Date Created:2/27/2020                                           //
        // Last Date Edited:2/19/2020                                       //       
        //------------------------------------------------------------------//



        //----//
        //Main//   
        //----//
        static void Main(string[] args)
        {
            //-------------//
            // create Finch//
            //-------------//
            Finch myFinch;
            myFinch = new Finch();

            //-----------------//
            // connect to finch//
            //-----------------//
            myFinch.connect();

            //-------//
            //Process//
            //-------//
            DisplayWelcomeScreen();
            DisplayMainMenu(myFinch);
            DisplayClosingScreen();

            //----------------------//
            // disconnect from finch//
            //----------------------//
            myFinch.disConnect();
        }
        #region Basic Screens
        //--------------//
        //Welcome Screen//
        //--------------//
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("\tFinch Control");

            DisplayContinuePrompt();

        }
        //--------------//
        //Closing Screen//
        //--------------//
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine("\n\tThank you for using this app");

            Console.WriteLine();
            Console.WriteLine("           Press any key to exit");
            Console.ReadKey();

        }
        //---------------//
        //Continue Prompt//
        //---------------//
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        //------//
        //Header//
        //------//
        static void DisplayHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine($"\n\t{headerText}");
            Console.WriteLine();
        }
        //---------//
        //Main Menu//
        //---------//
        static void DisplayMainMenu(Finch myFinch)
        {
            double assignment;
            DisplayHeader("Main Menu");

            Console.WriteLine("Choose an Assignment");
            Console.WriteLine("1.) Talent Show");
            Console.WriteLine("2.) Data Recorder");
            Console.WriteLine("3.) Alarm System");
            Console.WriteLine();
            double.TryParse(Console.ReadLine(), out assignment);
            switch (assignment)
            {
                case 1:
                    DisplayTalentShow(myFinch);
                    break;

                case 2:
                    DisplayDataRecorder(myFinch);
                    break;

                case 3:
                    DisplayAlarmSystem(myFinch);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Talent Show
        //-----------//
        //Talent Show//
        //-----------//
        static void DisplayTalentShow(Finch myFinch)
        {
            double action;
            Console.Clear();
            Console.WriteLine("\nChoose an Action");
            Console.WriteLine("1.) Light show");
            Console.WriteLine("2.) Play a Song");
            Console.WriteLine("3.) Do a dance");
            Console.WriteLine("4.) Panic");
            Console.WriteLine("5.) Quit");
            Console.WriteLine();

            double.TryParse(Console.ReadLine(), out action);
            switch (action)
            {
                case 1:
                    DisplayLeds(myFinch);
                    break;

                case 2:
                    DisplayNotes(myFinch);
                    break;

                case 3:
                    DisplayMoves(myFinch);
                    break;

                case 4:
                    DisplayPanic(myFinch);
                    break;

                case 5:
                    DisplayClosingScreen();
                    break;

                default:
                    break;
            }
        }
        //------------//
        //Display LEDS//
        //------------//
        static void DisplayLeds(Finch myFinch)
        {
            DisplayHeader("Finch LEDs");

            //for (int i = 0; i < 5; i++)
            //{
            //    myFinch.setLED(0, 0, 255);
            //    myFinch.wait(500);
            //    myFinch.setLED(0, 0, 0);
            //    myFinch.wait(500);
            //}
            for (int lightLevel = 0; lightLevel < 255; lightLevel++)
            {
                myFinch.setLED(lightLevel, 0, 0);
                myFinch.wait(10);
            }
            for (int lightLevel = 255; lightLevel > 0; lightLevel--)
            {
                myFinch.setLED(lightLevel, 0, 0);
                myFinch.wait(10);
            }

            DisplayContinuePrompt();
            DisplayTalentShow(myFinch);
        }
        //-----//
        //MUSIC//
        //-----//
        static void DisplayNotes(Finch myFinch)
        {
            DisplayHeader("Finch Notes");

            for (int soundlevel = 0; soundlevel < 20000; soundlevel = soundlevel + 50)
            {
                myFinch.noteOn(soundlevel);
            }
            for (int soundlevel = 255; soundlevel > 0; soundlevel = soundlevel - 50)
            {
                myFinch.noteOn(soundlevel);
            }

            //-----------------//
            //Hot Cross Buns???//
            //-----------------//

            myFinch.noteOn(587);
            myFinch.wait(500);
            myFinch.noteOff();
            myFinch.wait(500);

            myFinch.noteOn(523);
            myFinch.wait(500);
            myFinch.noteOff();
            myFinch.wait(500);

            myFinch.noteOn(493);
            myFinch.wait(500);
            myFinch.noteOff();
            myFinch.wait(500);

            myFinch.noteOn(587);
            myFinch.wait(500);
            myFinch.noteOff();
            myFinch.wait(500);

            myFinch.noteOn(523);
            myFinch.wait(500);
            myFinch.noteOff();
            myFinch.wait(500);

            myFinch.noteOn(493);
            myFinch.wait(500);
            myFinch.noteOff();
            myFinch.wait(500);

            myFinch.noteOn(493);
            myFinch.wait(500);
            myFinch.noteOff();
            myFinch.wait(500);

            myFinch.noteOn(493);
            myFinch.wait(500);
            myFinch.noteOff();
            myFinch.wait(500);

            myFinch.noteOn(523);
            myFinch.wait(500);
            myFinch.noteOff();
            myFinch.wait(500);

            myFinch.noteOn(523);
            myFinch.wait(500);
            myFinch.noteOff();
            myFinch.wait(500);

            myFinch.noteOn(587);
            myFinch.wait(500);
            myFinch.noteOff();
            myFinch.wait(500);

            myFinch.noteOn(523);
            myFinch.wait(500);
            myFinch.noteOff();
            myFinch.wait(500);

            myFinch.noteOn(493);
            myFinch.wait(500);
            myFinch.noteOff();
            myFinch.wait(500);

            DisplayContinuePrompt();
            DisplayTalentShow(myFinch);
        }
        //--------//
        //Movement//
        //--------//
        static void DisplayMoves(Finch myFinch)
        {
            DisplayHeader("Moves");

            myFinch.setMotors(255, 255);
            myFinch.wait(1000);
            myFinch.setMotors(-255, -255);
            myFinch.wait(1000);
            myFinch.setMotors(0, 0);

            DisplayContinuePrompt();
            DisplayTalentShow(myFinch);
        }
        //-----//
        //Panic//
        //-----//
        static void DisplayPanic(Finch myFinch)
        {
            DisplayHeader("PANIC");

            myFinch.setMotors(255, -255);
            myFinch.noteOn(587);
            myFinch.wait(5000);

            DisplayContinuePrompt();
            DisplayTalentShow(myFinch);

        }
        //---------//
        //Full Show//
        //---------//
        static void DisplayFullShow(Finch myFinch)
        {
            DisplayHeader("Full Show");


            DisplayContinuePrompt();
            DisplayTalentShow(myFinch);
        }
        #endregion

        #region Data Recorder
        //-------------//
        //Data Recorder//
        //-------------//
        static void DisplayDataRecorder(Finch myFinch)
        {

        }
        #endregion

        #region Alarm System
        //------------//
        //Alarm System//
        //------------//
        static void DisplayAlarmSystem(Finch myFinch)
        {

        }
        #endregion

    }
}
