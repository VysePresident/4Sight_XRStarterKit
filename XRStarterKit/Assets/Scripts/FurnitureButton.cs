using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FurnitureButton : MonoBehaviour
{
	public GameObject furniturePrefab;
	public VuforiaFurnitureManager furnitureManager;
	public int vuforiaSceneBuildIndex;

	private Button button;

	private void Awake()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		Debug.Log("Button clicked");
		furnitureManager.SpawnFurniture(furniturePrefab);
		Debug.Log("Requesting Vuforia scene load");

		LoadVuforiaScene loadVuforiaScene = FindObjectOfType<LoadVuforiaScene>();
		if (loadVuforiaScene != null)
		{
			loadVuforiaScene.LoadScene();
		}
		else
		{
			Debug.LogError("LoadVuforiaScene script not found in the scene");
		}
	}

}
