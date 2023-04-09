using UnityEngine;
using Vuforia;

public class VuforiaFurnitureManager : MonoBehaviour
{
	public GameObject activeFurniture;
	private bool isPlaced;

	private void Awake()
	{
		// Load the selected furniture from PlayerPrefs
		string furnitureName = PlayerPrefs.GetString("SelectedFurniture");

		// Instantiate the furniture prefab
		GameObject prefab = Resources.Load<GameObject>("Furniture/Prefabs/" + furnitureName);
		//SpawnFurniture(prefab);
	}
	/*
		private void Update()
		{
			if (activeFurniture == null || isPlaced)
				return;

			// Position the furniture at the center of the screen
			Vector3 centerScreenPos = new Vector3(Screen.width / 2, Screen.height / 2, 0);
			Ray ray = Camera.main.ScreenPointToRay(centerScreenPos);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				activeFurniture.transform.position = hit.point;
				activeFurniture.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
			}

			// Check for touches or mouse clicks
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
			{
				isPlaced = true;
				activeFurniture = null;
			}
		}
	*/
	private void Update()
	{
		if (activeFurniture == null || isPlaced)
			return;

		// Position the furniture at the center of the screen
		Vector3 centerScreenPos = new Vector3(Screen.width / 2, Screen.height / 2, 5); // Set distance from the camera here
		activeFurniture.transform.position = Camera.main.ScreenToWorldPoint(centerScreenPos);

		// Check for touches or mouse clicks
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
		{
			isPlaced = true;
			activeFurniture = null;
		}
	}

	public void SpawnFurniture(GameObject prefab)
	{
		if (activeFurniture != null)
			return;

		activeFurniture = Instantiate(prefab);
		isPlaced = false;
	}
}
