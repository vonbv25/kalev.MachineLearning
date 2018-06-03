using kalev.MachineLearning.Processors.Entities;
using System;
using Xer.Messaginator;
using System.Threading;
using System.Threading.Tasks;
using kalev.MachineLearning.Core.Learners;

namespace kalev.MachineLearning.Processors
{
    public class BatchSupervisedLearningProcessor : MessageProcessor<BatchData>
    {
        private readonly IBatchSupervisedLearner _learner;
        private readonly int _iterations;

        public BatchSupervisedLearningProcessor(IMessageSource<BatchData> messageSource, 
            IBatchSupervisedLearner learner, 
            int iterations) 
            : base(messageSource)
        {
            _learner = learner;
            _iterations = iterations;
        }

        public override string Name => typeof(BatchSupervisedLearningProcessor).Name;

        protected override Task ProcessMessageAsync(MessageContainer<BatchData> receivedMessage, 
            CancellationToken cancellationToken)
        {
            BatchData data = receivedMessage;

            return Task.Run(() => 
                {
                    _learner.Learn(data.FeatureVectors, data.Labels, _iterations);
                } 
            );

        }
    }
}
