using System;

namespace CalculateLib
{
    public class SimpleCalculate
    {
        public int Add(int a, int b) => a + b;

        public int Minus(int a, int b) => a - b;

        public int Multiply(int a, int b) => a * b;

        public float Divide(int a, int b) => (a * 1.0f) / b;
    }
}
