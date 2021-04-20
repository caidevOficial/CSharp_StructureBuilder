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

using Entities.AuxiliarClass;
using Entities.Entities;
using System;
using System.IO;
using System.Text;

namespace Entities.FileBuilders
{
    public sealed class CreatorDotH: Creator
    {

        public CreatorDotH() { }

        #region CreateStructure

        /// <summary>
        /// Starts to write the structure of the file.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <returns>The stringBuilder with the basic data of the structure</returns>
        private static StringBuilder CreateStructure(Structure myStructure, StringBuilder streamText)
        {
            streamText.Append($"#ifndef {myStructure.FinalStructureName.ToUpper()}_H_INCLUDED\n#define {myStructure.FinalStructureName.ToUpper()}_H_INCLUDED\n");
            streamText.Append("#include \"LinkedList.h\"\n");
            streamText.Append("\ntypedef struct{\n");
            foreach (Parameter aParameter in myStructure.ListParamaters)
            {
                if (aParameter.LengthParameter == 1)
                {
                    streamText.Append($"    {aParameter.TypeParameter} {aParameter.NameParameter};\n");
                }
                else
                {
                    streamText.Append($"    {aParameter.TypeParameter} {aParameter.NameParameter}[{aParameter.LengthParameter}];\n");
                }
            }
            streamText.Append($"}}{myStructure.FinalStructureName};\n\n");

            return streamText;
        }

        #endregion

        #region CreateConstructorAndBasicFunctions

        /// <summary>
        /// Creates The Constructor of the structure without parameters.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short CreateBuilderEmpty(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            streamText.Append($"\n// ## {myStructure.FinalStructureName}: BASIC STRUCTURE FUNCTIONS.\n");
            // Empty builder
            streamText.Append($"{myStructure.FinalStructureName}* {myStructure.AliasName}_newEmpty();\n"); // auxStrName* strShort_newEmpty();
            packsDone++;
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);

