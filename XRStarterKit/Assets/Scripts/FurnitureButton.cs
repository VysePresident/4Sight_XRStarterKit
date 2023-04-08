using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FurnitureButton : MonoBehaviour
{
	public GameObject furniturePrefab;
	public int vuforiaSceneBuildIndex;

	private Button button;

	private void Awake()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(OnClick);
	}

	public void OnClick()
	{
		Debug.Log("Open in AR button clicked");

		// Save the selected prefab to PlayerPrefs
		PlayerPrefs.SetString("SelectedFurniture", furniturePrefab.name);

		// Load the Vuforia scene
		SceneManager.LoadScene(vuforiaSceneBuildIndex);
	}
}
