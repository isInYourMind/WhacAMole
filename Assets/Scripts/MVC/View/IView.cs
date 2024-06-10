using System;

namespace MVC
{
    public interface IView
    {
        event Action DestroyEvent; 
        void Disable();
        void ApplyModel(IModel model);
    }
}