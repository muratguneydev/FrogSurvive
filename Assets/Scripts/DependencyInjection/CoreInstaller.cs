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
		Container.Bind<DeltaTime>().AsSingle();
		Container.Bind<RealTimeTicker>().AsTransient();
		//Container.Bind<ITickable>(),RealTimeTicker>().AsTransient();
		
		// Container.Bind<ITickable>().To<RealTimeTicker>().AsTransient();
		// Container.Bind<RealTimeTicker>().To<ITickable>().AsTransient();
		// Container.Bind(typeof(ITickable), typeof(RealTimeTicker)).WithId("PlayerName").To<RealTimeTicker>().AsSingle();
		//Container.BindInterfacesAndSelfTo<RealTimeTicker>().WithId("PlayerName").AsSingle();


		Container.Bind<GameObjectDestroyer>().AsSingle();
		Container.Bind<SceneManagerWrapper>().AsSingle();
		Container.BindInterfacesAndSelfTo<GameController>().AsSingle();

		Container.Bind<HitTheWallUISignalFactory>().AsSingle();
		Container.DeclareSignal<HitTheWallUISignal>();
		Container.BindSignal<HitTheWallUISignal>()
            .ToMethod<GameController>(x => x.OnHitTheWall)
			.FromResolve();

		Container.DeclareSignal<GameResetSignal>();
		Container.DeclareSignal<ResetButtonClickedUISignal>();
		Container.BindSignal<ResetButtonClickedUISignal>()
            .ToMethod<GameController>(x => x.OnGameReset)
			.FromResolve();
	}
}
