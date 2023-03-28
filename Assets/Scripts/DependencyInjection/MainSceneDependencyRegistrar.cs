using Zenject;


public class MainSceneDependencyRegistrar : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Install<CoreInstaller>();
	}
}