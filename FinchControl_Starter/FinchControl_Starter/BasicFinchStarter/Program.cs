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
        // Last Date Edited:01/03/2020                                      //       
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
            Console.ForegroundColor = ConsoleColor.Green;

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
            double action;
            int numberOfDataPoints = 0;
            double dataPointsFrequency = 0;
            double[] temperatures = null;

            Console.Clear();
            Console.WriteLine("\nChoose an Action");
            Console.WriteLine("1.) Number of Data Points");
            Console.WriteLine("2.) Frequency of data points");
            Console.WriteLine("3.) Get Data");
            Console.WriteLine("4.) Show Data");
            Console.WriteLine("5.) Quit");
            Console.WriteLine();

            double.TryParse(Console.ReadLine(), out action);
            switch (action)
            {
                case 1:
                    numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints(myFinch);
                    break;

                case 2:
                    dataPointsFrequency = DataRecorderDisplayGetFrequencyOfDataPoints(myFinch);
                    break;

                case 3:
                    temperatures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointsFrequency, myFinch);
                    break;

                case 4:
                    DataRecorderDisplayData(temperatures);
                    break;

                case 5:
                    DisplayMainMenu(myFinch);
                    break;

                default:
                    break;
            }

        }
        //---------------------------------//
        //Display Get Number Of Data Points//
        //---------------------------------//
        static int DataRecorderDisplayGetNumberOfDataPoints(Finch myFinch)
        {
            int numberOfDataPoints;
            string userResponse;
            bool validResponse;

            DisplayHeader("Number of Data Points");

            do
            {
                Console.WriteLine("Enter Number of Data Points");
                userResponse = Console.ReadLine();

                validResponse = int.TryParse(userResponse, out numberOfDataPoints);

                if (!validResponse)
                {
                    Console.WriteLine("Incorrect format");
                }

            } while (validResponse == false);

            DisplayContinuePrompt();
            DisplayDataRecorder(myFinch);
            return numberOfDataPoints;
        }
        //-------------//
        //Get Frequency//
        //-------------//
        static double DataRecorderDisplayGetFrequencyOfDataPoints(Finch myFinch)
        {
            double dataPointsFrequency;
            string userResponse;
            bool validResponse;

            DisplayHeader("Frequency of Data Points");

            do
            {
                Console.WriteLine("Enter Frequency of Data Points");
                userResponse = Console.ReadLine();

                validResponse = double.TryParse(userResponse, out dataPointsFrequency);

                if (!validResponse)
                {
                    Console.WriteLine("Incorrect format");
                }

            } while (validResponse == false);
            DisplayContinuePrompt();
            DisplayDataRecorder(myFinch);
            return dataPointsFrequency;

        }
        //--------//
        //Get Data//
        //--------//
        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointsFrequency, Finch myFinch)
        {
            double[] temperatures = new double[numberOfDataPoints];
            int frequencyInSeconds;
            DisplayHeader("Get Data");

            Console.WriteLine($"You have {numberOfDataPoints} and {dataPointsFrequency}");

            Console.WriteLine("The finch robot is ready to record temperature");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperatures[index] = myFinch.getTemperature();
                Console.WriteLine($"Data #{index + 1}: {temperatures[index]} in celcius. {index + 1}: {(temperatures[index] * 9 / 5) + 32} in fahrenheit");
                frequencyInSeconds = (int)(dataPointsFrequency * 1000);
                myFinch.wait(frequencyInSeconds);
            }

            Console.WriteLine();
            Console.WriteLine("Current Data");
            DataRecorderDisplayTable(temperatures);

            DisplayContinuePrompt();
            DisplayDataRecorder(myFinch);
            return temperatures;
        }
        //---------//
        //Show Data//
        //---------//
        static void DataRecorderDisplayData(double[] temperatures)
        {

            DisplayHeader("Data");

            DataRecorderDisplayData(temperatures);

            DisplayContinuePrompt();
        }
        //-------------//
        //Display Table//
        //-------------//
        static void DataRecorderDisplayTable(double[] temperatures)
        {
            Console.WriteLine(
                "Data Point".PadLeft(12) +
                "Temperature".PadLeft(10)
                );
            Console.WriteLine(
                "----------".PadLeft(12) +
                "-----------".PadLeft(10)
                );

            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                    (index + 1).ToString("N2").PadLeft(12) +
                    temperatures[index].ToString("n2").PadLeft(10)
                     );
            }

            DisplayContinuePrompt();
        }
        #endregion

        #region Alarm System
        //------------//
        //Alarm System//
        //------------//
        static void DisplayAlarmSystem(Finch myFinch)
        {
            string sensorToMonitor;
            string rangeType = "";
            int setThreshHold;
            int timeToMonitor;
            double action;

            Console.Clear();

            DisplayHeader("Alarm System");

            Console.WriteLine("\nChoose an Action");
            Console.WriteLine("1.) Choose Sensor to Monitor");
            Console.WriteLine("2.) Set Range");
            Console.WriteLine("3.) Set Thresh Hold");
            Console.WriteLine("4.) Set Monitor time");
            Console.WriteLine("5.) Set Alarm");
            Console.WriteLine("6.) Quit");
            Console.WriteLine();

            double.TryParse(Console.ReadLine(), out action);
            switch (action)
            {
                case 1:
                    sensorToMonitor = DisplaySensorToMonitor(myFinch);
                    break;

                case 2:
                    rangeType = DisplaySetRange();
                    break;

                case 3:
                    setThreshHold = DisplaySetThreshHold(rangeType, myFinch);
                    break;

                case 4:
                    timeToMonitor = DisplayTimeToMonitor();
                    break;

                case 5:
                    
                    break;
                
                case 6:
                    DisplayClosingScreen();
                    break;

                default:
                    break;
            }
        }
        //-------------//
        //Choose Sensor//
        //-------------//
        static string DisplaySensorToMonitor(Finch myFinch) 
        {
            string sensorToMonitor;
            DisplayHeader("Set Sensor to Monitor");

            Console.WriteLine("Choose Sensor");
            Console.WriteLine("1.) Left");
            Console.WriteLine("2.) Right");
            Console.WriteLine("3.) Both");
            sensorToMonitor = Console.ReadLine().ToLower();

            DisplayContinuePrompt();
            return sensorToMonitor;
        }
        //---------//
        //Set Range//
        //---------//
        static string DisplaySetRange()
        {
            string rangeType;

            DisplayHeader("Set Range");

            Console.WriteLine("Set Range");
            rangeType = Console.ReadLine();

            DisplayContinuePrompt();
            return rangeType;

        }
        //---------------//
        //Set Thresh Hold//
        //---------------//
        static int DisplaySetThreshHold(string rangeType, Finch myFinch)
        {
            int setThreshHold;
            string userResponse;
            bool validResponse;

            do
            {
                DisplayHeader("Min/Max Threshold Value");

                Console.WriteLine($"Current Left light sensor value: {myFinch.getLeftLightSensor()}");
                Console.WriteLine($"Current right light sensor value: {myFinch.getRightLightSensor()}");
                Console.WriteLine();

                Console.WriteLine("Set Threshold:");
                userResponse = Console.ReadLine();

                validResponse = int.TryParse(userResponse, out setThreshHold);

                if (!validResponse)
                {
                    Console.WriteLine("Incorrect format");
                }

            } while (validResponse == false);

            DisplayContinuePrompt();
            return setThreshHold;
        }
        //----------------//
        //Set monitor time//
        //----------------//
        static int DisplayTimeToMonitor()
        {
            int timeToMonitor;
            bool validResponse;
            string userResponse;

            DisplayHeader("Set Time To Monitor");

            do
            {
                Console.WriteLine("Set Time:");
                userResponse = Console.ReadLine();

                validResponse = int.TryParse(userResponse, out timeToMonitor);

                if (!validResponse)
                {
                    Console.WriteLine("Incorrect format");
                }
            } while (!validResponse);

            DisplayContinuePrompt();
            return timeToMonitor;
        }

        #endregion

    }
}
