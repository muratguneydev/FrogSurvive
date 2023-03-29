using FrogSurvive.FrogPlayer;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
	public FrogPlayerSettings FrogPlayerSettings;
	
    public override void InstallBindings()
    {
		Container.BindInstance(FrogPlayerSettings);
    }
}