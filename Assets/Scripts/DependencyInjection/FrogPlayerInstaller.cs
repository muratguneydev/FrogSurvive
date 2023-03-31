using FrogSurvive.FrogPlayer;
using Scripts;
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
		Container.Bind<HorizontalMover>().AsSingle();
		Container.BindInstance(_frogPlayerSettings.HorizontalVelocity).WhenInjectedInto<HorizontalMover>();

		Container.Bind<SpriteHorizontalDirectionManager>().AsSingle();
		
	}
}