            return packsDone;
        }

        /// <summary>
        /// Creates The Constructor of the structure with its parameters.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        protected override void CreateBuilderWithParams(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            streamText.Append($"{myStructure.FinalStructureName}* {myStructure.AliasName}_new("); // auxStrName* strShort_new(parametersLine);
            AddParametersToConstructor(myStructure, streamText);
        }

        /// <summary>
        /// Creates the function that show an entity of the structures.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short ShowOneEntity(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            streamText.Append($"void {myStructure.AliasName}_show({myStructure.FinalStructureName}* {myStructure.StructureName});\n"); // void usr_show(sUser* user)
            packsDone++;
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);

            return packsDone;
        }

        /// <summary>
        /// Creates the function that show all entities of structures.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short ShowAllEntities(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            streamText.Append($"int {myStructure.AliasName}_showAll(LinkedList* this, char* errorMesage);\n\n");
            packsDone++;
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);

            return packsDone;
        }

        /// <summary>
        /// Creates the basic functions such as Constructors, Show and ShowAll.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short CreateBasicStructFunctions(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {

            // Empty builder
            packsDone = CreateBuilderEmpty(myStructure, streamText, packsDone, fullPackSize);

            // Builder with params.
            CreateBuilderWithParams(myStructure, streamText, packsDone, fullPackSize);

            // Show one
            packsDone = ShowOneEntity(myStructure, streamText, packsDone, fullPackSize);

            // Show All
            packsDone = ShowAllEntities(myStructure, streamText, packsDone, fullPackSize);

            return packsDone;
        }

        /// <summary>
        /// Adds a parameter into the constructor's parameters.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="myParam">Parameter to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        protected override void AddParameterIntoConstructor(Structure myStructure, Parameter myParam, StringBuilder streamText)
        {
            if (myParam.LengthParameter == 1)
            {
                streamText.Append($"{myParam.TypeParameter} {myParam.NameParameter}");
            }
            else
            {
                streamText.Append($"{myParam.TypeParameter}* {myParam.NameParameter}");
            }
            //TODO CHECK THIS
            if (myStructure.ListParamaters.IndexOf(myParam) != myStructure.ListParamaters.Count - 1)
            {
                streamText.Append($", ");
            }
            else
            {
                streamText.Append($");\n\n"); // this should be EOF of dotH
            }
        }

        /// <summary>
        /// Adds parameters data to the 'parameters' of the constructor.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        protected override void AddParametersToConstructor(Structure myStructure, StringBuilder streamText)
        {
            foreach (Parameter aParam in myStructure.ListParamaters)
            {
                AddParameterIntoConstructor(myStructure, aParam, streamText);
            }
        }

        #endregion

        #region CreateGettersAndSetters

        /// <summary>
        /// Creates the Getter of the file.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="paramA"></param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short CreateGetter(Structure myStructure, Parameter paramA, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            streamText.Append($"int {myStructure.AliasName}_get{paramA.AliasNameParameter}({myStructure.FinalStructureName}* {myStructure.StructureName}, {paramA.TypeParameter}* {paramA.NameParameter});\n");
            packsDone++;
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);

            return packsDone;
        }

        /// <summary>
        /// Creates the Setter of the file.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="paramA"></param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short CreateSetter(Structure myStructure, Parameter paramA, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            if (paramA.LengthParameter == 1)
            {
                streamText.Append($"int {myStructure.AliasName}_set{paramA.AliasNameParameter}({myStructure.FinalStructureName}* {myStructure.StructureName}, {paramA.TypeParameter} {paramA.NameParameter});\n");
            }
            else
            {
                streamText.Append($"int {myStructure.AliasName}_set{paramA.AliasNameParameter}({myStructure.FinalStructureName}* {myStructure.StructureName}, {paramA.TypeParameter}* {paramA.NameParameter});\n");
            }
            packsDone++;
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);

            return packsDone;
        }

        /// <summary>
        /// Creates the Comparer of the file.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="paramA">Parameter to extract info to make a part of the function's sign.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short CreateComparer(Structure myStructure, Parameter paramA, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            streamText.Append($"int {myStructure.AliasName}_compare{paramA.AliasNameParameter}(void* {myStructure.StructureName}1, void* {myStructure.StructureName}2);\n");
            packsDone++;
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);

            return packsDone;
        }

        /// <summary>
        /// Creates the Comparers, Getter and Setter of the file.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short CreateGettersAndSetters(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            streamText.Append($"// ## {myStructure.FinalStructureName}: GETTERS\n");

            foreach (Parameter aParam in myStructure.ListParamaters)
            {
                // Create Getters
                packsDone = CreateGetter(myStructure, aParam, streamText, packsDone, fullPackSize);
            }
            streamText.Append("\n");

            streamText.Append($"// ## {myStructure.FinalStructureName}: SETTERS\n");
            foreach (Parameter aParam in myStructure.ListParamaters)
            {
                // Create Setters
                packsDone = CreateSetter(myStructure, aParam, streamText, packsDone, fullPackSize);
            }
            streamText.Append("\n");

            streamText.Append($"// ## {myStructure.FinalStructureName}: COMPARERS\n");
            foreach (Parameter aParam in myStructure.ListParamaters)
            {
                // Create Comparators
                packsDone = CreateComparer(myStructure, aParam, streamText, packsDone, fullPackSize);
            }
            streamText.Append("\n");

            return packsDone;
        }

        #endregion

        #region FileMaker_DotH

        /// <summary>
        /// Creates and Writes the '.h' file.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        public override short FileMaker(Structure myStructure, short packsDone, short fullPackSize)
        {
            TextWriter pFileDotH = new StreamWriter($"{myStructure.FinalStructureName}.h");
            try
            {
                StringBuilder dataMaker = new StringBuilder();
                string curFile = $"{myStructure.FinalStructureName}.h";

                Console.WriteLine($"auxStrName: {myStructure.FinalStructureName}");
                //Console.WriteLine(File.Exists(curFile) ? "File exists." : "File does not exist.");
                Console.WriteLine($"\nAmount of steps: {fullPackSize}\nActions completed: {packsDone}\n");

                dataMaker = CreateStructure(myStructure, dataMaker);

                dataMaker.Append("#endif \n");
                dataMaker.Append("\n// # CREDITS TO:\n");
                dataMaker.Append("// ## Idea in C: Santiago Herrera.\n");
                dataMaker.Append("// ## Advanced Improvement And develop in C#: FacuFalcone - CaidevOficial.\n");
                packsDone++;
                ConsolePrinter.ShowProgress(fullPackSize, packsDone);

                packsDone = CreateBasicStructFunctions(myStructure, dataMaker, packsDone, fullPackSize);
                packsDone = CreateGettersAndSetters(myStructure, dataMaker, packsDone, fullPackSize);

                if (File.Exists(curFile))
                {
                    // if not exist, creates the file.
                    pFileDotH.Write(dataMaker);
                }

                packsDone++;
                ConsolePrinter.ShowProgress(fullPackSize, packsDone);

            }
            catch (Exception e)
            {
                //e.printStackTrace();
            }
            finally
            {
                // Here we close the file if there is an error or not.
                try
                {
                    if (!(pFileDotH is null))
                    {
                        pFileDotH.Close();
                    }
                }
                catch (Exception e2)
                {
                    //e2.printStackTrace();
                }
            }

            return packsDone;
        }

        #endregion

    }
}
