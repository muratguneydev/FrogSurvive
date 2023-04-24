using UnityEngine.SceneManagement;

namespace FrogSurvive.Controllers
{
	public class SceneManagerWrapper
	{
		public virtual void LoadScene(string sceneName)
		{
			SceneManager.LoadScene(sceneName);
		}
	}
}