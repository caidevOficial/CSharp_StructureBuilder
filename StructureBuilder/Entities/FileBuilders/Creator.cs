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

using Entities.Entities;
using System.Text;

namespace Entities.FileBuilders
{
    public abstract class Creator
    {
        public Creator() { }

        /// <summary>
        /// Creates The Constructor of the structure without parameters.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected abstract short CreateBuilderEmpty(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize);

        /// <summary>
        /// Creates The Constructor of the structure with its parameters.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        protected abstract void CreateBuilderWithParams(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize);

        /// <summary>
        /// Creates the function that show an entity of the structures.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected abstract short ShowOneEntity(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize);

        /// <summary>
        /// Creates the function that show all entities of structures.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected abstract short ShowAllEntities(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize);

        /// <summary>
        /// Creates the basic functions such as Constructors, Show and ShowAll.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected abstract short CreateBasicStructFunctions(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize);

        /// <summary>
        /// Adds a parameter into the constructor's parameters.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="myParam">Parameter to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        protected virtual void AddParameterIntoConstructor(Structure myStructure, Parameter myParam, StringBuilder streamText) { }

        /// <summary>
        /// Adds parameters data to the 'parameters' of the constructor.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        protected virtual void AddParametersToConstructor(Structure myStructure, StringBuilder streamText) { }

        /// <summary>
        /// Creates the Getter of the file.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="paramA"></param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected abstract short CreateGetter(Structure myStructure, Parameter paramA, StringBuilder streamText, short packsDone, short fullPackSize);

        /// <summary>
        /// Creates the Setter of the file.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="paramA"></param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected abstract short CreateSetter(Structure myStructure, Parameter paramA, StringBuilder streamText, short packsDone, short fullPackSize);

        /// <summary>
        /// Creates the Comparer of the file.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="paramA">Parameter to extract info to make a part of the function's sign.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected abstract short CreateComparer(Structure myStructure, Parameter paramA, StringBuilder streamText, short packsDone, short fullPackSize);

        /// <summary>
        /// Creates the Comparers, Getter and Setter of the file.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected abstract short CreateGettersAndSetters(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize);

        /// <summary>
        /// Creates the function for delete the entity.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        protected abstract void CreateDeleteFunction(Structure myStructure, StringBuilder streamText);

        /// <summary>
        /// Creates and Writes the '.h' file.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        public abstract short FileMaker(Structure myStructure, short packsDone, short fullPackSize);
    }
}
