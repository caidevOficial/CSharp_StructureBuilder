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
    public sealed class CreatorDotC: Creator
    {

        public CreatorDotC() : base() { }

        #region CreateBuilders

        /// <summary>
        /// Creates in the stream the basic builder of the structure.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short CreateBuilderEmpty(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
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
        protected override void CreateBuilderWithParams(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
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
            //packsDone++;
            //ConsolePrinter.ShowProgress(fullPackSize, packsDone);

        }

        #endregion

        #region CreateComparers

        /// <summary>
        /// Creates the comparer of parameters that are a char's array type
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="aParam">A parameter to extract its data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        private void CreateCompareWithChar(Structure myStructure, Parameter aParam, StringBuilder streamText)
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
        private void CreateCompareWithoutChar(Structure myStructure, Parameter aParam, StringBuilder streamText)
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
        /// 
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="paramA">A parameter to extract its data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short CreateComparer(Structure myStructure, Parameter paramA, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            if (paramA.LengthParameter == 1)
            {
                CreateCompareWithoutChar(myStructure, paramA, streamText);
            }
            else if (paramA.TypeParameter.Equals("char"))
            {
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
        private short CreateComparers(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            foreach (Parameter aParam in myStructure.ListParamaters)
            {
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
        private void CreateGettersNoCharInFile(Structure myStructure, Parameter paramA, StringBuilder streamText)
        {
            streamText.Append($"int {myStructure.AliasName}_get{paramA.AliasNameParameter}({myStructure.FinalStructureName}* {myStructure.StructureName}, {paramA.TypeParameter}* {paramA.NameParameter}){{\n");
            streamText.Append($"    int isError = 1;\n");
            streamText.Append($"    if({myStructure.StructureName}!=NULL){{\n");
            streamText.Append($"        *{paramA.NameParameter} = {myStructure.StructureName}->{paramA.NameParameter};\n");
            streamText.Append($"        isError = 0;\n    }}\n");
            streamText.Append($"    return isError;\n}}\n\n");
        }

        /// <summary>
        /// Creates the getters of parameters that are a char's array type
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="aParam">A parameter to extract its data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        private void CreateGettersWithCharInFile(Structure myStructure, Parameter paramA, StringBuilder streamText)
        {
            streamText.Append($"int {myStructure.AliasName}_get{paramA.AliasNameParameter}({myStructure.FinalStructureName}* {myStructure.StructureName}, {paramA.TypeParameter}* {paramA.NameParameter}){{\n");
            streamText.Append($"    int isError = 1;\n");
            streamText.Append($"    if({myStructure.StructureName}!=NULL){{\n");
            streamText.Append($"        strcpy({paramA.NameParameter},{myStructure.StructureName}->{paramA.NameParameter});\n");
            streamText.Append($"        isError = 0;\n    }}\n");
            streamText.Append($"    return isError;\n}}\n\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="paramA"></param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short CreateGetter(Structure myStructure, Parameter paramA, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            if (paramA.LengthParameter == 1)
            {
                CreateGettersNoCharInFile(myStructure, paramA, streamText);
            }
            else if (paramA.TypeParameter.Equals("char"))
            {
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
        private short CreateGetters(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            foreach (Parameter aParam in myStructure.ListParamaters)
            {
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
        private void CreateSettersNoCharInFile(Structure myStructure, Parameter aParam, StringBuilder streamText)
        {
            streamText.Append($"int {myStructure.AliasName}_set{aParam.AliasNameParameter}({myStructure.FinalStructureName}* {myStructure.StructureName}, {aParam.TypeParameter} {aParam.NameParameter}){{\n");
            streamText.Append($"    int isError = 1;\n");
            streamText.Append($"    if({myStructure.StructureName}!=NULL){{\n");
            streamText.Append($"        {myStructure.StructureName}->{aParam.NameParameter} = {aParam.NameParameter};\n");
            streamText.Append($"        isError = 0;\n    }}\n");
            streamText.Append($"    return isError;\n}}\n\n");
        }

        /// <summary>
        /// Creates the setter of parameters that are a char's array type
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="paramA">A parameter to extract its data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        private void CreateSettersWithCharInFile(Structure myStructure, Parameter paramA, StringBuilder streamText)
        {
            streamText.Append($"int {myStructure.AliasName}_set{paramA.AliasNameParameter}({myStructure.FinalStructureName}* {myStructure.StructureName}, {paramA.TypeParameter}* {paramA.NameParameter}){{\n");
            streamText.Append($"    int isError = 1;\n");
            streamText.Append($"    if({myStructure.StructureName}!=NULL){{\n");
            streamText.Append($"        strcpy({myStructure.StructureName}->{paramA.NameParameter},{paramA.NameParameter});\n");
            streamText.Append($"        isError = 0;\n    }}\n");
            streamText.Append($"    return isError;\n}}\n\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="paramA">A parameter to extract its data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short CreateSetter(Structure myStructure, Parameter paramA, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            if (paramA.LengthParameter == 1)
            {
                CreateSettersNoCharInFile(myStructure, paramA, streamText);
            }
            else if (paramA.TypeParameter.Equals("char"))
            {
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
        private short CreateSetters(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            foreach (Parameter aParam in myStructure.ListParamaters)
            {
                packsDone = CreateSetter(myStructure, aParam, streamText, packsDone, fullPackSize);
            }
            packsDone++;
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);

            return packsDone;
        }

        #endregion

        #region CreateGetterSetter

        protected override short CreateGettersAndSetters(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region CreateShow

        /// <summary>
        /// Creates the nesessary infrastructure for the function 'Show'.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        public void CreateShowEntity(Structure myStructure, StringBuilder streamText)
        {
            streamText.Append($"void {myStructure.AliasName}_show({myStructure.FinalStructureName}* {myStructure.StructureName}){{\n"); // void usr_show(sUser* user)
            //FIXME: agregar auxiliares para los getters
            foreach (Parameter aParam in myStructure.ListParamaters)
            {
                // recorrer 1 vez para variables auxiliares.
                streamText.Append($" {aParam.TypeParameter} {aParam.NameParameter}");
                if (aParam.TypeParameter.Equals("char"))
                {
                    streamText.Append($"[{aParam.LengthParameter}]");
                }
                streamText.Append($";\n");
            }
            streamText.Append($"\n");

            // Recorrer por segunda vez para hacer los getters.
            foreach (Parameter aParam in myStructure.ListParamaters)
            {
                if (aParam.TypeParameter.Equals("char"))
                {
                    streamText.Append($"    {myStructure.AliasName}_get{aParam.AliasNameParameter}({myStructure.StructureName}, {aParam.NameParameter});\n");
                }
                else
                {
                    streamText.Append($"    {myStructure.AliasName}_get{aParam.AliasNameParameter}({myStructure.StructureName}, &{aParam.NameParameter});\n");
                }
            }
            streamText.Append($"\n");

            streamText.Append($"    if({myStructure.StructureName}!=NULL){{\n");
            streamText.Append($"        printf(\"");
            foreach (Parameter aParam in myStructure.ListParamaters)
            {
                if (aParam.TypeParameter.Equals("char"))
                {
                    streamText.Append($"%s");
                    //CASE INT
                }
                else if (aParam.TypeParameter.Equals("int"))
                {
                    streamText.Append($"%d");
                    //CASE SHORT SHORT INT
                }
                else if (aParam.TypeParameter.Equals("float"))
                {
                    streamText.Append($"%f");
                }

                if (myStructure.ListParamaters.IndexOf(aParam) != (myStructure.ListParamaters.Count - 1))
                {
                    streamText.Append($"|");
                }
                else
                {
                    streamText.Append($"\\n\"");
                    foreach (Parameter theParam in myStructure.ListParamaters)
                    {
                        streamText.Append($",{theParam.NameParameter}");
                    }

                    streamText.Append($");\n");
                }
            }
            streamText.Append($"        printf(\"-\\n\");\n    }}\n}}\n\n");
        }

        /// <summary>
        /// This one Creates the nesessary infrastructure for the function 'Show'.
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short ShowOneEntity(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            CreateShowEntity(myStructure, streamText);

            return packsDone;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        public static short CreateShowAll(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            streamText.Append($"int {myStructure.AliasName}_showAll(LinkedList* this, char* errorMesage){{\n");
            streamText.Append($"    int length;\n");
            streamText.Append($"    int isError = 1;\n");
            streamText.Append($"    {myStructure.FinalStructureName}* {myStructure.StructureName};\n");
            streamText.Append($"    length = ll_len(this);\n");
            streamText.Append($"    if(length>0){{\n");
            streamText.Append($"        printf(\"");
            
            foreach(Parameter myParam in myStructure.ListParamaters)
            {
                streamText.Append($"{myParam.NameParameter}");

                if (myStructure.ListParamaters.Count - 1 != myStructure.ListParamaters.IndexOf(myParam))
                {
                    streamText.Append($"|");
                }
                else
                {
                    streamText.Append($"\\n\");\n");
                }
            }
            streamText.Append($"        printf(\"-\\n\");\n");
            streamText.Append($"        for(int i=0; i<length; i++){{\n");
            streamText.Append($"            {myStructure.StructureName} = ({myStructure.FinalStructureName}*) ll_get(this,i);\n");
            streamText.Append($"            {myStructure.AliasName}_show({myStructure.StructureName});\n        }}\n");
            streamText.Append($"        isError = 0;\n    }}\n");
            streamText.Append($"    else{{\n");
            streamText.Append($"        printf(errorMesage);\n    }}\n");
            streamText.Append($"    return isError;\n}}\n");

            packsDone++;
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);
            
            return packsDone;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myStructure">Structure to extract the data.</param>
        /// <param name="streamText">A stringBuilder to write the data.</param>
        /// <param name="packsDone">Amount of steps done.</param>
        /// <param name="fullPackSize">Amount of total steps to do.</param>
        /// <returns>The amount of steps done.</returns>
        protected override short ShowAllEntities(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            packsDone = CreateShowAll(myStructure, streamText, packsDone, fullPackSize);

            return packsDone;
        }

        #endregion

        #region CreateBasicStructureFunctions

        protected override short CreateBasicStructFunctions(Structure myStructure, StringBuilder streamText, short packsDone, short fullPackSize)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region AddParametersToStructure

        protected override void AddParameterIntoConstructor(Structure myStructure, Parameter myParam, StringBuilder streamText)
        {
            throw new System.NotImplementedException();
        }

        protected override void AddParametersToConstructor(Structure myStructure, StringBuilder streamText)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region FileMaker

        public override short FileMaker(Structure myStructure, short packsDone, short fullPackSize)
        {
            throw new System.NotImplementedException();
        }

        #endregion

    }
}
