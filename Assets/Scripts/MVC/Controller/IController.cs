namespace MVC
{
    public interface IController
    {
        void ApplyView(IView view);

        void Open(IParameters inputData = null);
        
        void Close();

        void Hide();
    }
}