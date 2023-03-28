using Scripts;
using Zenject;

public class FrogPlayerInstaller : Installer<FrogPlayerInstaller>
{
	public override void InstallBindings()
	{
		//Container.Bind<KeyInput>().AsSingle();
	}
}
