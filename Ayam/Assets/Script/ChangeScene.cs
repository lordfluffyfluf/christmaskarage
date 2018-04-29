using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void ChangeSceneInto(string SceneName)
	{
		SceneManager.LoadScene (SceneName);
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
