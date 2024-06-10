namespace MVC
{
    public interface IController
    {
        void ApplyView(IView view);
        void SetParameters(IParameters inputData = null);
        void Close();
    }
}