using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    class EvaluareExpresie
    {
        static void Main(string[] args)
        {
            string exp = "( 1 + ( ( 2 + 3 ) * ( 4 * 5 ) ) )";
            string[] tokens = exp.Split(' ');

            Stack<string> operatori = new Stack<string>();
            Stack<double> operanzi = new Stack<double>();

            foreach (var item in tokens)
            {
                if (item == "(")
                    ;
                else if (item == "+" || item == "-" || item == "*" || item == "/")
                        operatori.push(item);
                else if (item == ")")
                    {
                        string op = operatori.pop();
                        double v = operanzi.pop();
                        switch (op)
                        {
                            case "+":
                                v = operanzi.pop() + v;
                                break;
                            case "-":
                                v = operanzi.pop() - v;
                                break;
                            case "/":
                                v = operanzi.pop() / v;
                                break;
                            case "*":
                                v = operanzi.pop() * v;
                                break;
                        }
                        operanzi.push(v);
                    }
                else
                    operanzi.push(double.Parse(item));
            }
            Console.WriteLine("Valoarea expresiei este: {0}", operanzi.pop());
        }
    }
}
