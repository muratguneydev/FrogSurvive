using FrogSurvive.Enemy1;
using FrogSurvive.FrogPlayer;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
	public FrogPlayerSettings FrogPlayerSettings;
	public Enemy1Settings Enemy1Settings;
	
    public override void InstallBindings()
    {
		Container.BindInstance(FrogPlayerSettings);
		Container.BindInstance(Enemy1Settings);
    }
}