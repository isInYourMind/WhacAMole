using System;
using MVC;

namespace WindowSystem
{
    public interface IWindowController : IController
    {
        WindowLayer CurrentLayer { get; }
        Action<IWindowController> Closed { get; }
    }
}