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

        BigInteger _internalNum1;
        BigInteger _internalNum2;

        int _num1DecimalPlace;
        int _num2DecimalPlace;
        int _greaterDecimalPlace;
        int _productDecimalPlace;

        bool _isNum1Decimal, _isNum1Integer;
        bool _isNum2Decimal, _isNum2Integer;

        public string Addition(string number1, string number2)
        {
            ParseInputs(number1, number2);

            string localResult;

            int padLength = BigInteger.Abs(_internalNum1).ToString().Length;

            BigInteger internalResult = _internalNum1 + _internalNum2;
            localResult = internalResult.ToString();

            if (internalResult < 0)
            {
                localResult = localResult.Remove(localResult.IndexOf('-'), 1);
                localResult = localResult.Insert((localResult.Length - _greaterDecimalPlace), ".");
                localResult = "-" + localResult.PadLeft(padLength, '0');
            }
            else
                localResult = localResult.Insert((localResult.Length - _greaterDecimalPlace), ".");

            return localResult;
        }

        public string Subtraction(string number, string numberSubtracted)
        {
            ParseInputs(number, numberSubtracted);

            string localResult;

            int padLength = BigInteger.Abs(_internalNum1).ToString().Length;

            BigInteger internalResult = _internalNum1 - _internalNum2;
            localResult = internalResult.ToString();

            if (internalResult < 0)
            {
                localResult = localResult.Remove(localResult.IndexOf('-'), 1);
                localResult = localResult.Insert((localResult.Length - _greaterDecimalPlace), ".");
                localResult = "-" + localResult.PadLeft(padLength, '0');
            }
            else
                localResult = localResult.Insert((localResult.Length - _greaterDecimalPlace), ".");

            return localResult;
        }

        public string Multiplication(string number1, string number2)
        {
            ParseInputs(number1, number2);

            string localResult;

            BigInteger internalResult = _internalNum1 * _internalNum2;
            localResult = internalResult.ToString();

            if (internalResult < 0)
            {
                localResult = localResult.Remove(localResult.IndexOf('-'), 1);
                localResult = localResult.Insert((localResult.Length - _productDecimalPlace), ".");
                localResult = "-" + localResult;
            }
            else
                localResult = localResult.Insert((localResult.Length - _productDecimalPlace), ".");

            return localResult;
        }

        public string Division(string dividend, string divisor, int decimalPrecision)
        {
            ParseInputs(dividend, divisor);

            string localResult = "";
            int gate1 = 1;
            int currentDecimalCount = 0;

            BigInteger localA = _internalNum1,
                       localB = _internalNum2,
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

        private void ParseInputs(string number1, string number2)
        {
            ValidateStrings(number1, number2);
            DetermineDecimalPlaces(number1, number2);
            PadShorterDecimal(number1, number2);
        }

        private void ValidateStrings(string value1, string value2)
        {
            _isNum1Decimal = IsDecimal(value1);
            _isNum1Integer = IsInteger(value1);

            _isNum2Decimal = IsDecimal(value2);
            _isNum2Integer = IsInteger(value2);
        }

        private void DetermineDecimalPlaces(string number1, string number2)
        {
            if (_isNum1Decimal && _isNum1Integer == false)
                _num1DecimalPlace = number1.Length - (number1.IndexOf('.') + 1);
            if (_isNum2Decimal && _isNum2Integer == false)
                _num2DecimalPlace = number2.Length - (number2.IndexOf('.') + 1);

            if (_num1DecimalPlace > _num2DecimalPlace)
                _greaterDecimalPlace = _num1DecimalPlace;
            else if (_num1DecimalPlace < _num2DecimalPlace)
                _greaterDecimalPlace = _num2DecimalPlace;
            else
                _greaterDecimalPlace = _num1DecimalPlace;

            _productDecimalPlace = 2 * _greaterDecimalPlace;
        }

        private void PadShorterDecimal(string number1, string number2)
        {
            string localNumber1 = number1;
            string localNumber2 = number2;

            if (_num1DecimalPlace > 0 || _num2DecimalPlace > 0)
            {
                localNumber1 = localNumber1.Replace(".", "");
                localNumber2 = localNumber2.Replace(".", "");

                if (_num1DecimalPlace > _num2DecimalPlace)
                    for (int i = 0; i < (_num1DecimalPlace - _num2DecimalPlace); i++)
                        localNumber2 += "0";
                else if (_num1DecimalPlace < _num2DecimalPlace)
                    for (int i = 0; i < (_num2DecimalPlace - _num1DecimalPlace); i++)
                        localNumber1 += "0";
            }

            _internalNum1 = BigInteger.Parse(localNumber1);
            _internalNum2 = BigInteger.Parse(localNumber2);
        }

        #endregion

        #region SQUARE-ROOT OPERATIONS

        BigInteger _internalSquareNum;
        private int _squareDecimalPlace;
        private int _squarePadZeroes;
        private int _squareBitSpace = 1;
        int _remainingGuesses;
        bool _isSquareDecimal, _isSquareInteger;

        public string SquareRootOf(string number, int rootDecimalPrecision)
        {
            ParseSquareInputs(number, rootDecimalPrecision);
            FindSquareBitSpace(_internalSquareNum);

            BigInteger internalSquareRoot = GuessSquareRootOf(_internalSquareNum);

            string localResult = internalSquareRoot.ToString();

            localResult = localResult.Insert((localResult.Length - rootDecimalPrecision), ".");

            return localResult;
        }

        private void ParseSquareInputs(string number, int decimalPrecision)
        {
            ValidateSquareString(number);
            DetermineSquareDecimalPlaces(number, decimalPrecision);
            PadRootDecimal(number);
        }

        private void ValidateSquareString(string number)
        {
            _isSquareDecimal = IsDecimal(number);
            _isSquareInteger = IsInteger(number);
        }

        private void DetermineSquareDecimalPlaces(string number, int decimalPrecision)
        {
            if (_isSquareDecimal && _isSquareInteger == false)
                _squarePadZeroes = (2 * decimalPrecision) - (number.Length - (number.IndexOf('.') + 1));
            else if (_isSquareInteger)
                _squarePadZeroes = 2 * decimalPrecision;

            _squareDecimalPlace = 2 * decimalPrecision;
        }

        private void PadRootDecimal(string number)
        {
            string localResult = number;

            localResult = localResult.Replace(".", "");

            for (int i = 0; i < _squarePadZeroes; i++)
            {
                localResult += '0';
            }

            _internalSquareNum = BigInteger.Parse(localResult);
        }

        private void FindSquareBitSpace(BigInteger targetValue)
        {
            BigInteger squareBitSpaceTest = 0;

            while (targetValue > squareBitSpaceTest)
            {
                _squareBitSpace++;
                squareBitSpaceTest = BigInteger.Pow(2, _squareBitSpace);
            }

            _remainingGuesses = _squareBitSpace;
        }

        private BigInteger GuessSquareRootOf(BigInteger number)
        {
            BigInteger guess = 0;
            BigInteger squareRoot = 0;
            int guessIterations = _remainingGuesses;

            for (int i = 0; i <= guessIterations; i++)
            {
                if (guess < _internalSquareNum)
                {
                    Console.WriteLine("Square Target is Higher than " + guess + "\n");
                    Console.WriteLine("--- --- --- \n");
                    Console.WriteLine("Guesses remaining: " + _remainingGuesses);

                    squareRoot += BigInteger.Pow(2, _remainingGuesses);
                    Console.WriteLine("Current Square Root Guess: " + squareRoot + "\n");
                    guess = squareRoot * squareRoot;

                    _remainingGuesses--;
                }

                else if (guess > _internalSquareNum)
                {
                    Console.WriteLine("Square Target is Lower than " + guess + "\n");
                    Console.WriteLine("--- --- --- \n");
                    Console.WriteLine("Guesses remaining: " + _remainingGuesses);
                    squareRoot -= BigInteger.Pow(2, _remainingGuesses);
                    Console.WriteLine("Current Square Root Guess: " + squareRoot + "\n");
                    guess = squareRoot * squareRoot;

                    _remainingGuesses--;
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

        #region FACTORIALS

        public BigInteger Factorial(int integer)
        {
            BigInteger result = 1;

            for (int i = 1; i <= integer; i++)
                result *= i;
            return result;
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
