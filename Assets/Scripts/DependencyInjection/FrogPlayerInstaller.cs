using FrogSurvive.Enemy1;
using FrogSurvive.Events;
using FrogSurvive.FrogPlayer;
using Zenject;

public class FrogPlayerInstaller : Installer<FrogPlayerSettings, FrogPlayerInstaller>
{
	private readonly FrogPlayerSettings _frogPlayerSettings;

	public FrogPlayerInstaller(FrogPlayerSettings frogPlayerSettings)
	{
		_frogPlayerSettings = frogPlayerSettings;
	}
	public override void InstallBindings()
	{
		Container.Bind<FrogPlayerMover>().AsSingle();
		Container.BindInstance(_frogPlayerSettings.HorizontalVelocity).WhenInjectedInto<FrogPlayerMover>();

		Container.DeclareSignal<FrogPlayerMovedSignal>();
		Container.BindSignal<FrogPlayerMovedSignal>()
            .ToMethod<SpriteHorizontalDirectionManager>(x => x.OnFrogPlayerMoved)
			.FromResolve();
		Container.BindSignal<FrogPlayerMovedSignal>()
            .ToMethod<FrogPlayerAnimatorManager>(x => x.OnFrogPlayerMoved)
			.FromResolve();
		Container.BindSignal<FrogPlayerMovedSignal>()
            .ToMethod<Enemy1BulletSpawner>(x => x.OnFrogPlayerMoved)
			.FromResolve();

		Container.Bind<FrogPlayerHealthManager>().AsSingle();

		Container.DeclareSignal<FrogPlayerHitUISignal>();
		Container.BindSignal<FrogPlayerHitUISignal>()
            .ToMethod<FrogPlayerHealthManager>(x => x.OnHitByAnObject)
			.FromResolve();
		

		Container.Bind<SpriteHorizontalDirectionManager>().AsSingle();
		Container.Bind<FrogPlayerAnimatorManager>().AsSingle();
		
	}
}
