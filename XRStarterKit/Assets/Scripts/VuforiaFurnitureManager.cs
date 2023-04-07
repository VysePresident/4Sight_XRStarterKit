using UnityEngine;
using UnityEngine.EventSystems;
using Vuforia;

public class VuforiaFurnitureManager : MonoBehaviour
{

	private GameObject activeFurniture;
	private bool isPlaced;

	void Update()
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
			if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && !EventSystem.current.IsPointerOverGameObject())
			{
				isPlaced = true;
				activeFurniture = null;
			}
		}
	}

	// Add a new method to spawn the furniture prefab
	public void SpawnFurniture(GameObject prefab)
	{
		if (activeFurniture != null)
			return;

		activeFurniture = Instantiate(prefab);
		isPlaced = false;
	}
}
