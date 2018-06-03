using System;
using System.Collections.Generic;
using System.Text;

namespace kalev.MachineLearning.Processors.Entities
{
    public class StreamData
    {
        private double[] featureVector;

        private double label;

        public double[] FeatureVector { get => featureVector; set => featureVector = value; }

        public double Label { get => label; set => label = value; }
    }
}
