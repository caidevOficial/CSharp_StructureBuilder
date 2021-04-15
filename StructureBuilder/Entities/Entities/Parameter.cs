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

namespace Entities.Entities
{
    public sealed class Parameter
    {
        private short idParameter;
        private int lengthParameter;
        private string typeParameter;
        private string nameParameter;
        private string aliasNameParameter;

        #region Builders

        public Parameter()
        {

        }

        public Parameter(short idParameter) : this()
        {
            IdParameter = idParameter;
        }

        public Parameter(short idParameter, int lengthParameter) : this(idParameter)
        {
            this.LengthParameter = lengthParameter;
        }

        public Parameter(short idParameter, int lengthParameter, string nameParameter) : this(idParameter, lengthParameter)
        {
            this.NameParameter = nameParameter;
        }

        public Parameter(short idParameter, int lengthParameter, string typeParameter, string nameParameter) : this(idParameter, lengthParameter, nameParameter)
        {
            this.TypeParameter = typeParameter;
        }

        public Parameter(short idParameter, int lengthParameter, string typeParameter, string nameParameter, string aliasNameParameter) : this(idParameter, lengthParameter, typeParameter, nameParameter)
        {
            this.AliasNameParameter = aliasNameParameter;
        }

        #endregion

        #region Properties

        public string TypeParameter
        {
            get => typeParameter;
            set
            {
                if (!(value is null))
                {
                    typeParameter = value;
                }
            }
        }
        public string NameParameter
        {
            get => nameParameter;
            set
            {
                if (!(value is null))
                {
                    nameParameter = value;
                }
            }
        }
        public string AliasNameParameter
        {
            get => aliasNameParameter;
            set
            {
                if (!(value is null))
                {
                    aliasNameParameter = value;
                }
            }
        }
        public int LengthParameter
        {
            get => lengthParameter;
            set
            {
                if (value > 0)
                {
                    lengthParameter = value;
                }
            }
        }
        public short IdParameter
        {
            get => idParameter;
            set
            {
                if (value > 0)
                {
                    idParameter = value;
                }
            }
        }

        #endregion

        #region Operators

        public static bool operator ==(Parameter p1, Parameter p2)
        {
            return p1.IdParameter == p2.IdParameter;
        }

        public static bool operator !=(Parameter p1, Parameter p2)
        {
            return !(p1 == p2);
        }

        #endregion

    }
}
