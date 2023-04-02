using FrogSurvive.Controllers;
using FrogSurvive.Events;
using Scripts;
using Zenject;

public class CoreInstaller : Installer
{
	public override void InstallBindings()
	{
		SignalBusInstaller.Install(Container);
		Container.Bind<IEventBus>().To<EventBus>().AsSingle();

		Container.Bind<KeyInput>().AsSingle();
		Container.BindInterfacesAndSelfTo<GameController>().AsSingle();
	}
}
