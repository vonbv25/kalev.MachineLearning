using System;
using System.Threading.Tasks;
using Xunit;

namespace kalev.MachineLearning.Processors.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            double[] weights = new double[] { 0.5, 0.5, 0.5 };

            double[][] featureVectors = new double[][] 
            { 
                new double[]{ 1, 2, 3 },
                new double[]{ 2, 3, 4 }
            };

            double[] labels = new double[] { 1, 1.1 };

            double[] cached_weights = new double[] { 0.5, 0.5, 0.5 };

            double _learningRate = 0.5;
            Parallel.For(0, weights.Length,
                            (w) => 
                            {
                                double gradient = 0;
                                //Iterate to all data entries
                                for (int j = 0; j < featureVectors.Length; j++)
                                {
                                    gradient += CostFunctionDerivative(featureVectors[j], weights, featureVectors[j][w], labels[j]);
                                    string weight_str = weights[w].ToString();
                                    string feature = j.ToString();
                                }

                                gradient /= labels.Length;

                                gradient *= _learningRate;

                                cached_weights[w] -= gradient;
                            }        
                       );
            
        }

        private double CostFunctionDerivative(double[] features, double[] weights, double feature, double label)
        {
            return feature * (label - Predict(features, weights));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        /// <param name="weights"></param>
        /// <returns></returns>
        private double Predict(double[] feature, double[] _weights)
        {
            double z = 0;

            for (int i = 0; i < feature.Length; i++)
            {
                z += (feature[i] * _weights[i]);
            }

            return z;
        }

    }
}
