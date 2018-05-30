using System;
using System.Collections.Generic;
using System.Text;

namespace kalev.MachineLearning.Core.Models
{
    public interface ISupervisedLearningModel
    {

        double[] Weights
        {
            get;
            set;
        }

        double CostFunction(double[][] featureVectors, double[] label);

        double Predict(double[] featureVector);
        
    }
}
