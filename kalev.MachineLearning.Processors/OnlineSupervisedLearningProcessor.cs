using kalev.MachineLearning.Processors.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xer.Messaginator;
using System.Threading;
using System.Threading.Tasks;
using kalev.MachineLearning.Core.Learners;

namespace kalev.MachineLearning.Processors
{
    public class OnlineSupervisedLearningProcessor : MessageProcessor<StreamData>
    {
        private readonly IOnlineSupervisedLearner _learner;

        public OnlineSupervisedLearningProcessor(IOnlineSupervisedLearner learner,
            IMessageSource<StreamData> messageSource) : base(messageSource)
        {
            _learner = learner;
        }

        public override string Name => typeof(OnlineSupervisedLearningProcessor).Name;

        protected override Task ProcessMessageAsync(MessageContainer<StreamData> receivedMessage, CancellationToken cancellationToken)
        {
            StreamData data = receivedMessage;

            return Task.Run( () => 
                {
                    _learner.Learn(data.FeatureVector, data.Label);
                }
            );
        }
    }
}
