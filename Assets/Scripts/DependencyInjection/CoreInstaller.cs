using FrogSurvive.Events;
using FrogSurvive.FrogPlayer;
using Scripts;
using Zenject;

public class CoreInstaller : Installer
{
	public override void InstallBindings()
	{
		SignalBusInstaller.Install(Container);
		Container.Bind<IEventBus>().To<EventBus>().AsSingle();

		Container.DeclareSignal<FrogPlayerMovedSignal>();
		Container.BindSignal<FrogPlayerMovedSignal>()
            .ToMethod<SpriteHorizontalDirectionManager>(x => x.FrogPlayerMoved)
			.FromResolve();

		Container.Bind<KeyInput>().AsSingle();
	}
}
