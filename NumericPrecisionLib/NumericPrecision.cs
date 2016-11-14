using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NumericPrecisionLib
{
    public class NumericPrecision
    {
        #region ELEMENTARY OPERATIONS

        public BigInteger internalNum1;
        public BigInteger internalNum2;

        public int num1DecimalPlace = 0;
        public int num2DecimalPlace = 0;
        public int greaterDecimalPlace = 0;
        public int productDecimalPlace = 0;

        public bool isNum1Decimal, isNum1Integer;
        public bool isNum2Decimal, isNum2Integer;

        public string Addition(string number1, string number2)
        {
            ParseInputs(number1, number2);

            string localResult = "";

            int padLength = BigInteger.Abs(internalNum1).ToString().Length;

            BigInteger internalResult = internalNum1 + internalNum2;
            localResult = internalResult.ToString();

            if (internalResult < 0)
            {
                localResult = localResult.Remove(localResult.IndexOf('-'), 1);
                localResult = localResult.Insert((localResult.Length - greaterDecimalPlace), ".");
                localResult = "-" + localResult.PadLeft(padLength, '0');
            }

            else
                localResult = localResult.Insert((localResult.Length - greaterDecimalPlace), ".");

            return localResult;
        }

        public string Subtraction(string number, string numberSubtracted)
        {
            ParseInputs(number, numberSubtracted);

            string localResult = "";

            int padLength = BigInteger.Abs(internalNum1).ToString().Length;

            BigInteger internalResult = internalNum1 - internalNum2;
            localResult = internalResult.ToString();

            if (internalResult < 0)
            {
                localResult = localResult.Remove(localResult.IndexOf('-'), 1);
                localResult = localResult.Insert((localResult.Length - greaterDecimalPlace), ".");
                localResult = "-" + localResult.PadLeft(padLength, '0');
            }

            else
                localResult = localResult.Insert((localResult.Length - greaterDecimalPlace), ".");

            return localResult;
        }

        public string Multiplication(string number1, string number2)
        {
            ParseInputs(number1, number2);

            string localResult = "";

            BigInteger internalResult = internalNum1 * internalNum2;
            localResult = internalResult.ToString();

            if (internalResult < 0)
            {
                localResult = localResult.Remove(localResult.IndexOf('-'), 1);
                localResult = localResult.Insert((localResult.Length - productDecimalPlace), ".");
                localResult = "-" + localResult;
            }

            else
                localResult = localResult.Insert((localResult.Length - productDecimalPlace), ".");

            return localResult;
        }

        public string Division(string dividend, string divisor, int decimalPrecision)
        {
            ParseInputs(dividend, divisor);

            string localResult = "";
            int gate1 = 1;
            int currentDecimalCount = 0;

            BigInteger localA = internalNum1,
                       localB = internalNum2,
                       localC,
                       localD;

            while (currentDecimalCount < decimalPrecision)
            {
                localC = localA / localB;
                localResult += localC.ToString();

                if (gate1 == 1)
                {
                    localResult += ".";
                    gate1 = 0;
                }

                // Turns the division values all positive, after the first minus sign is posted.
                if (localC < 0)
                {
                    localResult = localResult.Remove(localResult.IndexOf('-'), 1);

                    localResult = "-" + localResult;

                    localA = BigInteger.Abs(localA);
                    localB = BigInteger.Abs(localB);
                }

                localD = (localA % localB) * 10;
                localA = localD;

                currentDecimalCount = localResult.Length - (localResult.IndexOf('.') + 1);
            }

            return localResult;
        }

        public void ParseInputs(string number1, string number2)
        {
            ValidateStrings(number1, number2);
            DetermineDecimalPlaces(number1, number2);
            PadShorterDecimal(number1, number2);
        }

        public void ValidateStrings(string value1, string value2)
        {
            isNum1Decimal = IsDecimal(value1);
            isNum1Integer = IsInteger(value1);

            isNum2Decimal = IsDecimal(value2);
            isNum2Integer = IsInteger(value2);
        }

        public void DetermineDecimalPlaces(string number1, string number2)
        {
            if (isNum1Decimal == true && isNum1Integer == false)
                num1DecimalPlace = number1.Length - (number1.IndexOf('.') + 1);

            if (isNum2Decimal == true && isNum2Integer == false)
                num2DecimalPlace = number2.Length - (number2.IndexOf('.') + 1);

            if (num1DecimalPlace > num2DecimalPlace)
                greaterDecimalPlace = num1DecimalPlace;
            else if (num1DecimalPlace < num2DecimalPlace)
                greaterDecimalPlace = num2DecimalPlace;
            else
                greaterDecimalPlace = num1DecimalPlace;

            productDecimalPlace = 2 * greaterDecimalPlace;
        }

        public void PadShorterDecimal(string number1, string number2)
        {
            string localNumber1 = number1;
            string localNumber2 = number2;

            if (num1DecimalPlace > 0 || num2DecimalPlace > 0)
            {
                localNumber1 = localNumber1.Replace(".", "");
                localNumber2 = localNumber2.Replace(".", "");

                if (num1DecimalPlace > num2DecimalPlace)
                {
                    for (int i = 0; i < (num1DecimalPlace - num2DecimalPlace); i++)
                    {
                        localNumber2 += "0";
                    }
                }

                else if (num1DecimalPlace < num2DecimalPlace)
                {
                    for (int i = 0; i < (num2DecimalPlace - num1DecimalPlace); i++)
                    {
                        localNumber1 += "0";
                    }
                }
            }

            internalNum1 = BigInteger.Parse(localNumber1);
            internalNum2 = BigInteger.Parse(localNumber2);
        }

        #endregion

        #region SQUARE-ROOT OPERATIONS

        public BigInteger internalSquareNum;
        public int squareDecimalPlace = 0;
        public int squarePadZeroes = 0;
        public int squareBitSpace = 1;
        public int remainingGuesses;
        public bool isSquareDecimal, isSquareInteger;

        public string SquareRootOf(string number, int rootDecimalPrecision)
        {
            ParseSquareInputs(number, rootDecimalPrecision);
            FindSquareBitSpace(internalSquareNum);

            BigInteger internalSquareRoot = GuessSquareRootOf(internalSquareNum);

            string localResult = internalSquareRoot.ToString();

            localResult = localResult.Insert((localResult.Length - rootDecimalPrecision), ".");

            return localResult;
        }

        public void ParseSquareInputs(string number, int decimalPrecision)
        {
            ValidateSquareString(number);
            DetermineSquareDecimalPlaces(number, decimalPrecision);
            PadRootDecimal(number);
        }

        public void ValidateSquareString(string number)
        {
            isSquareDecimal = IsDecimal(number);
            isSquareInteger = IsInteger(number);
        }

        public void DetermineSquareDecimalPlaces(string number, int decimalPrecision)
        {
            if (isSquareDecimal == true && isSquareInteger == false)
                squarePadZeroes = (2 * decimalPrecision) - (number.Length - (number.IndexOf('.') + 1));

            else if (isSquareInteger == true)
                squarePadZeroes = 2 * decimalPrecision;

            squareDecimalPlace = 2 * decimalPrecision;
        }

        public void PadRootDecimal(string number)
        {
            string localResult = number;

            localResult = localResult.Replace(".", "");

            for (int i = 0; i < squarePadZeroes; i++)
            {
                localResult += '0';
            }

            internalSquareNum = BigInteger.Parse(localResult);
        }

        public void FindSquareBitSpace(BigInteger targetValue)
        {
            BigInteger squareBitSpaceTest = 0;

            while (targetValue > squareBitSpaceTest)
            {
                squareBitSpace++;
                squareBitSpaceTest = BigInteger.Pow(2, squareBitSpace);
            }

            remainingGuesses = squareBitSpace;
        }

        public BigInteger GuessSquareRootOf(BigInteger number)
        {
            BigInteger guess = 0;
            BigInteger squareRoot = 0;
            int guessIterations = remainingGuesses;

            for (int i = 0; i <= guessIterations; i++)
            {
                if (guess < internalSquareNum)
                {
                    Console.WriteLine("Square Target is Higher than " + guess + "\n");
                    Console.WriteLine("--- --- --- \n");
                    Console.WriteLine("Guesses remaining: " + remainingGuesses);

                    squareRoot += BigInteger.Pow(2, remainingGuesses);
                    Console.WriteLine("Current Square Root Guess: " + squareRoot + "\n");
                    guess = squareRoot * squareRoot;

                    remainingGuesses--;
                }

                else if (guess > internalSquareNum)
                {
                    Console.WriteLine("Square Target is Lower than " + guess + "\n");
                    Console.WriteLine("--- --- --- \n");
                    Console.WriteLine("Guesses remaining: " + remainingGuesses);
                    squareRoot -= BigInteger.Pow(2, remainingGuesses);
                    Console.WriteLine("Current Square Root Guess: " + squareRoot + "\n");
                    guess = squareRoot * squareRoot;

                    remainingGuesses--;
                }

                else
                {
                    Console.WriteLine("Perfect" + "\n");
                    Console.WriteLine("--- --- ---");
                    break;
                }

                System.Threading.Thread.Sleep(10);
            }

            return squareRoot;
        }

        #endregion

        public bool IsDecimal(string value)
        {
            bool isDecimal = true;
            int decimalCount = 0;
            int negativeCount = 0;

            if (value != "")
            {
                foreach (char c in value)
                {
                    if (c == '.')
                        decimalCount++;

                    else if (c == '-')
                    {
                        negativeCount++;

                        if (value.IndexOf('-') != 0)
                        {
                            isDecimal = false;
                            break;
                        }
                    }

                    else if ((c != '0' && c != '1' && c != '2' && c != '3' &&
                                c != '4' && c != '5' && c != '6' && c != '7' &&
                                c != '8' && c != '9' && c != '.' && c != '-') ||
                                decimalCount > 1 || negativeCount > 1)
                    {
                        isDecimal = false;
                        break;
                    }
                }
            }

            else
                isDecimal = false;

            return isDecimal;
        }

        public bool IsInteger(string value)
        {
            BigInteger localResult;
            bool isInteger = BigInteger.TryParse(value, out localResult);

            return isInteger;
        }
    }
}
