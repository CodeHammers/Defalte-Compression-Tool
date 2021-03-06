﻿
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CompressionTool
{
    class InputReader
    {
        public InputReader()
        {
            //empty
        }

        public string ReadOriginalFile(string FileName)
        {
            string FilePath = @"..\..\Dataset\" + FileName + ".tsv";

            return File.ReadAllText(FilePath); 
        }

        public Dictionary<char, byte> ReadSymbolDictionary()
        {
            byte id = 0;

            Dictionary<char, byte> Alphabet = new Dictionary<char, byte>();

            string Text = File.ReadAllText(@"..\..\SymbolDictionary.txt", Encoding.UTF8);

            for (int i = 0; i < Text.Length; i++)
            {
                if (Alphabet.ContainsKey(Text[i]))
                    continue;

                Alphabet.Add(Text[i], id);
                id++;
            }

            return Alphabet;
        }
    }
}
