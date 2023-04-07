using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadVuforiaScene : MonoBehaviour
{
	public int vuforiaSceneBuildIndex;

	public void LoadScene()
	{
		Debug.Log("Loading Vuforia scene with build index: " + vuforiaSceneBuildIndex);
		SceneManager.LoadScene(vuforiaSceneBuildIndex);
	}
}
