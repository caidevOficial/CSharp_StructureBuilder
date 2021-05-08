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
using Entities;
using System;
using System.IO;
using System.Text;

namespace FileBuilders {
    public sealed class CreatorDotH : Creator {
        public CreatorDotH() { }

        #region CreateHeaders

        /// <summary>
        /// Writes in the file a license MIT-type
        /// </summary>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        public static void CreateLicense(StringBuilder streamText) {
            streamText.AppendLine("/*");
            streamText.AppendLine(" * MIT License");
            streamText.AppendLine(" *");
            streamText.AppendLine(" * Copyright (c) 2021 [FacuFalcone]");
            streamText.AppendLine(" *");
            streamText.AppendLine(" * Permission is hereby granted, free of charge, to any person obtaining a copy");
            streamText.AppendLine(" * of this software and associated documentation files (the \"Software\"), to deal");
            streamText.AppendLine(" * in the Software without restriction, including without limitation the rights");
            streamText.AppendLine(" * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell");
            streamText.AppendLine(" * copies of the Software, and to permit persons to whom the Software is ");
            streamText.AppendLine(" * furnished to do so, subject to the following conditions: ");
            streamText.AppendLine(" * ");
            streamText.AppendLine(" * The above copyright notice and this permission notice shall be included in all");
            streamText.AppendLine(" * copies or substantial portions of the Software.");
            streamText.AppendLine(" * ");
            streamText.AppendLine(" * THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR");
            streamText.AppendLine(" * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,");
            streamText.AppendLine(" * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE");
            streamText.AppendLine(" * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER");
            streamText.AppendLine(" * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,");
            streamText.AppendLine(" * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE");
            streamText.AppendLine(" * SOFTWARE.");
            streamText.AppendLine(" */\n");
        }

