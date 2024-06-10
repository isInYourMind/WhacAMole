using Cysharp.Threading.Tasks;
using MVC;

namespace Game
{
    public class MoleModel : Model
    {
        public int LifeSpanSec => 4;
        
        public MoleType Type { get; set; }
        public readonly AsyncReactiveProperty<int> Health = new(0);
    }
}