using System;
using System.Collections.Generic;
using System.Text;

namespace kalev.MachineLearning.Core.Activations
{
    public class SigmoidActivationFunction : IActivationFunction, IActivationDerivative
    {
        public double Activate(double val)
        {
            return 1 / 1 + Math.Exp(-val);
        }

        public double ActivationDerivative(double val)
        {
            throw new NotImplementedException();
        }
    }
}
