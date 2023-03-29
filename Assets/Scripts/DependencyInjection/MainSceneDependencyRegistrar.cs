using FrogSurvive.FrogPlayer;
using Zenject;

public class MainSceneDependencyRegistrar : MonoInstaller
{
	[Inject] FrogPlayerSettings _frogPlayerSettings;

	public override void InstallBindings()
	{
		Container.Install<CoreInstaller>();
		FrogPlayerInstaller.Install(Container, _frogPlayerSettings);
	}
}