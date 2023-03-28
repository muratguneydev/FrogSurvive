using Scripts;
using Zenject;

public class CoreInstaller : Installer
{
	public override void InstallBindings()
	{
		Container.Bind<KeyInput>().AsSingle();
	}
}
