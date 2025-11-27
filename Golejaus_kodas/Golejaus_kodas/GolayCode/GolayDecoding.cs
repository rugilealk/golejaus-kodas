using Golejaus_kodas.Helpers;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Golejaus_kodas.GolayCode
{
    internal class GolayDecoding
    {
        private byte[,] matrixH = Matrices.H;
        private byte[,] matrixB = Matrices.B;

        // returns decoded length 12 code word
        public byte[] decode(byte[] vector)
        {
            if(vector==null)
                throw new ArgumentException("Cannot decode null vector.");

            if(vector.Length!=23)
                throw new ArgumentException("Vector should be of length 23.");

            byte[] longerVector = new byte[vector.Length +1];
            for (int i = 0; i < vector.Length; ++i)
                longerVector[i] = vector[i];

            // 1. add another coordinate so that the weight of vector stays odd
            if (VectorTools.getWeight(vector) % 2 == 0)
                longerVector[vector.Length] = 1;
            else
                longerVector[vector.Length] = 0;

            // 2. get error vector
            byte[] errorVector = getErrorVector(longerVector);

            // 3. add error vector to vector to get decoded word
            byte[] decodedVector = VectorTools.addTwoVectors(longerVector, errorVector);

            // 4. take the first 12 coordinates, which are the decoded word
            byte[] word = new byte[12];
            for (int i = 0; i < 12; ++i)
                word[i] = decodedVector[i];

            return word;
        }

        // Function that return error vector, this function implements the 3.6.1 algorithm
        private byte[] getErrorVector(byte[] vector) // cis su 24 ilgio
        {
            // 1. Count sindrome
            byte[] sindrome = calculateSindrome(vector, matrixH);
            if(sindrome == null)
                throw new ArgumentException("Sindrome calculation failed.");

            // 2. If weight of sindrome is less or equal to three then we can construct the error vector
            if (VectorTools.getWeight(sindrome) <= 3)
                return constructErrorVector(sindrome, VectorTools.nullVector);

            else
            {
                // 3. Adding every matrix B row to sindrome
                (byte[] row1, int number1) = findMatrixBRow(sindrome);
                if (row1 != null)
                    return constructErrorVector(VectorTools.addTwoVectors(sindrome, row1), VectorTools.getUnitVector(number1, 12));

                else
                {
                    // 4. Count second sindrome sB 
                    byte[] sindromeB = calculateSindrome(sindrome, matrixB);

                    // 5. If weight of sindrome is less or equal to three then we can construct the error vector
                    if (VectorTools.getWeight(sindromeB) <= 3)
                        return constructErrorVector(VectorTools.nullVector, sindromeB);

                    else
                    {
                        /// 6. Adding every matrix B row to sindromeB
                        (byte[] row2, int number2) = findMatrixBRow(sindromeB);
                        if (row2 != null)
                            return constructErrorVector(VectorTools.getUnitVector(number2, 12), VectorTools.addTwoVectors(sindromeB, row2));
                        else
                            return null; // 7. ask to send again
                    }
                }
            }

        }

        private byte[] calculateSindrome(byte[] vector, byte[,] matrix)
        {
            return MatrixArithmetic.multiplyVectorMatrix(vector, matrix);
        }

        // function that constructs ErrorVector
        private byte[] constructErrorVector(byte[] sindrome, byte[] vector) //reikia nulinio vektorio, vienetinio vektoriaus
        {
            byte[] errorVector = new byte[24];
            for(int i=0; i< sindrome.Length; ++i)
                errorVector[i] = sindrome[i];

            for(int i=sindrome.Length; i< sindrome.Length + vector.Length; ++i)
                errorVector[i + sindrome.Length] = vector[i];
            
            return errorVector;
        }

        // function, that finds line of matrix B which added to sindrome results in vector with weight less than 2
        private (byte[], int) findMatrixBRow(byte[] sindrome)
        {
            int rowNumber = 0;
            byte[] row = new byte[sindrome.Length];
            int i = 0;
            bool rowNotFound = true;
            while(rowNotFound)
            {
                row = MatrixArithmetic.getMatrixRow(i + 1, matrixB);
                byte[] additionResult = new byte[sindrome.Length];
                additionResult = VectorTools.addTwoVectors(row, sindrome);
                if (VectorTools.getWeight(additionResult) <= 2)
                {
                    rowNumber = i;
                    rowNotFound = false;
                }
                ++i;
            }

            if (rowNotFound)
                return (null, 0);

            return (row, rowNumber);
        }
    }
}

//FIXME: prideti visuose failuose exceptions
//TODO: prideti GoBack button
