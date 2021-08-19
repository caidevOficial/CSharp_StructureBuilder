/*
 * MIT License
 * 
 * Copyright (c) 2021 [FacuFalcone]
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Text;
using Entities;

namespace AuxiliarClass {
    public sealed class DataCollector {

        #region StructureName

        public static string StructureNameCollector() {
            StringBuilder data = new StringBuilder();
            do {
                ConsolePrinter.PrintHeader("# Idea in C Language by: Santiago Herrera.\n## Advanced improvement & Development in C# by: CaidevOficial - FacuFalcone.\n", ConsoleColor.Green, ConsoleColor.Yellow);
                Console.WriteLine("Through this program you'll be asked many times for yes or no.");
                Console.WriteLine("At those times enter y for yes and n for no.");
                Console.WriteLine("Nothing will be saved if you close the program at a random time.");
                Console.WriteLine("The saving will only procced after the \"LAST CONFIRMATION\" Question.");
                Console.WriteLine("(An \"s\" will be added at the beginning) so.. \n");
                Console.Write("Write the name of the Structure: ");
                data.Append(Console.ReadLine().Trim());

            } while (!DataValidator.ValidateAnswer("Are you sure? [y/n]: "));

            return data.ToString();
        }

        public static string StructureAliasCollector(string structureName) {
            StringBuilder data = new StringBuilder();
            structureName = structureName.Trim().ToLower();
            ConsolePrinter.PrintHeader($"Generating data For Structure: {structureName}.", ConsoleColor.Green, ConsoleColor.Yellow);
            ConsolePrinter.PrintSubHeader("Creating Alias For Structure", ConsoleColor.Green, ConsoleColor.Yellow);
            data.Append(structureName.Substring(0, 1).ToUpper());
            data.Append(structureName.Substring(1, structureName.Length - 1).ToLower());

            return data.ToString();
        }

        #endregion

        #region ParameterName

        public static string ParameterNameCollector() {
            StringBuilder data = new StringBuilder();
            do {
                ConsolePrinter.PrintHeader("Struct DotH DotC Builder", ConsoleColor.Green, ConsoleColor.Yellow);
                ConsolePrinter.PrintSubHeader("Step 2: Parameters: [For the structure]", ConsoleColor.Green, ConsoleColor.Yellow);
                Console.Write("\nWrite the name of the Parameter: ");
                data.Append(Console.ReadLine().Trim().Replace(" ", "").ToLower());

            } while (!DataValidator.ValidateAnswer("Are you sure? [y/n]: "));

            return data.ToString();
        }

        public static String ParameterAliasCollector(string parameterName) {
            StringBuilder data = new StringBuilder();
            parameterName = parameterName.Trim().ToLower();
            ConsolePrinter.PrintHeader($"Generating data For Parameter: {parameterName}.", ConsoleColor.Green, ConsoleColor.Yellow);
            ConsolePrinter.PrintSubHeader("Creating Alias For Parameter", ConsoleColor.Green, ConsoleColor.Yellow);
            data.Append(parameterName.Substring(0, 1).ToUpper());
            data.Append(parameterName.Substring(1, parameterName.Length - 1).ToLower());

            return data.ToString();
        }

        #endregion

        #region ParameterType

        private static string MenuOfTypes() {
            string typeParameter = string.Empty;
            short selectedOption = 0;

            Console.WriteLine("Possible types of parameters:");
            Console.WriteLine("1 - int\n2 - float\n3 - char\n4 - long int\n5 - short\n======================");
            Console.Write("Choose a number corresponding to the types listed above: ");
            if (short.TryParse(Console.ReadLine(), out selectedOption)) {
                switch (selectedOption) {
                    case 1:
                        typeParameter = "int";
                        break;
                    case 2:
                        typeParameter = "float";
                        break;
                    case 3:
                        typeParameter = "char";
                        break;
                    case 4:
                        typeParameter = "long int";
                        break;
                    case 5:
                        typeParameter = "short";
                        break;
                    default:
                        break;
                }
            }

            return typeParameter;
        }

        public static string ParameterTypeCollector(Parameter myParam) {
            string type = "int";

            if (!(myParam is null)) {
                do {
                    ConsolePrinter.PrintHeader("Struct DotH DotC Builder", ConsoleColor.Green, ConsoleColor.Yellow);
                    ConsolePrinter.PrintSubHeader("Step 2: Name of the Parameters: [Select a type of the parameter.]", ConsoleColor.Green, ConsoleColor.Yellow);
                    Console.WriteLine($"\nName of the Parameter: {myParam.NameParameter}\nAlias: {myParam.AliasNameParameter}\n");
                    type = MenuOfTypes();

                    while (type.Equals("")) {
                        ConsolePrinter.PrintHeader("Error, invalid option selected. Please, Try Again.", ConsoleColor.Red, ConsoleColor.Magenta);
                        type = MenuOfTypes();
                    }
                } while (!DataValidator.ValidateAnswer("Are you sure? [y/n]: "));
            }

            return type;
        }

        #endregion

        #region ParameterLength

        public static short LengthCharCollector(Parameter myParam) {
            int sizeChar = 1;
            if (!(myParam is null)) {
                if (myParam.TypeParameter.Equals("char")) {
                    do {
                        ConsolePrinter.PrintHeader("Struct DotH DotC Builder", ConsoleColor.Green, ConsoleColor.Yellow);
                        ConsolePrinter.PrintSubHeader("Step 2: Name of the Parameters: [Specify size of the char array]", ConsoleColor.Green, ConsoleColor.Yellow);
                        Console.Write("\nThe type of the parameter is char, if its a string [char's array] \n"
                                + "Write the length [Default 1]: ");
                        int.TryParse(Console.ReadLine(), out sizeChar);

                    } while (!DataValidator.ValidateAnswer("Are you sure? [y/n]: "));

                    if (sizeChar <= 0) {
                        sizeChar = 1;
                    }
                }
            }

            return (short)sizeChar;
        }

        public static bool NeedStringImport(Structure myStructure) {
            if (!(myStructure is null)) {
                foreach (Parameter aParameter in myStructure.ListParamaters) {
                    if (aParameter.LengthParameter > 1) {
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion

        #region ContinueCollectinParameters

        private static short ContinueAddingParameters() {
            short continueAdd = 0;
            ConsolePrinter.PrintHeader("Struct DotH DotC Builder", ConsoleColor.Green, ConsoleColor.Yellow);
            ConsolePrinter.PrintSubHeader("Step 2: Name Your Parameters.", ConsoleColor.Green, ConsoleColor.Yellow);
            Console.Write("\nParameter Saved.");
            Console.Write("\nDo you Want to add more parameters?[ 1 = YES/ 0 = NO]: ");
            short.TryParse(Console.ReadLine(), out continueAdd);

            while (continueAdd != 1 && continueAdd != 0) {
                ConsolePrinter.PrintHeader("Error, invalid option selected. Please, Try Again.", ConsoleColor.Red, ConsoleColor.Magenta);
                Console.Write("\nDo you Want to add more parameters?[ 1 = YES/ 0 = NO]: ");
                short.TryParse(Console.ReadLine(), out continueAdd);
            }

            return continueAdd;
        }

        #endregion

        #region AssembleParameter

        private static void AssembleParameter(Parameter myParameter) {
            string parameterName = string.Empty;
            string parameterAlias = string.Empty;

            if (!(myParameter is null)) {
                do {
                    myParameter.NameParameter = ParameterNameCollector(); // Set the name
                    myParameter.AliasNameParameter = myParameter.NameParameter; // insert the alias.
                    myParameter.TypeParameter = ParameterTypeCollector(myParameter); // Set the type
                    myParameter.LengthParameter = LengthCharCollector(myParameter); // Set the length

                    if (myParameter.TypeParameter.Equals("char")) {
                        Console.Write($"\nParameter status: \nName: {myParameter.NameParameter}\nAlias: {myParameter.AliasNameParameter}\nType: {myParameter.TypeParameter}[{myParameter.LengthParameter}]\n");
                        ConsolePrinter.PrintHeader($"Preview: {myParameter.TypeParameter} {myParameter.NameParameter}[{myParameter.LengthParameter}];", ConsoleColor.White, ConsoleColor.Cyan);
                    } else {
                        Console.Write($"\nParameter status: \nName: {myParameter.NameParameter}\nAlias: {myParameter.AliasNameParameter}\nType: {myParameter.TypeParameter}\n");
                        ConsolePrinter.PrintHeader($"Preview: {myParameter.TypeParameter} {myParameter.NameParameter};", ConsoleColor.White, ConsoleColor.Cyan);
                    }
                } while (!DataValidator.ValidateAnswer("Is it OK? [y/n]: "));
            }
        }

        public static void AddParameterToStructure(Structure myStructure) {
            int idForParameter = 1;
            if (!(myStructure is null)) {
                do {
                    Parameter myParameter = new Parameter();
                    if (myStructure.ListParamaters.Count > 0) {
                        myParameter.IdParameter = (short)(myStructure.ListParamaters.Count + 1);
                    } else {
                        myParameter.IdParameter = (short)idForParameter;
                    }

                    AssembleParameter(myParameter);

                    if (myStructure + myParameter) {
                        Console.WriteLine($"Parameter: {myParameter.TypeParameter} {myParameter.NameParameter} added to structure {myStructure.FinalStructureName} successfully!.\n");
                    } else {
                        Console.WriteLine($"ERROR: something get wrong while trying to add {myParameter.NameParameter} to the structure. Try again.\n");
                    }
                } while (ContinueAddingParameters() != 0);
            }
        }

        #endregion

    }
}
