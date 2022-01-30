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

using AuxiliarClass;

namespace Entities {
    public sealed class Parameter {

        #region Attributes

        private short idParameter;
        private int lengthParameter;
        private string typeParameter;
        private string nameParameter;
        private string aliasNameParameter;

        #endregion

        #region Builders

        /// <summary>
        /// Builds the entity without parameters.
        /// </summary>
        public Parameter() { }

        /// <summary>
        /// Builds the entity with the id.
        /// </summary>
        /// <param name="idParameter">ID/PK of the entity.</param>
        public Parameter(short idParameter) : this() {
            IdParameter = idParameter;
        }

        /// <summary>
        /// Builds the entity with the name and the id.
        /// </summary>
        /// <param name="idParameter">ID/PK of the entity.</param>
        /// /// <param name="nameParameter">Name of the parameter.</param>
        public Parameter(short idParameter, string nameParameter)
            : this(idParameter) {
            NameParameter = nameParameter;
        }

        /// <summary>
        /// Builds the entity with the name, id and type.
        /// </summary>
        /// <param name="idParameter">ID/PK of the entity.</param>
        /// <param name="nameParameter">Name of the parameter.</param>
        /// <param name="typeParameter">Type of the parameter.</param>
        public Parameter(short idParameter, string nameParameter, string typeParameter)
            : this(idParameter, nameParameter) {
            TypeParameter = typeParameter;
        }

        /// <summary>
        /// Builds the entity with the id, name type and the length.
        /// </summary>
        /// <param name="idParameter">ID/PK of the entity.</param>
        /// <param name="nameParameter">Name of the parameter.</param>
        /// <param name="typeParameter">Type of the parameter.</param>
        /// <param name="lengthParameter">Length of the parameter.</param>
        public Parameter(short idParameter, string nameParameter, string typeParameter, int lengthParameter)
            : this(idParameter, nameParameter, typeParameter) {
            LengthParameter = lengthParameter;
        }

        /// <summary>
        /// Builds the entity with the id, name type, the length and the alias.
        /// </summary>
        /// <param name="idParameter">ID/PK of the entity.</param>
        /// <param name="nameParameter">Name of the parameter.</param>
        /// <param name="typeParameter">Type of the parameter.</param>
        /// <param name="lengthParameter">Length of the parameter.</param>
        /// <param name="aliasNameParameter">Alias - Short name of the parameter.</param>
        public Parameter(short idParameter, string nameParameter, string typeParameter, int lengthParameter, string aliasNameParameter)
            : this(idParameter, nameParameter, typeParameter, lengthParameter) {
            AliasNameParameter = aliasNameParameter;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get: Gets the type of the parameter.
        /// Set: Sets the type of the parameter.
        /// </summary>
        public string TypeParameter {
            get => typeParameter;
            set {
                if (!(value is null)) {
                    typeParameter = value;
                }
            }
        }

        /// <summary>
        /// Get: Gets the name of the parameter.
        /// Set: Sets the name of the parameter.
        /// </summary>
        public string NameParameter {
            get => nameParameter;
            set {
                if (!(value is null)) {
                    nameParameter = value.Decapitalize();
                }
            }
        }

        /// <summary>
        /// Get: Gets the alias of the parameter.
        /// Set: Sets the alias of the parameter.
        /// </summary>
        public string AliasNameParameter {
            get => aliasNameParameter;
            set {
                if (!(value is null)) {
                    aliasNameParameter = DataCollector.ParameterAliasCollector(value);
                }
            }
        }

        /// <summary>
        /// Get: Gets the length of the parameter.
        /// Set: Sets the length of the parameter.
        /// </summary>
        public int LengthParameter {
            get => lengthParameter;
            set {
                if (value > 0) {
                    lengthParameter = value;
                }
            }
        }

        /// <summary>
        /// Get: Gets the id of the parameter.
        /// Set: Sets the id of the parameter.
        /// </summary>
        public short IdParameter {
            get => idParameter;
            set {
                if (value > 0) {
                    idParameter = value;
                }
            }
        }

        #endregion

        #region Operators

        /// <summary>
        /// Checks if both parameters are equals.
        /// </summary>
        /// <param name="p1">First parameter to check.</param>
        /// <param name="p2">Second parameter to check.</param>
        /// <returns>True if both are equals, otherwise returns false.</returns>
        public static bool operator ==(Parameter p1, Parameter p2) {
            return p1.IdParameter == p2.IdParameter;
        }

        /// <summary>
        /// Checks if both parameters aren't equals.
        /// </summary>
        /// <param name="p1">First parameter to check.</param>
        /// <param name="p2">Second parameter to check.</param>
        /// <returns>True if both aren't equals, otherwise returns false.</returns>
        public static bool operator !=(Parameter p1, Parameter p2) {
            return !(p1 == p2);
        }

        #endregion

    }
}
