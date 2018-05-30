using System;
using System.Collections.Generic;
using System.Text;

namespace kalev.MachineLearning.Core.Learners
{
    public interface IOnlineSupervisedLearner
    {
        void Learn(double[] featureVector, double label);
    }
}
