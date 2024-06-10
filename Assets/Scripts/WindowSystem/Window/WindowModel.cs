using MVC;

namespace WindowSystem
{
    public class WindowModel<TParameters> : Model, IWindowModel where TParameters : IParameters
    {
        public TParameters Parameters;

        public override void SetParameters(IParameters parameters)
        {
            Parameters = (TParameters) parameters;
            base.SetParameters(parameters);
        }
    }
}