using UnityEngine;

public class SceneData : MonoBehaviour
{
	public static SceneData Instance;

	public FurnitureDetails selectedFurniture;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
