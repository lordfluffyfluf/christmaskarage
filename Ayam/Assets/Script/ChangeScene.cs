using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void ChangeSceneInto(string SceneName)
	{
		SceneManager.LoadScene (SceneName);
	}

	public void restarter(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex); //still bugged when restarting
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
