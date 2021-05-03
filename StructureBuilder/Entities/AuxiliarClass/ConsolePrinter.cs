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

namespace Entities.AuxiliarClass {
    public sealed class ConsolePrinter {

        #region Printers

        /// <summary>
        /// Prints characters.
        /// </summary>
        /// <param name="length">Max length of the line.</param>
        /// <param name="charact">Character or symbol to print</param>
        /// <param name="foregroundColor">Color Of the symbols</param>
        private static void PrintSymbols(int length, char charact, ConsoleColor foregroundColor) {
            Console.ForegroundColor = foregroundColor;
            for (int index = 0; index < length; index++) {
                Console.Write(charact);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Prints the title and decorations of the program.
        /// </summary>
        /// <param name="title">Title to print.</param>
        /// <param name="titleForegroundColor">Color of the Text</param>
        /// <param name="symbolForegroundColor">Color Of the symbols</param>
        public static void PrintHeader(string title, ConsoleColor titleForegroundColor, ConsoleColor symbolForegroundColor) {
            int length = title.Length;
            int lengthLine = (length);

            PrintSymbols(lengthLine, '=', symbolForegroundColor);
            Console.ForegroundColor = titleForegroundColor;
            Console.WriteLine(title);
            PrintSymbols(lengthLine, '=', symbolForegroundColor);
        }

        /// <summary>
        /// Prints the subHeader of the program.
        /// </summary>
        /// <param name="subHeader">Subheader to print.</param>
        /// <param name="titleForegroundColor">Color of the Text</param>
        /// <param name="symbolForegroundColor">Color Of the symbols</param>
        public static void PrintSubHeader(string subHeader, ConsoleColor titleForegroundColor, ConsoleColor symbolForegroundColor) {
            int subLength = subHeader.Length;
            Console.ForegroundColor = titleForegroundColor;
            Console.WriteLine($"\n{subHeader}\n");
            PrintSymbols(subLength, '-', symbolForegroundColor);
        }

        #endregion

        #region CalculateAndPrints

        /// <summary>
        /// Calculates the percentage of the program.
        /// </summary>
        /// <param name="baseNumber">Max number of steps.</param>
        /// <param name="top">Actual number of steps done.</param>
        /// <returns></returns>
        private static double PercentageCalc(short baseNumber, short top) {
            int result;
            result = (100 * top) / baseNumber;
            return result;
        }

        /// <summary>
        /// Shows the progress of the program.
        /// </summary>
        /// <param name="baseNumber">Max number of steps.</param>
        /// <param name="top">Actual number of steps done.</param>
        public static void ShowProgress(short baseNumber, short top) {
            PrintHeader("Structure Builder", ConsoleColor.Yellow, ConsoleColor.Green);
            PrintSubHeader("Step 3: Building Struct Files", ConsoleColor.Yellow, ConsoleColor.Green);
            Console.Write($"\nProgress: [{PercentageCalc(baseNumber, top)}]%\n");
        }

        #endregion

    }
}
