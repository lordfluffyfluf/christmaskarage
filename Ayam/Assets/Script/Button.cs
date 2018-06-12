using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    private bool isActive;

    private void Start()
    {
        isActive = false;
    }

    public void ChangeSceneInto(string SceneName)
	{
		SceneManager.LoadScene (SceneName);
	}

	public void restarter(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
	}

	public void Exit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit ();
		#endif
	}

    public void ChooseTrack(int SelectedTrack)
    {
        TrackManager.selectedTrack = SelectedTrack;
        ChangeSceneInto("In Game");
    }


    public void Race(GameObject ChooseTrackPanel)
    {
        isActive = !isActive;
        if (isActive) ChooseTrackPanel.SetActive(false);
        else ChooseTrackPanel.SetActive(true);
    }
}
