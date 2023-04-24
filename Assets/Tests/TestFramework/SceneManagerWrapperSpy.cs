using System.Collections.Generic;
using FrogSurvive.Controllers;

public class SceneManagerWrapperSpy : SceneManagerWrapper
{
	private readonly HashSet<string> _loadedScenes = new();
	public override void LoadScene(string sceneName)
	{
		_loadedScenes.Add(sceneName);
	}

	public bool IsSceneLoaded(string name) => _loadedScenes.Contains(name);
}