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
        private string structureName;
        private string finalStructureName;
        private string aliasShortName;
        private List<Parameter> listOfParamaters;

        #region Builders

        /// <summary>
        /// Initializes the list of parameters.
        /// </summary>
        public Structure()
        {
            listOfParamaters = new List<Parameter>();
        }

        /// <summary>
        /// Builds the entity with the name.
        /// </summary>
        /// <param name="structureName">Name of the entity.</param>
        public Structure(string structureName) : this()
        {
            StructureName = structureName;
        }

        /// <summary>
        /// Builds the entity with the name and the alias.
        /// </summary>
        /// <param name="structureName">Name of the entity.</param>
        /// <param name="aliasShortName">Short Name (Alias) of the entity.</param>
        public Structure(string structureName, string aliasShortName) : this(structureName)
        {
            AliasName = aliasShortName;
        }

        /// <summary>
        /// Builds the entity with all its parameters.
        /// </summary>
        /// <param name="structureName">Name of the entity.</param>
        /// <param name="aliasShortName">Short Name (Alias) of the entity.</param>
        /// <param name="finalStructureName">Final name of the entity, it will have an 's' at the beginning of the name.</param>
        public Structure(string structureName, string aliasShortName, string finalStructureName) : this(structureName, aliasShortName)
        {
            FinalStructureName = finalStructureName;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get: Gets the list of parameters of the entity.
        /// </summary>
        public List<Parameter> ListParamaters
        {
            get => listOfParamaters;
        }

        /// <summary>
        /// Get: Gets the name of the entity.
        /// Set: Sets the name of the entity.
        /// </summary>
        public string StructureName
        {
            get => structureName;
            set
            {
                if (!(value is null))
                {
                    structureName = value;
                }
            }
        }

        /// <summary>
        /// Get: Gets the final name of the entity.
        /// Set: Sets the final name of the entity.
        /// </summary>
        public string FinalStructureName
        {
            get => finalStructureName;
            set
            {
                if (!(value is null))
                {
                    finalStructureName = value;
                }
            }
        }

        /// <summary>
        /// Get: Gets the alias of the entity.
        /// Set: Sets the alias of the entity.
        /// </summary>
        public string AliasName
        {
            get => aliasShortName;
            set
            {
                if (!(value is null))
                {
                    aliasShortName = value;
                }
            }
        }

        #endregion

        #region Operators

        /// <summary>
        /// Compares if the parameter is inside the list of parameters of the entity.
        /// </summary>
        /// <param name="s1">Structure to check its list of parameters.</param>
        /// <param name="p1">Parameter to verify if is inside the list of the structure.</param>
        /// <returns>True if the parameter is in the list, otherwise returns false.</returns>
        public static bool operator ==(Structure s1, Parameter p1)
        {
            if (!(s1 is null || p1 is null))
            {
                foreach (Parameter aParameter in s1.ListParamaters)
                {
                    if (p1 == aParameter)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Compares if the parameter isn't inside the list of parameters of the entity.
        /// </summary>
        /// <param name="s1">Structure to check its list of parameters.</param>
        /// <param name="p1">Parameter to verify if isn't inside the list of the structure.</param>
        /// <returns>True if the parameter isn't in the list, otherwise returns false.</returns>
        public static bool operator !=(Structure s1, Parameter p1)
        {
            return !(s1 == p1);
        }

        /// <summary>
        /// Tries to add a parameter inside the list of the structure.
        /// </summary>
        /// <param name="s1">Structure to check its list of parameters.</param>
        /// <param name="p1">Parameter to try to add in the list of the structure.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds a parameter in the list of parameters of the structure.
        /// </summary>
        /// <param name="p1">Parameter to add in the list.</param>
        public void AddParameter(Parameter p1)
        {
            this.listOfParamaters.Add(p1);
        }

        #endregion

    }
}
