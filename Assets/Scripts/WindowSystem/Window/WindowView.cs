using MVC;

namespace WindowSystem
{
    public class WindowView<TModel> : View<TModel>, IWindowView where TModel : class, IWindowModel, IModel
    {
    }
}