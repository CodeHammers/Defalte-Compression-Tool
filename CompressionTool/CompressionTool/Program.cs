﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressionTool
{
    class Program
    {
        static void Main(string[] args)
        {
            double TotalTime = 0.0;

            for (int file = 1; file <= 20; file++)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                string FileName = "DataSet_" + file.ToString();

                InputReader InputReader = new InputReader(FileName);
                string Text = InputReader.GetFileContent();

                Probability Probability = new Probability(Text);
                Dictionary<char, int> CharactersCount = Probability.GetCharactersCount();

                HuffmanEncoder HuffmanEncoder = new HuffmanEncoder();
                HuffmanEncoder.Encode(CharactersCount, Text, FileName);

                Console.WriteLine("Encoded {0} symbol", Text.Length);

                HuffmanDecoder HuffmanDecoder = new HuffmanDecoder();
                HuffmanDecoder.Decode(FileName);

                Console.WriteLine("\nDecoded {0} symbol", Text.Length);

                Console.Write("File number {0} finished in ", file);
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                double Secs = (double)elapsedMs / 1000.0;
                Console.WriteLine("{0} secs", Secs);

                TotalTime += Secs;

                Console.WriteLine("=====================================================");
                Console.WriteLine("=====================================================");
            }

            Console.WriteLine("Compression/decompression of all 20 files done in {0} secs", TotalTime);
        }
    }
}
