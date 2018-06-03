using kalev.MachineLearning.Core.Exceptions;
using kalev.MachineLearning.Core.Models;
using System;
using System.Threading.Tasks;

namespace kalev.MachineLearning.Core.Learners
{
    public class GradientDescentLearner : IBatchSupervisedLearner
    {

        public delegate void LogCost(double cost);

        public delegate void SaveTrainedModel(ISupervisedLearningModel trainedModel);

        private IDerivableSupervisedModel _model;
        private LogCost _logCostFunc;
        private readonly double _learningRate;
        private SaveTrainedModel _saveModel;

        public GradientDescentLearner(IDerivableSupervisedModel model, 
            SaveTrainedModel saveModel = null,
            LogCost func = null,
            double learningRate = 0.5)
        {
            _model = model;
            _saveModel = saveModel;
            _learningRate = learningRate;

            _logCostFunc = func;
        }

        public void Learn(double[][] featureVectors, double[] label, int iterations)
        {
            if(_model.Weights.Length != featureVectors[0].Length)
            {
                throw new ComputationException("Feature column must equal to the number of _weights");
            }

            double[] cached_weights = new double[_model.Weights.Length];
            //Cached the weights since we will update the weights in parallel
            Array.Copy(_model.Weights, cached_weights, _model.Weights.Length);

            for (int i = 0; i < iterations; i++)
            {
                Parallel.For(0, _model.Weights.Length,
                        (w) =>
                        {
                            double gradient = 0;

                            //Iterate to all data entries
                            for (int j = 0; j < featureVectors.Length; j++)
                            {
                                gradient += 
                                _model.CostFunctionDerivative(featureVectors[j], featureVectors[j][w], label[j]);                      
                            }

                            gradient /= label.Length;

                            gradient *= _learningRate;

                            cached_weights[w] -= gradient;
                        }
                    );

                Array.Copy(cached_weights, _model.Weights, cached_weights.Length);

                _logCostFunc?.Invoke(_model.CostFunction(featureVectors, label));
            }

            //Save the trained model
            _saveModel?.Invoke(_model);


        }
    }

}
