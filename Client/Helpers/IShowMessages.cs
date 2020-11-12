using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Client.Helpers
{
    public interface IShowMessages
    {
        Task ShowErrorMessage(string message);
    }

    public class ShowMessages : IShowMessages
    {
        public Task ShowErrorMessage(string message)
        {
            return Task.FromResult(0);
        }
    }
}
