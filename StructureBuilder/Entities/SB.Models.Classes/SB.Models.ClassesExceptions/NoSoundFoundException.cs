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

namespace SBExceptions {
    public class NoSoundFoundException : Exception {

        #region Builders

        /// <summary>
        /// Creates the entity with a message.
        /// </summary>
        /// <param name="message">Message to show when the entity is created.</param>
        public NoSoundFoundException(string message)
            : this(message, null) { }

        /// <summary>
        /// Creates the entity with a message and a innerException.
        /// </summary>
        /// <param name="message">Message to show when the entity is created.</param>
        /// <param name="innerException">Inner Exception of this exception.</param>
        public NoSoundFoundException(string message, Exception innerException)
            : base(message, innerException) { }

        #endregion

        #region Method

        /// <summary>
        /// Gets the message of the exception.
        /// </summary>
        /// <returns>The message of the exception as a string.</returns>
        public override string ToString() {
            StringBuilder data = new StringBuilder();
            data.AppendLine($"Excepcion: {Message}");
            data.AppendLine($"Method afected: {TargetSite}");
            if (!(InnerException is null))
                data.AppendLine($"Details: {InnerException}");

            return data.ToString(); ;
        }

        #endregion
    }
}
