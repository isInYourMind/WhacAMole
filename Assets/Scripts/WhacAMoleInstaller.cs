using Game;
using HighScores;
using HomeScreen;
using Results;
using WindowSystem;
using Zenject;

public class WhacAMoleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        WindowSystemInstaller.Install(Container);
        HomeScreenInstaller.Install(Container);
        GameInstaller.Install(Container);
        ResultsInstaller.Install(Container);
        HighScoresInstaller.Install(Container);
    }
}