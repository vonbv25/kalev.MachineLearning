using kalev.MachineLearning.Processors.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xer.Messaginator;

namespace kalev.MachineLearning.Processors.Test.Entities
{
    public class MockMessageSource : IMessageSource<BatchData>
    {
        public event MessageReceivedDelegate<BatchData> OnMessageReceived;
        public event EventHandler<Exception> OnError;

        public Task ReceiveAsync(MessageContainer<BatchData> message, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task StartReceivingAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task StopReceivingAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
