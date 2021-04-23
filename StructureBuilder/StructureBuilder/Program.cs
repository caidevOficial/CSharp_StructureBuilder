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
using Entities.FileBuilders;
using System;

namespace StructureBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            CreatorDotH makerH = new CreatorDotH();
            CreatorDotC makerC = new CreatorDotC();
            Structure myStructure = new Structure();
            string appVersion = "Structure Builder [v1.2.0.1]";
            short fullPackSize = 8; // Basic functions struct newEmpty + new + show + showall
            short auxParNum = 6; // Basic functions by parameter com + get + set
            short packsDone = 0;

            Console.WriteLine(appVersion);
            myStructure.StructureName = DataCollector.StructureNameCollector();
            myStructure.AliasName = DataCollector.StructureAliasCollector(myStructure.StructureName);
            myStructure.FinalStructureName = myStructure.AliasName;

            DataCollector.AddParameterToStructure(myStructure);

            auxParNum *= (short)myStructure.ListParamaters.Count;
            fullPackSize += auxParNum;
            ConsolePrinter.ShowProgress(fullPackSize, packsDone);

            packsDone = makerH.FileMaker(myStructure, packsDone, fullPackSize);
            packsDone = makerC.FileMaker(myStructure, packsDone, fullPackSize);

            ConsolePrinter.ShowProgress(fullPackSize, packsDone);

            Console.ReadKey();
        }
    }
}
