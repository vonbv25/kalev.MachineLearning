using System;
using System.Collections.Generic;
using System.Text;

namespace kalev.MachineLearning.Core.Models
{
    public interface IDerivableSupervisedModel : ISupervisedLearningModel
    {
        double CostFunctionDerivative(double[] featureVector, double featureEntry, double label);
    }
}
