using BlazorDemo.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlazorDemo.Client.Shared.MainLayout;

namespace BlazorDemo.Client.Pages
{
    public class CounterBase : ComponentBase
    {
        protected int currentCount = 0;
        
        [Inject]
        protected SingletonService Singleton { get; set; }

        [Inject]
        protected TransientService Transient { get; set; }

        protected void IncrementCount()
        {
            currentCount++;
            Singleton.Value = currentCount;
            Transient.Value = currentCount;
        }
    }
}
