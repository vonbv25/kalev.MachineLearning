using kalev.MachineLearning.Core.Activations;
using kalev.MachineLearning.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace kalev.MachineLearning.Core.Models
{

    public class LogisticRegression : IDerivableSupervisedModel
    {
        private double[] _weights;

        private IActivationFunction activator;

        public double[] Weights { get => _weights; set => _weights = value; }

        public LogisticRegression(int numberOfWeights, double bias, bool setWeightToZero = true)
        {
            activator = new SigmoidActivationFunction();

            _weights = new double[numberOfWeights + 1];

            _weights[0] = bias;

            if (!setWeightToZero)
            {
                randomizeWeights();
            }
            else
            {
                setWeigtToZero();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activationFunc"></param>
        public LogisticRegression(IActivationFunction activationFunc, 
            int numberOfWeights, 
            double bias,
            bool setWeightToZero = true)
        {
            activator = activationFunc;

            _weights = new double[numberOfWeights + 1];

            _weights[0] = bias;

            if (!setWeightToZero)
            {
                randomizeWeights();
            }
            else
            {
                setWeigtToZero();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="featureVectors"></param>
        /// <param name="label"></param>
        /// <param name="weights"></param>
        /// <returns></returns>
        public double CostFunction(double[][] featureVectors, double[] label)
        {
            double totalCostVal = 0;

            if (featureVectors[0].Length != _weights.Length)
            {
                throw new ComputationException("Feature column must equal to the number of _weights");
            }

            if (featureVectors.Length != label.Length)
            {
                throw new ComputationException("Some of data does not have a Label");
            }

            for (int i = 0; i< featureVectors.Length; i++)
            {
                double z = 0;

                for (int j = 0; j < featureVectors[i].Length; j++)
                {
                    z += featureVectors[i][j] * _weights[j];
                }

                double class1_cost = label[i] * Math.Log(activator.Activate(z));
                
                double class2_cost = (1- label[i]) * Math.Log(1 - activator.Activate(z));

                totalCostVal += (class1_cost + class2_cost);

            }

            return totalCostVal/ label.Length;
            
        }

        public double CostFunctionDerivative(double[] features, double feature, double label)
        {
            return feature * (label - Predict(features));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        /// <param name="weights"></param>
        /// <returns></returns>
        public double Predict(double[] feature)
        {
            double z = 0;

            for (int i = 0; i < feature.Length; i++)
            {
                z += (feature[i] * _weights[i]);
            }

            return activator.Activate(z);
        }

        private void randomizeWeights()
        {
            Random rand = new Random();

            for (int i = 0; i < _weights.Length; i++)
            {
                _weights[i] = rand.NextDouble();
            }
        }

        private void setWeigtToZero()
        {
            for (int i = 0; i < _weights.Length; i++)
            {
                _weights[i] = 0.0;
            }
        }


    }
}
