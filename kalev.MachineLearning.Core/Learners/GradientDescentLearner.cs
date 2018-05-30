using kalev.MachineLearning.Core.Exceptions;
using kalev.MachineLearning.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void Learn(double[][] data, double[] label, int iterations)
        {

            if(_model.Weights.Length != data[0].Length)
            {
                throw new ComputationException("Feature column must equal to the number of _weights");
            }

            for (int i = 0; i < iterations; i++)
            {
                
                for (int w = 0; w < data[0].Length; w++)
                {
                    double gradient = 0;

                    //Iterate to all data entries
                    for (int j = 0; j < data.Length; j++)
                    {
                        gradient += _model.CostFunctionDerivative(data[j], data[j][w], label[j]);
                            //(features[j][w] * (label[j] - _model.Predict(features[j])));                        
                    }

                    gradient /= label.Length;

                    gradient *= _learningRate;

                    _model.Weights[w] -= gradient;
                }

                _logCostFunc?.Invoke(_model.CostFunction(data, label));
            }

            //Save the trained model
            _saveModel?.Invoke(_model);


        }
    }

}
