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
    public sealed class CreatorDotC : Creator {
        public CreatorDotC() : base() { }

        #region CreateHeaders

        /// <summary>
        /// Creates the imports or 'Headers' of the file.
        /// </summary>
        /// <param name="myStructure">Structure for check the parameters.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        protected override void CreateImports(Structure myStructure, StringBuilder streamText) {
            streamText.AppendLine($"#include <stdlib.h>");
            streamText.AppendLine($"#include <stdio.h>");

            if (CheckCharParam(myStructure)) {
                streamText.AppendLine($"#include <string.h>");
            }
            streamText.AppendLine($"#include \"LinkedList.h\"");
            streamText.AppendLine($"#include \"{myStructure.FinalStructureName}.h\"\n");
        }

        #endregion

        #region CreateBuilders

        /// <summary>
        /// Checks if one at least one parameter is type ''char''.
        /// </summary>
        /// <param name="myStructure">Structure for check the parameters.</param>
        /// <returns>True if at least one parameter is char-type, otherwise returns false.</returns>
        private bool CheckCharParam(Structure myStructure) {
            if (!(myStructure is null)) {
                foreach (Parameter myParam in myStructure.ListParamaters) {
                    if (myParam.TypeParameter.Equals("char")) {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Creates in the stream the basic builder of the structure.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short CreateBuilderEmpty(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize) {
            streamText.AppendLine($"{myStructure.FinalStructureName}* {myStructure.AliasName}_newEmpty(){{");
            streamText.AppendLine($"\treturn ({myStructure.FinalStructureName}*) calloc(sizeof({myStructure.FinalStructureName}),1);\n}}\n");
            packsDone++;
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);

            return packsDone;
        }

        /// <summary>
        /// Creates in the stream the builder of the structure with all the parameters.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override void CreateBuilderWithParams(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize) {

            streamText.Append($"{myStructure.FinalStructureName}* {myStructure.AliasName}_new(");
            foreach (Parameter aParam in myStructure.ListParamaters) {
                if (aParam.LengthParameter == 1) {
                    streamText.Append($"{aParam.TypeParameter} {aParam.NameParameter}");
                } else {
                    streamText.Append($"{aParam.TypeParameter}* {aParam.NameParameter}");
                }
                if (myStructure.ListParamaters.Count - 1 != myStructure.ListParamaters.IndexOf(aParam)) {
                    streamText.Append($", ");
                } else {
                    streamText.AppendLine($"){{");
                }
            }
            streamText.AppendLine($"\t{myStructure.FinalStructureName}* this = {myStructure.AliasName}_newEmpty();");
            streamText.AppendLine($"\tif(this != NULL){{");

            foreach (Parameter aParam in myStructure.ListParamaters) {
                streamText.AppendLine($"\t\t{myStructure.AliasName}_set{aParam.AliasNameParameter}(this, {aParam.NameParameter});");
            }
            streamText.AppendLine($"\t}}\n\treturn this;\n}}\n");
        }

        #endregion

        #region CreateShow

        /// <summary>
        /// Creates the nesessary infrastructure for the function 'Show'.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        public void CreateShowEntity(Structure myStructure, StringBuilder streamText) {

            streamText.AppendLine($"void {myStructure.AliasName}_show({myStructure.FinalStructureName}* this){{");
            foreach (Parameter aParam in myStructure.ListParamaters) {
                // loop through one time for auxiliar variables..
                streamText.Append($"\t{aParam.TypeParameter} {aParam.NameParameter}");
                if (aParam.TypeParameter.Equals("char")) {
                    streamText.Append($"[{aParam.LengthParameter}]");
                }
                streamText.AppendLine($";");
            }
            streamText.AppendLine("");

            // loop through for the second time to make the getters.
            foreach (Parameter aParam in myStructure.ListParamaters) {
                if (aParam.TypeParameter.Equals("char")) {
                    streamText.AppendLine($"\t{myStructure.AliasName}_get{aParam.AliasNameParameter}(this, {aParam.NameParameter});");
                } else {
                    streamText.AppendLine($"\t{myStructure.AliasName}_get{aParam.AliasNameParameter}(this, &{aParam.NameParameter});");
                }
            }
            streamText.AppendLine("");

            streamText.AppendLine($"\tif(this != NULL){{");
            streamText.Append($"\t\tprintf(\"");
            foreach (Parameter aParam in myStructure.ListParamaters) {
                if (aParam.TypeParameter.Equals("char")) {
                    streamText.Append($"%s");
                    //CASE INT
                } else if (aParam.TypeParameter.Equals("int")) {
                    streamText.Append($"%d");
                    //CASE SHORT SHORT INT
                } else if (aParam.TypeParameter.Equals("float")) {
                    streamText.Append($"%f");
                }

                if (myStructure.ListParamaters.IndexOf(aParam) != (myStructure.ListParamaters.Count - 1)) {
                    streamText.Append($"|");
                } else {
                    streamText.Append($"\\n\"");
                    foreach (Parameter theParam in myStructure.ListParamaters) {
                        streamText.Append($",{theParam.NameParameter}");
                    }

                    streamText.AppendLine($");");
                }
            }
            streamText.AppendLine($"\t\tprintf(\"-\\n\");\n\t}}\n}}\n");
        }

        /// <summary>
        /// This one Creates the nesessary infrastructure for the function 'Show'.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short ShowOneEntity(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize) {
            if (!(myStructure is null)) {
                CreateShowEntity(myStructure, streamText);
            }

            return packsDone;
        }

        /// <summary>
        /// Creates the nesessary infrastructure for the function 'ShowAll'.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        public static short CreateShowAll(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize) {

            streamText.AppendLine($"int {myStructure.AliasName}_showAll(LinkedList* this, char* errorMesage){{");
            streamText.AppendLine($"\tint length;");
            streamText.AppendLine($"\tint isError = 1;");
            streamText.AppendLine($"\t{myStructure.FinalStructureName}* {myStructure.StructureName};");
            streamText.AppendLine($"\tlength = ll_len(this);");
            streamText.AppendLine($"\tif(length>0){{");
            streamText.Append($"\t\tprintf(\"");

            foreach (Parameter myParam in myStructure.ListParamaters) {
                streamText.Append($"{myParam.NameParameter}");

                if (myStructure.ListParamaters.Count - 1 != myStructure.ListParamaters.IndexOf(myParam)) {
                    streamText.Append($"|");
                } else {
                    streamText.AppendLine($"\\n\");");
                }
            }
            streamText.AppendLine($"\t\tprintf(\"-\\n\");");
            streamText.AppendLine($"\t\tfor(int i=0; i<length; i++){{");
            streamText.AppendLine($"\t\t\t{myStructure.StructureName} = ({myStructure.FinalStructureName}*) ll_get(this,i);");
            streamText.AppendLine($"\t\t\t{myStructure.AliasName}_show({myStructure.StructureName});\n\t\t}}");
            streamText.AppendLine($"\t\tisError = 0;\n\t}}");
            streamText.AppendLine($"\telse{{");
            streamText.AppendLine($"\t\tprintf(errorMesage);\n\t}}");
            streamText.AppendLine($"\treturn isError;\n}}\n");

            packsDone++;
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);

            return packsDone;
        }

        /// <summary>
        /// This one Creates the nesessary infrastructure for the function 'ShowAll'.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short ShowAllEntities(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize) {
            if (!(myStructure is null)) {
                packsDone = CreateShowAll(myStructure, streamText, packsDone, fullPackSize);
            }

            return packsDone;
        }

        #endregion

        #region CreateBasicStructureFunctions

        /// <summary>
        /// Creates the basic functions such as Constructors, Show and ShowAll.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short CreateBasicStructFunctions(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize) {
            if (!(myStructure is null)) {

                CreatorDotH.CreateLicense(streamText);
                CreateImports(myStructure, streamText);
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
            }
            return packsDone;
        }

        #endregion

        #region CreateComparers

        /// <summary>
        /// Creates the comparer of parameters that are a char's array type
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="aParam">A parameter to extract its data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        private void CreateCompareWithChar(Structure myStructure, Parameter aParam, StringBuilder streamText) {
            streamText.AppendLine($"// For use in a sort function - Compare {myStructure.StructureName}->{aParam.NameParameter}");
            streamText.AppendLine($"int {myStructure.AliasName}_compare{aParam.AliasNameParameter}(void* this1, void* this2){{");
            streamText.AppendLine($"\tint anw;");
            // First variable
            streamText.AppendLine($"\t{aParam.TypeParameter} {aParam.NameParameter}1_1[{aParam.LengthParameter}];");
            // Second variable
            streamText.AppendLine($"\t{aParam.TypeParameter} {aParam.NameParameter}2_2[{aParam.LengthParameter}];\n");
            // First getter
            streamText.AppendLine($"\t{myStructure.AliasName}_get{aParam.AliasNameParameter}(this1, {aParam.NameParameter}1_1);");
            // Second getter
            streamText.AppendLine($"\t{myStructure.AliasName}_get{aParam.AliasNameParameter}(this2, {aParam.NameParameter}2_2);\n");
            streamText.AppendLine($"\tanw = strcmp({aParam.NameParameter}1_1,{aParam.NameParameter}2_2);");
            streamText.AppendLine($"\treturn anw;\n}}\n");
        }

        /// <summary>
        /// Creates the comparer of parameters that aren't a char's array type
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="aParam">A parameter to extract its data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        private void CreateCompareWithoutChar(Structure myStructure, Parameter aParam, StringBuilder streamText) {
            streamText.AppendLine($"// For use in a sort function - Compare {myStructure.StructureName}->{aParam.NameParameter}");
            streamText.AppendLine($"int {myStructure.AliasName}_compare{aParam.AliasNameParameter}(void* this1, void* this2){{");
            streamText.AppendLine($"\tint anw = 0;");
            // First variable
            streamText.AppendLine($"\t{aParam.TypeParameter} {aParam.NameParameter}1_1;");
            // Second variable
            streamText.AppendLine($"\t{aParam.TypeParameter} {aParam.NameParameter}2_2;\n");
            // First getter
            streamText.AppendLine($"\t{myStructure.AliasName}_get{aParam.AliasNameParameter}(this1, &{aParam.NameParameter}1_1);");
            // Second getter
            streamText.AppendLine($"\t{myStructure.AliasName}_get{aParam.AliasNameParameter}(this2, &{aParam.NameParameter}2_2);");
            // Comparator Area
            streamText.AppendLine($"\tif({aParam.NameParameter}1_1>{aParam.NameParameter}2_2){{");
            streamText.AppendLine($"\t\tanw=1;\n\t}}");
            streamText.AppendLine($"\telse if({aParam.NameParameter}1_1<{aParam.NameParameter}2_2){{");
            streamText.AppendLine($"\t\tanw=-1;\n\t}}");
            streamText.AppendLine($"\treturn anw;\n}}\n");
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
            if (paramA.LengthParameter == 1) {
                CreateCompareWithoutChar(myStructure, paramA, streamText);
            } else if (paramA.TypeParameter.Equals("char")) {
                CreateCompareWithChar(myStructure, paramA, streamText);
            }

            return packsDone;
        }

        /// <summary>
        /// Creates the comparers of all the parameters of the structure.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        private short CreateComparers(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize) {
            foreach (Parameter aParam in myStructure.ListParamaters) {
                packsDone = CreateComparer(myStructure, aParam, streamText, packsDone, fullPackSize);
            }
            packsDone++;
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);

            return packsDone;
        }

        #endregion

        #region CreateGetters

        /// <summary>
        /// Creates the getters of parameters that aren't a char's array type
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="paramA">A parameter to extract its data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        private void CreateGettersNoCharInFile(Structure myStructure, Parameter paramA, StringBuilder streamText) {
            streamText.AppendLine($"int {myStructure.AliasName}_get{paramA.AliasNameParameter}({myStructure.FinalStructureName}* this, {paramA.TypeParameter}* {paramA.NameParameter}){{");
            streamText.AppendLine($"\tint isError = 1;\n");
            streamText.AppendLine($"\tif(this != NULL){{");
            streamText.AppendLine($"\t\t*{paramA.NameParameter} = this->{paramA.NameParameter};");
            streamText.AppendLine($"\t\tisError = 0;\n\t}}");
            streamText.AppendLine($"\treturn isError;\n}}\n");
        }

        /// <summary>
        /// Creates the getters of parameters that are a char's array type
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="aParam">A parameter to extract its data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        private void CreateGettersWithCharInFile(Structure myStructure, Parameter paramA, StringBuilder streamText) {
            streamText.AppendLine($"int {myStructure.AliasName}_get{paramA.AliasNameParameter}({myStructure.FinalStructureName}* this, {paramA.TypeParameter}* {paramA.NameParameter}){{");
            streamText.AppendLine($"\tint isError = 1;");
            streamText.AppendLine($"\tif(this != NULL){{");
            streamText.AppendLine($"\t\tstrcpy({paramA.NameParameter}, this->{paramA.NameParameter});");
            streamText.AppendLine($"\t\tisError = 0;\n\t}}");
            streamText.AppendLine($"\treturn isError;\n}}\n");
        }

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
            if (paramA.LengthParameter == 1) {
                CreateGettersNoCharInFile(myStructure, paramA, streamText);
            } else if (paramA.TypeParameter.Equals("char")) {
                CreateGettersWithCharInFile(myStructure, paramA, streamText);
            }

            return packsDone;
        }

        /// <summary>
        /// Creates the getters of all the parameters of the structure.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        private short CreateGetters(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize) {
            foreach (Parameter aParam in myStructure.ListParamaters) {
                packsDone = CreateGetter(myStructure, aParam, streamText, packsDone, fullPackSize);
            }
            packsDone++;
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);

            return packsDone;
        }

        #endregion

        #region CreateSetters

        /// <summary>
        /// Creates the setters of parameters that aren't a char's array type
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="aParam">A parameter to extract its data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        private void CreateSettersNoCharInFile(Structure myStructure, Parameter aParam, StringBuilder streamText) {
            streamText.AppendLine($"int {myStructure.AliasName}_set{aParam.AliasNameParameter}({myStructure.FinalStructureName}* this, {aParam.TypeParameter} {aParam.NameParameter}){{");
            streamText.AppendLine($"\tint isError = 1;");
            streamText.AppendLine($"\tif(this != NULL){{");
            streamText.AppendLine($"\t\tthis->{aParam.NameParameter} = {aParam.NameParameter};");
            streamText.AppendLine($"\t\tisError = 0;\n\t}}");
            streamText.AppendLine($"\treturn isError;\n}}\n");
        }

        /// <summary>
        /// Creates the setter of parameters that are a char's array type
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="paramA">A parameter to extract its data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        private void CreateSettersWithCharInFile(Structure myStructure, Parameter paramA, StringBuilder streamText) {
            streamText.AppendLine($"int {myStructure.AliasName}_set{paramA.AliasNameParameter}({myStructure.FinalStructureName}* this, {paramA.TypeParameter}* {paramA.NameParameter}){{");
            streamText.AppendLine($"\tint isError = 1;");
            streamText.AppendLine($"\tif(this != NULL){{");
            streamText.AppendLine($"\t\tstrcpy(this->{paramA.NameParameter}, {paramA.NameParameter});");
            streamText.AppendLine($"\t\tisError = 0;\n\t}}");
            streamText.AppendLine($"\treturn isError;\n}}\n");
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
                CreateSettersNoCharInFile(myStructure, paramA, streamText);
            } else if (paramA.TypeParameter.Equals("char")) {
                CreateSettersWithCharInFile(myStructure, paramA, streamText);
            }

            return packsDone;
        }

        /// <summary>
        /// Creates the setters of all the parameters of the structure.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        private short CreateSetters(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize) {
            foreach (Parameter aParam in myStructure.ListParamaters) {
                packsDone = CreateSetter(myStructure, aParam, streamText, packsDone, fullPackSize);
            }
            packsDone++;
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);

            return packsDone;
        }

        #endregion

        #region CreateGetterSetter

        /// <summary>
        /// Creates the Comparers, Getter and Setter of the file.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short CreateGettersAndSetters(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize) {
            if (!(myStructure is null)) {

                streamText.AppendLine($"// ## {myStructure.FinalStructureName}: GETTERS");
                packsDone = CreateGetters(myStructure, streamText, packsDone, fullPackSize);
                streamText.AppendLine($"// ## {myStructure.FinalStructureName}: SETTERS");
                packsDone = CreateSetters(myStructure, streamText, packsDone, fullPackSize);
                streamText.AppendLine($"// ## {myStructure.FinalStructureName}: COMPARERS");
                packsDone = CreateComparers(myStructure, streamText, packsDone, fullPackSize);
            }

            return packsDone;
        }

        #endregion

        #region CreateDeleteStructure

        /// <summary>
        /// Creates the function for delete the entity.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        protected override void CreateDeleteFunction(Structure myStructure, StringBuilder streamText) {
            streamText.AppendLine($"// ## {myStructure.FinalStructureName}: DELETE");
            streamText.AppendLine($"void {myStructure.AliasName}_delete({myStructure.FinalStructureName}* this){{");
            streamText.AppendLine($"\tif(this != NULL){{");
            streamText.AppendLine($"\t\tfree(this);\n\t}}");
            streamText.AppendLine($"}}");
        }

        #endregion

        #region FileMaker

        /// <summary>
        /// Creates and Writes the '.c' file.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        public override short FileMaker(Structure myStructure, short packsDone, short fullPackSize) {
            if (!(myStructure is null)) {
                TextWriter pFileDotC = new StreamWriter($"{myStructure.FinalStructureName}.c");
                try {
                    StringBuilder dataMaker = new StringBuilder();
                    string curFile = $"{myStructure.FinalStructureName}.c";

                    packsDone = CreateBasicStructFunctions(myStructure, dataMaker, packsDone, fullPackSize);
                    packsDone = CreateGettersAndSetters(myStructure, dataMaker, packsDone, fullPackSize);
                    CreateDeleteFunction(myStructure, dataMaker);

                    if (File.Exists(curFile)) {
                        // if exist, writes the file.
                        pFileDotC.Write(dataMaker);
                    }

                } catch (Exception e) {
                    Console.WriteLine(e.StackTrace);
                }
                // Here we close the file if there is an error or not.
                try {
                    if (!(pFileDotC is null)) {
                        pFileDotC.Close();
                    }
                } catch (Exception e2) {
                    Console.WriteLine(e2.StackTrace);
                }
            }

            return packsDone;
        }

        #endregion

    }
}
