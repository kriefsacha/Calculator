using CalculatorAPI.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CalculatorBL
{
    public class CalculationService : ICalculationService
    {
        public decimal Calculate(string expression)
        {
            Queue<string> postfixQueue = ParseIntoPostfixQueue(expression);
            decimal res = PostfixQueueToResult(postfixQueue);
            return res;
        }

        public Queue<string> ParseIntoPostfixQueue(string str)
        {
            Stack<char> symbolsStack = new Stack<char>();
            Queue<string> postfixQueue = new Queue<string>();

            FillPostfixQueue(str, postfixQueue, symbolsStack);
            AddLastSymbolsToQueue(symbolsStack, postfixQueue);
            return postfixQueue;
        }

        public void FillPostfixQueue(string str, Queue<string> postfixQueue, Stack<char> symbolsStack)
        {
            for (int i = 0; i < str.Length;)
            {
                if ((str[i] >= '0' && str[i] <= '9') || (str[i] == '.'))
                {
                    decimal cur = 0;
                    bool isDecimal = false;
                    int num = 0;
                    while (i < str.Length && ((str[i] >= '0' && str[i] <= '9') || (str[i] == '.')))
                    {
                        if (str[i] == '.')
                        {
                            isDecimal = true;
                        }
                        else
                        {
                            if (!isDecimal)
                            {
                                cur = AddCharToNumber(cur, str[i]);
                            }
                            else
                            {
                                num++;
                                cur = AddCharToDecimalPart(cur, str[i], num);
                            }
                        }
                        i++;
                    }
                    postfixQueue.Enqueue(cur.ToString());
                }
                else
                {
                    while (symbolsStack.Count != 0 && CompareOperators(symbolsStack.Peek(), str[i]) < 0)
                    {
                        postfixQueue.Enqueue(symbolsStack.Pop() + "");
                    }
                    symbolsStack.Push(str[i]);
                    i++;
                }
            }
        }

        public void AddLastSymbolsToQueue(Stack<char> symbolsStack, Queue<string> postfixQueue)
        {
            while (symbolsStack.Count != 0)
            {
                postfixQueue.Enqueue(symbolsStack.Pop() + "");
            }
        }


        public decimal AddCharToNumber(decimal dec, char chr)
        {
            dec = dec * 10 + chr - '0';
            return dec;
        }

        public decimal AddCharToDecimalPart(decimal dec, char chr, double power)
        {
            dec = dec + (chr - '0') / (decimal)(Math.Pow(10, power));
            return dec;
        }

        public int CompareOperators(char peek, char c)
        {
            if (c == '+' || c == '-') return -1;
            if (c == '*' && (peek == '*' || peek == '/')) return -1;
            if (c == '/' && (peek == '*' || peek == '/')) return -1;
            return 1;
        }

        public decimal PostfixQueueToResult(Queue<string> queue)
        {
            Stack res = new Stack();
            while (queue.Count != 0)
            {
                string t = queue.Dequeue();
                if (t.Equals("+") || t.Equals("-") || t.Equals("*") || t.Equals("/"))
                {
                    decimal a = (decimal)res.Pop();
                    decimal b = (decimal)res.Pop();
                    decimal result = CalculatePerOperatorSign(b, a, t);
                    res.Push(result);
                }
                else
                {
                    res.Push(decimal.Parse(t));
                }
            }
            return (decimal)res.Pop();
        }

        public decimal CalculatePerOperatorSign(decimal a, decimal b, string t)
        {
            if (t.Equals("+"))
            {
                return Plus(a, b);
            }
            else if (t.Equals("-"))
            {
                return Minus(a, b);
            }
            else if (t.Equals("*"))
            {
                return Multiply(a, b);
            }
            else
            {
                return Divide(a, b);
            }
        }

        public decimal Plus(decimal a, decimal b)
        {
            return a + b;
        }

        public decimal Minus(decimal a, decimal b)
        {
            return a - b;
        }

        public decimal Multiply(decimal a, decimal b)
        {
            return a * b;
        }

        public decimal Divide(decimal a, decimal b)
        {
            return a / b;
        }
    }
}