        /// <summary>
        /// Creates the imports or 'Headers' of the file.
        /// </summary>
        /// <param name="myStructure">Structure for check the parameters.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        protected override void CreateImports(Structure myStructure, StringBuilder streamText) {
            streamText.AppendLine($"#ifndef {myStructure.FinalStructureName.ToUpper()}_H_INCLUDED\n#define {myStructure.FinalStructureName.ToUpper()}_H_INCLUDED");
            streamText.AppendLine("#include \"LinkedList.h\"");
        }

        #endregion

        #region CreateStructure

        /// <summary>
        /// Starts to write the structure of the file.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <returns>The stringBuilder with the basic data of the structure</returns>
        private void CreateStructure(Structure myStructure, StringBuilder streamText) {
            CreateImports(myStructure, streamText);
            streamText.AppendLine("\ntypedef struct{");
            foreach (Parameter aParameter in myStructure.ListParamaters) {
                if (aParameter.LengthParameter == 1) {
                    streamText.AppendLine($"\t{aParameter.TypeParameter} {aParameter.NameParameter};");
                } else {
                    streamText.AppendLine($"\t{aParameter.TypeParameter} {aParameter.NameParameter}[{aParameter.LengthParameter}];");
                }
            }
            streamText.AppendLine($"}}{myStructure.FinalStructureName};\n");
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
        protected override short CreateBuilderEmpty(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize) {
            // Empty builder
            streamText.AppendLine($"{myStructure.FinalStructureName}* {myStructure.AliasName}_newEmpty();"); // auxStrName* strShort_newEmpty();
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
        protected override void CreateBuilderWithParams(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize) {
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
        protected override short ShowOneEntity(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize) {
            streamText.AppendLine($"void {myStructure.AliasName}_show({myStructure.FinalStructureName}* {myStructure.StructureName});"); // void usr_show(sUser* user)
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
        protected override short ShowAllEntities(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize) {
            streamText.AppendLine($"int {myStructure.AliasName}_showAll(LinkedList* this, char* errorMesage);\n");
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
        protected override short CreateBasicStructFunctions(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize) {

            streamText.AppendLine($"// ## {myStructure.FinalStructureName}: CONSTRUCTORS.");
            // Empty builder
            packsDone = CreateBuilderEmpty(myStructure, streamText, packsDone, fullPackSize);

            // Builder with params.
            CreateBuilderWithParams(myStructure, streamText, packsDone, fullPackSize);

            streamText.AppendLine($"// ## {myStructure.FinalStructureName}: SHOW & SHOW_ALL.");
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
        protected override void AddParameterIntoConstructor(Structure myStructure, Parameter myParam, StringBuilder streamText) {
            if (myParam.LengthParameter == 1) {
                streamText.Append($"{myParam.TypeParameter} {myParam.NameParameter}");
            } else {
                streamText.Append($"{myParam.TypeParameter}* {myParam.NameParameter}");
            }
            //TODO CHECK THIS
            if (myStructure.ListParamaters.IndexOf(myParam) != myStructure.ListParamaters.Count - 1) {
                streamText.Append($", ");
            } else {
                streamText.AppendLine($");\n"); // this should be EOF of dotH
            }
        }

        /// <summary>
        /// Adds parameters data to the 'parameters' of the constructor.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        protected override void AddParametersToConstructor(Structure myStructure, StringBuilder streamText) {
            foreach (Parameter aParam in myStructure.ListParamaters) {
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
        protected override short CreateGetter(Structure myStructure, Parameter paramA, StringBuilder streamText, short packsDone, short fullPackSize) {
            streamText.AppendLine($"int {myStructure.AliasName}_get{paramA.AliasNameParameter}({myStructure.FinalStructureName}* {myStructure.StructureName}, {paramA.TypeParameter}* {paramA.NameParameter});");
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
        protected override short CreateSetter(Structure myStructure, Parameter paramA, StringBuilder streamText, short packsDone, short fullPackSize) {
            if (paramA.LengthParameter == 1) {
                streamText.AppendLine($"int {myStructure.AliasName}_set{paramA.AliasNameParameter}({myStructure.FinalStructureName}* {myStructure.StructureName}, {paramA.TypeParameter} {paramA.NameParameter});");
            } else {
                streamText.AppendLine($"int {myStructure.AliasName}_set{paramA.AliasNameParameter}({myStructure.FinalStructureName}* {myStructure.StructureName}, {paramA.TypeParameter}* {paramA.NameParameter});");
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
        protected override short CreateComparer(Structure myStructure, Parameter paramA, StringBuilder streamText, short packsDone, short fullPackSize) {
            streamText.AppendLine($"int {myStructure.AliasName}_compare{paramA.AliasNameParameter}(void* {myStructure.StructureName}1, void* {myStructure.StructureName}2);");
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
        protected override short CreateGettersAndSetters(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize) {
            streamText.AppendLine($"// ## {myStructure.FinalStructureName}: GETTERS");

            foreach (Parameter aParam in myStructure.ListParamaters) {
                // Create Getters
                packsDone = CreateGetter(myStructure, aParam, streamText, packsDone, fullPackSize);
            }
            streamText.AppendLine("");

            streamText.AppendLine($"// ## {myStructure.FinalStructureName}: SETTERS");
            foreach (Parameter aParam in myStructure.ListParamaters) {
                // Create Setters
                packsDone = CreateSetter(myStructure, aParam, streamText, packsDone, fullPackSize);
            }
            streamText.AppendLine("");

            streamText.AppendLine($"// ## {myStructure.FinalStructureName}: COMPARERS");
            foreach (Parameter aParam in myStructure.ListParamaters) {
                // Create Comparators
                packsDone = CreateComparer(myStructure, aParam, streamText, packsDone, fullPackSize);
            }
            streamText.AppendLine("");

            return packsDone;
        }

        #endregion

        #region CreateDeleteFunction

        /// <summary>
        /// Creates the function for delete the entity.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        protected override void CreateDeleteFunction(Structure myStructure, StringBuilder streamText) {
            streamText.AppendLine($"// ## {myStructure.FinalStructureName}: DELETE");
            streamText.AppendLine($"void {myStructure.AliasName}_delete({myStructure.FinalStructureName}* this);");
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
        public override short FileMaker(Structure myStructure, short packsDone, short fullPackSize) {
            if (!(myStructure is null)) {
                TextWriter pFileDotH = new StreamWriter($"{myStructure.FinalStructureName}.h");
                try {
                    StringBuilder dataMaker = new StringBuilder();
                    string curFile = $"{myStructure.FinalStructureName}.h";

                    Console.WriteLine($"Final Structure Name: {myStructure.FinalStructureName}");
                    Console.WriteLine($"\nAmount of steps: {fullPackSize}\nActions completed: {packsDone}\n");

                    CreateLicense(dataMaker);
                    CreateStructure(myStructure, dataMaker);

                    dataMaker.AppendLine("#endif\n");
                    dataMaker.AppendLine("// # CREDITS TO:");
                    dataMaker.AppendLine("// ## Advanced Improvement And develop in C#: FacuFalcone - CaidevOficial.");
                    dataMaker.AppendLine("// ## Follow me on -> github.com/CaidevOficial\n");
                    packsDone++;
                    ConsolePrinter.ShowProgress(fullPackSize, packsDone);

                    packsDone = CreateBasicStructFunctions(myStructure, dataMaker, packsDone, fullPackSize);
                    packsDone = CreateGettersAndSetters(myStructure, dataMaker, packsDone, fullPackSize);
                    CreateDeleteFunction(myStructure, dataMaker);

                    if (File.Exists(curFile)) {
                        // if exist the file, writes.
                        pFileDotH.Write(dataMaker);
                    }

                    packsDone++;
                    ConsolePrinter.ShowProgress(fullPackSize, packsDone);

                } catch (Exception e) {
                    Console.WriteLine(e.StackTrace);
                    throw new Exception("Something get wrong in CreatorDotH.cs", e);
                } finally {
                    // Here we close the file if there is an error or not.
                    try {
                        if (!(pFileDotH is null)) {
                            pFileDotH.Close();
                        }
                    } catch (Exception e2) {
                        Console.WriteLine(e2.StackTrace);
                        throw new Exception("Maybe the file is null in CreatorDotH.cs", e2);
                    }
                }
            }

            return packsDone;
        }

        #endregion

    }
}
