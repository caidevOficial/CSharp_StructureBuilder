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

using System.Collections.Generic;

namespace Entities.Entities
{
    public sealed class Structure
    {
        private List<Parameter> listOfParamaters;

        #region Builder

        public Structure()
        {
            ListOfParamaters = new List<Parameter>();
        }

        public List<Parameter> ListOfParamaters
        {
            get => listOfParamaters;
            set => listOfParamaters = value;
        }

        #endregion

        #region Properties

        public List<Parameter> ListParamaters
        {
            get => listOfParamaters;
        }

        #endregion

        #region Operators

        public static bool operator ==(Structure s1, Parameter p1)
        {
            if (!(s1 is null || p1 is null))
            {
                foreach (Parameter aParameter in s1.ListOfParamaters)
                {
                    if (p1 == aParameter)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator !=(Structure s1, Parameter p1)
        {
            return !(s1 == p1);
        }

        public static Structure operator +(Structure s1, Parameter p1)
        {
            if (!(s1 is null) && !(p1 is null))
            {
                if (!(s1 == p1))
                {
                    s1.AddParameter(p1);
                }
            }

            return s1;
        }

        #endregion

        #region Methods

        public void AddParameter(Parameter p1)
        {
            this.listOfParamaters.Add(p1);
        }

        #endregion

    }
}
