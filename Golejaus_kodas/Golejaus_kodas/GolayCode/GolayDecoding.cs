using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Golejaus_kodas.Helpers;


namespace Golejaus_kodas.GolayCode
{
    internal class GolayDecoding
    {
        private byte[,] matrixH = new Matrices().H;
        private byte[,] matrixB = new Matrices().B;
        private VectorTools vectorTools = new VectorTools();

        private MatrixArithmetic matrixArithmetic = new MatrixArithmetic();
        public byte[] findErrorVector(byte[] vector) // cis su 24 ilgio
        {
            byte[] sindrome = calculateSindrome(vector, matrixH);
            if(sindrome == null)
                throw new ArgumentException("Sindrome calculation failed.");

            int weight = vectorTools.vectorWeight(sindrome);
            if (weight <= 3)
                return constructErrorVector(sindrome, 0);

        }

        private byte[] calculateSindrome(byte[] vector, byte[,] matrix)
        {
            return matrixArithmetic.multiplyVectorMatrix(vector, matrix);
        }

        public byte[] constructErrorVector(byte[] sindrome, byte[] vector) //reikia nulinio vektorio, vienetinio vektoriaus
        {
            byte[] errorVector = new byte[24];
            for(int i=0; i< sindrome.Length; ++i)
                errorVector[i] = sindrome[i];

            for(int i=sindrome.Length; i< sindrome.Length + vector.Length; ++i)
                errorVector[i + sindrome.Length] = vector[i];
            
            return errorVector;
        }
    }
}
