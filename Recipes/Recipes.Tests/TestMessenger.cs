using GalaSoft.MvvmLight.Messaging;
using Recipes.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Tests
{
    public class TestMessenger : IMessenger
    {
        private IMessenger _messenger;

        public TestMessenger(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void Cleanup() { }

        public static void OverrideDefault(IMessenger newMessenger) { }

        public virtual void Register<TMessage>(object recipient, Action<TMessage> action) 
        {
            _messenger.Register<TMessage>(recipient, action);
        }

        public virtual void Register<TMessage>(object recipient, bool receiveDerivedMessagesToo, Action<TMessage> action) { }

        public virtual void Register<TMessage>(object recipient, object token, Action<TMessage> action) { }

        public virtual void Register<TMessage>(object recipient, object token, bool receiveDerivedMessagesToo, Action<TMessage> action) { }

        public void RequestCleanup() { }

        public static void Reset() { }

        public void ResetAll() { }

        public virtual void Send<TMessage, TTarget>(TMessage message) { }

        public virtual void Send<TMessage>(TMessage message) 
        {
            _messenger.Send<TMessage>(message);
        }

        public virtual void Send<TMessage>(TMessage message, object token) { }

        public virtual void Unregister(object recipient) { }

        public virtual void Unregister<TMessage>(object recipient) { }

        public virtual void Unregister<TMessage>(object recipient, Action<TMessage> action) { }

        public virtual void Unregister<TMessage>(object recipient, object token) { }

        public virtual void Unregister<TMessage>(object recipient, object token, Action<TMessage> action) { }
    }
}
