using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FurnitureButton : MonoBehaviour
{
	public string furniturePrefabName;
	public int vuforiaSceneBuildIndex;

	private Button button;

	private void Awake()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(OnClick);
	}

	public void OnClick()
	{
		PlayerPrefs.SetString("SelectedFurniture", furniturePrefabName);
		SceneManager.LoadScene(vuforiaSceneBuildIndex);
	}
}
