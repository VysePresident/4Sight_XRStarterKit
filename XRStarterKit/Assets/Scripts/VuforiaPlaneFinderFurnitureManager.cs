using UnityEngine;

public class VuforiaPlaneFinderFurnitureManager : MonoBehaviour
{
	public GameObject furniturePrefab;
	private GameObject activeFurniture;
	private bool isPlaced;

	private void Awake()
	{
		// Load the selected furniture from PlayerPrefs
		string furnitureName = PlayerPrefs.GetString("SelectedFurniture");

		// Instantiate the furniture prefab
		furniturePrefab = Resources.Load<GameObject>("Furniture/Prefabs/" + furnitureName);

		if (furniturePrefab != null)
		{
			Debug.Log("Furniture prefab loaded: " + furnitureName);
		}
		else
		{
			Debug.Log("Furniture prefab not found: " + furnitureName);
		}
	}

	public void SpawnFurniture(Vector3 position, Quaternion rotation)
	{
		if (furniturePrefab == null || isPlaced) return;

		if (activeFurniture == null)
		{
			activeFurniture = Instantiate(furniturePrefab);
		}

		activeFurniture.transform.position = position;
		activeFurniture.transform.rotation = rotation;
		isPlaced = true;
		Debug.Log("SpawnFurniture called with position: " + position + ", rotation: " + rotation);
	}
}
