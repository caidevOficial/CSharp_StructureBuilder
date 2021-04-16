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
using System.Text;

namespace Entities.FileBuilders
{
    public sealed class CreatorDotC
    {

        #region CreateBuilders

        /// <summary>
        /// Creates in the stream the basic builder of the structure.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        private static int CreateBuilderEmpty(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            streamText.Append($"\n{myStructure.FinalStructureName}* {myStructure.AliasName}_newEmpty(){{ \n"); // sUser* usr_newEmpty()
            streamText.Append($"    return ({myStructure.FinalStructureName}*) calloc(sizeof({myStructure.FinalStructureName}),1);\n}}\n\n"); // return (sUser*) malloc(sizeof(sUser));
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
        private static int CreateBuilderWithParams(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            streamText.Append($"{myStructure.FinalStructureName}* {myStructure.AliasName}_new("); // auxStrName* strShort_new(parametersLine);
            foreach (Parameter aParam in myStructure.ListParamaters)
            {
                if (aParam.LengthParameter == 1)
                {
                    streamText.Append($"{aParam.TypeParameter} {aParam.NameParameter}");
                }
                else
                {
                    streamText.Append($"{aParam.TypeParameter}* {aParam.NameParameter}");
                }
                if (myStructure.ListParamaters.Count - 1 != myStructure.ListParamaters.IndexOf(aParam))
                {
                    streamText.Append($", ");
                }
                else
                {
                    streamText.Append($"){{\n");
                }
            }
            streamText.Append($"    {myStructure.FinalStructureName}* {myStructure.StructureName} = {myStructure.AliasName}_newEmpty();\n");
            streamText.Append($"    if({myStructure.StructureName}!=NULL){{\n");

            foreach (Parameter aParam in myStructure.ListParamaters)
            {
                streamText.Append($"        {myStructure.AliasName}_set{aParam.AliasNameParameter}({myStructure.StructureName}, {aParam.NameParameter});\n"); // usr_setId(user,id);
            }
            streamText.Append($"    }}\n    return {myStructure.StructureName};\n{{\n\n");
            packsDone++;
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);

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
        private static void CreateCompareWithChar(Structure myStructure, Parameter aParam, StringBuilder streamText)
        {
            streamText.Append($"// For use in a sort function - Compare {myStructure.StructureName}->{aParam.NameParameter}\n");
            streamText.Append($"int {myStructure.AliasName}_compare{aParam.AliasNameParameter}(void* {myStructure.StructureName}1, void* {myStructure.StructureName}2){{\n");
            streamText.Append($"    int anw;\n");
            // First variable
            streamText.Append($"    {aParam.TypeParameter} {aParam.NameParameter}1_1[{aParam.LengthParameter}];\n");
            // Second variable
            streamText.Append($"    {aParam.TypeParameter} {aParam.NameParameter}2_2[{aParam.LengthParameter}];\n\n");
            // First getter
            streamText.Append($"    {myStructure.AliasName}_get{aParam.AliasNameParameter}({myStructure.StructureName}1, {aParam.NameParameter}1_1);\n");
            // Second getter
            streamText.Append($"    {myStructure.AliasName}_get{aParam.AliasNameParameter}({myStructure.StructureName}2, {aParam.NameParameter}2_2);\n\n");
            streamText.Append($"    anw = strcmp({aParam.NameParameter}1_1,{aParam.NameParameter}2_2);\n");
            streamText.Append($"    return anw;\n}}\n\n");
        }

        /// <summary>
        /// Creates the comparer of parameters that aren't a char's array type
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="aParam">A parameter to extract its data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        private static void CreateCompareWithoutChar(Structure myStructure, Parameter aParam, StringBuilder streamText)
        {
            streamText.Append($"// For use in a sort function - Compare {myStructure.StructureName}->{aParam.NameParameter}\n");
            streamText.Append($"int {myStructure.AliasName}_compare{aParam.AliasNameParameter}(void* {myStructure.StructureName}1, void* {myStructure.StructureName}2){{\n");
            streamText.Append($"    int anw = 0;\n");
            // First variable
            streamText.Append($"    {aParam.TypeParameter} {aParam.NameParameter}1_1;\n");
            // Second variable
            streamText.Append($"    {aParam.TypeParameter} {aParam.NameParameter}2_2;\n\n");
            // First getter
            streamText.Append($"    {myStructure.AliasName}_get{aParam.AliasNameParameter}({myStructure.StructureName}1, &{aParam.NameParameter}1_1);\n");
            // Second getter
            streamText.Append($"    {myStructure.AliasName}_get{aParam.AliasNameParameter}({myStructure.StructureName}2, &{aParam.NameParameter}2_2);\n");
            // Comparator Area
            streamText.Append($"    if({aParam.NameParameter}1_1>{aParam.NameParameter}2_2){{\n");
            streamText.Append($"        anw=1;\n    }}\n");
            streamText.Append($"    else if({aParam.NameParameter}1_1<{aParam.NameParameter}2_2){{\n");
            streamText.Append($"        anw=-1;\n    }}\n");
            streamText.Append($"    return anw;\n}}\n\n");
        }

        /// <summary>
        /// Creates the comparers of all the parameters of the structure.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        private static short CreateComparers(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            foreach (Parameter aParam in myStructure.ListParamaters)
            {
                if (aParam.LengthParameter == 1)
                {
                    CreateCompareWithoutChar(myStructure, aParam, streamText);
                }
                else if (aParam.TypeParameter.Equals("char"))
                {
                    CreateCompareWithChar(myStructure, aParam, streamText);
                }
            }
            packsDone++;
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);

            return packsDone;
        }

        #endregion
    }
}
