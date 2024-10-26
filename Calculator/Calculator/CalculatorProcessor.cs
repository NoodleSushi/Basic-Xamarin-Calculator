using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class CalculatorProcessor
    {
        public enum Operation
        {
            Nil,
            Add,
            Sub,
            Mul,
            Div,
            Err,
            Equ,
        }

        private decimal spare = 0;
        private string input = "0";
        private bool isDecimal = false;
        private Operation lastOp = Operation.Nil;

        private void ResetInput()
        {
            input = "0";
            isDecimal = false;
        }

        public void Clear()
        {
            ResetInput();
            spare = 0;
            lastOp = Operation.Nil;
        }

        public string GetDisplay() => input;

        public void InputNumber(int num)
        {
            if (lastOp == Operation.Equ)
                Clear();
            
            if (input.Equals("0"))
                input = num.ToString();
            else
                input += num.ToString();
        }

        public void InputOperation(Operation op)
        {
            if (lastOp == Operation.Nil)
                spare = decimal.Parse(input);
            else if (lastOp != Operation.Equ)
                ExecuteOperation();

            ResetInput();
            lastOp = op;
        }

        private void ExecuteOperation()
        {
            decimal inputParsed = decimal.Parse(input);

            switch (lastOp)
            {
                case Operation.Add:
                    spare += inputParsed;
                    break;
                case Operation.Sub:
                    spare -= inputParsed;
                    break;
                case Operation.Mul:
                    spare *= inputParsed;
                    break;
                case Operation.Div:
                    if (inputParsed == 0)
                    {
                        input = "Cannot divide by zero";
                        lastOp = Operation.Err;
                    }
                    else
                    {
                        spare /= inputParsed;
                    }
                    break;
            }
        }

        public void Delete()
        {
            if (lastOp == Operation.Equ)
                return;

            if (input.Substring(input.Length - 1).Equals("."))
                isDecimal = false;

            input = (input.Length == 1) ? "0" : input.Substring(0, input.Length - 1);
        }

        public void ToggleDecimal()
        {
            if (lastOp == Operation.Equ)
                return;

            if (isDecimal && input.Substring(input.Length - 1).Equals("."))
            {
                isDecimal = false;
                Delete();
            }
            else if (!isDecimal)
            {
                isDecimal = true;
                input += ".";
            }
        }

        public void Evaluate()
        {
            if (lastOp == Operation.Equ || lastOp == Operation.Nil)
                return;

            ExecuteOperation();

            if (lastOp != Operation.Err)
                input = spare.ToString();

            lastOp = Operation.Equ;
        }
    }
}
