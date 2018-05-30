using System;
using System.Collections.Generic;
using System.Text;

namespace kalev.MachineLearning.Processors.Entities
{
    public class BatchData
    {
        private double[][] featureVectors;

        private double[] labels;

        public double[][] FeatureVectors { get => featureVectors; set => featureVectors = value; }

        public double[] Labels { get => labels; set => labels = value; }
    }
}
