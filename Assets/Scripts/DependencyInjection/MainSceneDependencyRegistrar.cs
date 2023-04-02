using FrogSurvive.Enemy1;
using FrogSurvive.FrogPlayer;
using Zenject;

public class MainSceneDependencyRegistrar : MonoInstaller
{
	[Inject] FrogPlayerSettings _frogPlayerSettings;
	[Inject] Enemy1Settings _enemy1Settings;

	public override void InstallBindings()
	{
		Container.Install<CoreInstaller>();
		FrogPlayerInstaller.Install(Container, _frogPlayerSettings);
		Enemy1Installer.Install(Container, _enemy1Settings);
	}
}