using System;
using System.Collections.Generic;
using System.Text;

namespace kalev.MachineLearning.Core.Learners
{
    public interface IBatchSupervisedLearner
    {
        void Learn(double[][] featureVectors, double[] label, int iterations);
    }
}
