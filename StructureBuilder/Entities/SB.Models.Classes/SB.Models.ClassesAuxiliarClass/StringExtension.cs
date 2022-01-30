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

namespace Entities {
    public static class StringExtension {

        /// <summary>
        /// Deletes the possibly spaces in all the string.
        /// </summary>
        /// <param name="myString">String to remove the spaces.</param>
        /// <returns>The string without spaces.</returns>
        public static string RemoveSpaces(this string myString) {
            return myString.Trim().Replace(" ", "");
        }

        /// <summary>
        /// Changes only the first letter of the string to lower.
        /// </summary>
        /// <param name="myString">String to apply lower in the first letter.</param>
        /// <returns>The string 'Decapitalized'.</returns>
        public static string Decapitalize(this string myString) {
            return $"{myString.Substring(0, 1).ToLower()}{myString.Substring(1)}";
        }
    }
}
