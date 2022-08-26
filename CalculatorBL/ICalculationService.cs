using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.Interfaces
{
    public interface ICalculationService
    {
        public decimal Calculate(string expression);
    }
}
