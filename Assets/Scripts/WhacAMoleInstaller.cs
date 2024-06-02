using Game;
using HighScores;
using HomeScreen;
using Results;
using Zenject;

public class WhacAMoleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        HomeScreenInstaller.Install(Container);
        GameInstaller.Install(Container);
        ResultsInstaller.Install(Container);
        HighScoresInstaller.Install(Container);
    }
}