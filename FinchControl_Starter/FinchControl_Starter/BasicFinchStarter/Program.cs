﻿using FinchAPI;
using System;
using System.Collections.Generic;
using System.IO;

namespace FinchControl_Starter
{
    enum Command
    {
        NONE,
        MOVEFORWARD,
        MOVEBACKWARDS,
        STOPMOTORS,
        WAIT,
        TURNRIGHT,
        TURNLEFT,
        LEDON,
        LEDOFF,
        GETTEMPERATURE,
        DONE
    }
    class Program
    {
        //------------------------------------------------------------------//
        // Application:Finch Assignments                                    //
        // Author:Sean Donovan                                              //
        // Description:Coding assingments within Mission 3                  //
        // Date Created:2/27/2020                                           //
        // Last Date Edited:03/04/2020                                      //       
        //------------------------------------------------------------------//

        #region Prcedure
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
        #endregion

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
            Console.WriteLine("4.) User Program");
            Console.WriteLine("5.) Settings");
            Console.WriteLine("6.) Quit");
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

                case 4:
                    DisplayUserProgram(myFinch);
                    break;

                case 5:
                    DisplaySettings(myFinch);
                    break;

                case 6:

                    break;
                default:
                    break;
            }
        }

        //--------//
        //Settings//
        //--------//
        static void DisplaySettings(Finch myFinch)
        {
            (ConsoleColor foregroundColor, ConsoleColor backgroundColor) themeColors;
            bool themeChosen = false;
            string fileIOStatusMessage;

            DisplayHeader("Set New Theme");

            Console.WriteLine($"\tCurrent foreground color: {Console.ForegroundColor}");
            Console.WriteLine($"\tCurrent background color: {Console.BackgroundColor}");
            Console.WriteLine();

            Console.Write("\tWould you like to change the current theme [ yes | no ]?");
            if (Console.ReadLine().ToLower() == "yes")
            {
                do
                {
                    //
                    // query the user for console colors
                    //
                    themeColors.foregroundColor = GetConsoleColorFromUser("foreground");
                    themeColors.backgroundColor = GetConsoleColorFromUser("background");

                    //
                    // set new theme
                    //
                    Console.ForegroundColor = themeColors.foregroundColor;
                    Console.BackgroundColor = themeColors.backgroundColor;
                    Console.Clear();
                    DisplayHeader("Set Application Theme");
                    Console.WriteLine($"\tNew foreground color: {Console.ForegroundColor}");
                    Console.WriteLine($"\tNew background color: {Console.BackgroundColor}");

                    Console.WriteLine();
                    Console.Write("\tIs this the theme you would like?");
                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        themeChosen = true;
                        fileIOStatusMessage = WriteThemeDataExceptions(themeColors.foregroundColor, themeColors.backgroundColor);
                        if (fileIOStatusMessage == "Complete")
                        {
                            Console.WriteLine("\n\tNew theme written to data file.\n");
                        }
                        else
                        {
                            Console.WriteLine("\n\tNew theme not written to data file.");
                            Console.WriteLine($"\t*** {fileIOStatusMessage} ***\n");
                        }
                    }

                } while (!themeChosen);
            }
            DisplayMainMenu(myFinch);
        }
        //-------------//
        //Console Color//
        //-------------//
        static ConsoleColor GetConsoleColorFromUser(string property)
        {
            ConsoleColor consoleColor;
            bool validConsoleColor;

            do
            {
                Console.Write($"\tEnter a value for the {property}:");
                validConsoleColor = Enum.TryParse<ConsoleColor>(Console.ReadLine(), true, out consoleColor);

                if (!validConsoleColor)
                {
                    Console.WriteLine("\n\t***** It appears you did not provide a valid console color. Please try again. *****\n");
                }
                else
                {
                    validConsoleColor = true;
                }

            } while (!validConsoleColor);

            return consoleColor;
        }
        //---------------//
        //Data Exceptions//
        //---------------//
        static string WriteThemeDataExceptions(ConsoleColor foreground, ConsoleColor background)
        {
            string dataPath = @"Data/Theme.txt";
            string fileIOStatusMessage = "";

            try
            {
                File.WriteAllText(dataPath, foreground.ToString() + "\n");
                File.AppendAllText(dataPath, background.ToString());
                fileIOStatusMessage = "Complete";
            }
            catch (DirectoryNotFoundException)
            {
                fileIOStatusMessage = "Unable to locate the folder for the data file.";
            }
            catch (Exception)
            {
                fileIOStatusMessage = "Unable to write to data file.";
            }

            return fileIOStatusMessage;
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

            DisplayHeader("Talent Show");

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
                    DisplayMainMenu(myFinch);
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

            DisplayHeader("Talent Show");

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

            Console.WriteLine($"You have {numberOfDataPoints} data points and a frequency of {dataPointsFrequency}");

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
                "Data Point".PadLeft(10) +
                "Temperature".PadLeft(12)
                );
            Console.WriteLine(
                "----------".PadLeft(10) +
                "-----------".PadLeft(12)
                );

            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                    (index + 1).ToString("N2").PadLeft(12) +
                    temperatures[index].ToString("n2").PadLeft(10)
                     );
            }

        }
        #endregion

        #region Alarm System
        //------------//
        //Alarm System//
        //------------//
        static void DisplayAlarmSystem(Finch myFinch)
        {
            string sensorToMonitor = null;
            string rangeType = null;
            int setThreshHold = 0;
            int timeToMonitor = 0;
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
                    rangeType = DisplaySetRange(myFinch);
                    break;

                case 3:
                    setThreshHold = DisplaySetThreshHold(rangeType, myFinch);
                    break;

                case 4:
                    timeToMonitor = DisplayTimeToMonitor(myFinch);
                    break;

                case 5:
                    DisplaySetAlarm(myFinch, sensorToMonitor, rangeType, setThreshHold, timeToMonitor);
                    break;

                case 6:
                    DisplayMainMenu(myFinch);
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
            DisplayAlarmSystem(myFinch);
            return sensorToMonitor;
        }
        //---------//
        //Set Range//
        //---------//
        static string DisplaySetRange(Finch myFinch)
        {
            string rangeType;

            DisplayHeader("Set Range");

            Console.WriteLine("Set Range");
            rangeType = Console.ReadLine();

            DisplayContinuePrompt();
            DisplayAlarmSystem(myFinch);
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
            DisplayAlarmSystem(myFinch);
            return setThreshHold;
        }
        //----------------//
        //Set monitor time//
        //----------------//
        static int DisplayTimeToMonitor(Finch myFinch)
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
            DisplayAlarmSystem(myFinch);
            return timeToMonitor;
        }
        //---------//
        //Set Alarm//
        //---------//
        static void DisplaySetAlarm(Finch myFinch, string sensorToMonitor, string rangeType, int setThreshHold, int timeToMonitor)
        {
            int currentLightSensorValue = 0;
            int elapsedTime = 0;
            bool thresholdExceeded = false;
            DisplayHeader("Set Alarm System");

            Console.WriteLine($"Sensors used: {sensorToMonitor}");
            Console.WriteLine($"Range: {rangeType}");
            Console.WriteLine($"Threshold: {setThreshHold}");
            Console.WriteLine($"Monitoring time: {timeToMonitor}");
            Console.WriteLine();

            Console.WriteLine("Press any key to begin monitoring.");
            Console.ReadKey();

            while (!thresholdExceeded && elapsedTime < timeToMonitor)
            {
                DisplayGetCurrentSensorValue(myFinch, sensorToMonitor, currentLightSensorValue);

                DisplayMonitorLightSensors(myFinch, rangeType, elapsedTime, currentLightSensorValue, setThreshHold, thresholdExceeded);
            }
            if (thresholdExceeded)
            {
                Console.WriteLine($"The {rangeType} threshhold value of {setThreshHold} was exceedded.");
                myFinch.setMotors(255, -255);
                myFinch.noteOn(587);
                myFinch.wait(5000);
            }
            else if (!thresholdExceeded)
            {
                Console.WriteLine($"The threshold was not exceeded");
            }


            DisplayContinuePrompt();
            DisplayAlarmSystem(myFinch);
        }
        //------------------------//
        //Get Current Sensor Value//
        //------------------------//
        static int DisplayGetCurrentSensorValue(Finch myFinch, string sensorToMonitor, int currentLightSensorValue)
        {

            switch (sensorToMonitor)
            {
                case "left":
                    currentLightSensorValue = myFinch.getLeftLightSensor();
                    break;

                case "right":
                    currentLightSensorValue = myFinch.getRightLightSensor();
                    break;

                case "both":
                    currentLightSensorValue = myFinch.getLeftLightSensor() + myFinch.getRightLightSensor() / 2;
                    break;

            }

            DisplayAlarmSystem(myFinch);
            return currentLightSensorValue;
        }
        //---------------------//
        //Monitor Light Sensors//
        //---------------------//
        static bool DisplayMonitorLightSensors(Finch myFinch, string rangeType, int elapsedTime, int currentLightSensorValue, int setThreshHold, bool thresholdExceeded)
        {
            switch (rangeType)
            {
                case "min":
                    if (currentLightSensorValue < setThreshHold)
                    {
                        thresholdExceeded = true;
                    }
                    break;

                case "max":
                    if (currentLightSensorValue > setThreshHold)
                    {
                        thresholdExceeded = true;
                    }
                    break;

            }
            myFinch.wait(1000);
            elapsedTime++;

            DisplayAlarmSystem(myFinch);
            return thresholdExceeded;
        }
        #endregion

        #region User Program
        //-----------//
        //User Prgram//
        //-----------//
        static void DisplayUserProgram(Finch myFinch)
        {
            double action;

            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            List<Command> commands = new List<Command>();

            Console.Clear();

            DisplayHeader("Alarm System");

            Console.WriteLine("\nChoose an Action");
            Console.WriteLine("1.) Set Command Perameters");
            Console.WriteLine("2.) Add Commands");
            Console.WriteLine("3.) View Commands");
            Console.WriteLine("4.) Execute Comands");
            Console.WriteLine("5.) Quit");
            Console.WriteLine();

            double.TryParse(Console.ReadLine(), out action);
            switch (action)
            {
                case 1:
                    commandParameters = DisplayGetCommandParameters(myFinch);
                    break;

                case 2:
                    DisplayGetFinchCommands(commands, myFinch);
                    break;

                case 3:
                    DisplayFinchCommands(commands, myFinch);
                    break;

                case 4:
                    DisplayExecuteCommands(myFinch, commands, commandParameters);
                    break;

                case 5:
                    DisplayMainMenu(myFinch);
                    break;


                default:
                    break;
            }
        }

        //------------------//
        //Command Parameters//
        //------------------//
        static (int motorSpeed, int ledBrightness, double waitSeconds) DisplayGetCommandParameters(Finch myFinch)
        {
            string userResponse;
            bool validResponse;
            DisplayHeader("Command Parameters");

            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            //***********//
            //Motor Speed//
            //***********//
            do
            {
                Console.WriteLine("\tEnter Motor Speed[1 - 255]:");
                userResponse = Console.ReadLine();

                validResponse = int.TryParse(userResponse, out commandParameters.motorSpeed);

                if (!validResponse)
                {
                    Console.WriteLine("Incorrect format");
                }

            } while (validResponse == false);
            //**************//
            //LED Brightness//
            //**************//
            do
            {
                Console.WriteLine("\tEnter LED Brightness [1 - 255]:");
                userResponse = Console.ReadLine();

                validResponse = int.TryParse(userResponse, out commandParameters.ledBrightness);

                if (!validResponse)
                {
                    Console.WriteLine("Incorrect format");
                }

            } while (validResponse == false);
            //*********//
            //Wait Time//
            //*********//
            do
            {
                Console.WriteLine("Enter Wait in Seconds;");
                userResponse = Console.ReadLine();

                validResponse = double.TryParse(userResponse, out commandParameters.waitSeconds);

                if (!validResponse)
                {
                    Console.WriteLine("Incorrect format");
                }

            } while (validResponse == false);

            Console.WriteLine();
            Console.WriteLine($"\tMotor Speed: {commandParameters.motorSpeed}");
            Console.WriteLine($"\tLED Brightness: {commandParameters.ledBrightness}");
            Console.WriteLine($"\tWait Command Duration; {commandParameters.waitSeconds}");

            DisplayUserProgram(myFinch);

            return commandParameters;
        }

        //------------//
        //Get Commands//
        //------------//
        static void DisplayGetFinchCommands(List<Command> commands, Finch myFinch)
        {
            Command command = Command.NONE;

            DisplayHeader("Finch Robot Commands");

            //*************//
            //List commands//
            //*************//
            int commandCount = 1;
            Console.WriteLine("\tList of Available Commands");
            Console.WriteLine();
            Console.WriteLine("\t-");
            foreach (string commandName in Enum.GetNames(typeof(Command)))
            {
                Console.Write($"- {commandName.ToLower()} -");
                if (commandCount % 5 == 0) Console.WriteLine("-\n\t-");
                commandCount++;
            }
            Console.WriteLine();

            //******************//
            //user command input//
            //******************//
            while (command != Command.DONE)
            {
                Console.WriteLine("\tEnter Command");
                if (Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                {
                    commands.Add(command);
                }
                else
                {
                    Console.WriteLine("\t\t-------------------------------------------");
                    Console.WriteLine("\t\tPlease enter a command from the list above.");
                    Console.WriteLine("\t\t-------------------------------------------");
                }
            }

            DisplayUserProgram(myFinch);
        }

        //--------------//
        //Finch Commands//
        //--------------//
        static void DisplayFinchCommands(List<Command> commands, Finch myFinch)
        {
            DisplayHeader("Finch Robot Commands");
            foreach (Command command in commands)
            {
                Console.WriteLine($"\t{command}");
            }

            DisplayContinuePrompt();
            DisplayUserProgram(myFinch);
        }

        //----------------//
        //Execute Commands//
        //----------------//
        static void DisplayExecuteCommands(Finch myFinch, List<Command> commands, (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters)
        {
            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            int waitMilliSeconds = (int)(commandParameters.waitSeconds * 1000);
            string commandFeedback = "";
            const int TURNING_MOTOR_SPEED = 100;

            DisplayHeader("Execute Finch Commands");

            Console.WriteLine("\tThe Finch robot is ready to execute the list of commands.");
            DisplayContinuePrompt();

            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.NONE:
                        break;

                    case Command.MOVEFORWARD:
                        myFinch.setMotors(motorSpeed, motorSpeed);
                        commandFeedback = Command.MOVEFORWARD.ToString();
                        break;

                    case Command.MOVEBACKWARDS:
                        myFinch.setMotors(-motorSpeed, -motorSpeed);
                        commandFeedback = Command.MOVEBACKWARDS.ToString();
                        break;

                    case Command.STOPMOTORS:
                        myFinch.setMotors(0, 0);
                        commandFeedback = Command.STOPMOTORS.ToString();
                        break;

                    case Command.WAIT:
                        myFinch.wait(waitMilliSeconds);
                        commandFeedback = Command.WAIT.ToString();
                        break;

                    case Command.TURNRIGHT:
                        myFinch.setMotors(TURNING_MOTOR_SPEED, -TURNING_MOTOR_SPEED);
                        commandFeedback = Command.TURNRIGHT.ToString();
                        break;

                    case Command.TURNLEFT:
                        myFinch.setMotors(-TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                        commandFeedback = Command.TURNLEFT.ToString();
                        break;

                    case Command.LEDON:
                        myFinch.setLED(ledBrightness, ledBrightness, ledBrightness);
                        commandFeedback = Command.LEDON.ToString();
                        break;

                    case Command.LEDOFF:
                        myFinch.setLED(0, 0, 0);
                        commandFeedback = Command.LEDOFF.ToString();
                        break;

                    case Command.GETTEMPERATURE:
                        commandFeedback = $"Temperature: {myFinch.getTemperature().ToString("n2")}\n";
                        break;

                    case Command.DONE:
                        commandFeedback = Command.DONE.ToString();
                        break;

                    default:
                        break;
                }

                Console.WriteLine($"\t{commandFeedback}");
            }

            DisplayUserProgram(myFinch);
        }
        #endregion

    }
}
