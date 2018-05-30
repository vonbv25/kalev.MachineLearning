using System;
using System.Collections.Generic;
using System.Text;

namespace kalev.MachineLearning.Core.Activations
{
    public interface IActivationFunction
    {
        double Activate(double val);
    }
}
