using UnityEngine;
using Vuforia;

public class CustomGroundPlaneEventHandler : MonoBehaviour
{
	public VuforiaPlaneFinderFurnitureManager furnitureManager;

	private void Update()
	{
		if (Input.touchCount == 0 || Input.GetTouch(0).phase != TouchPhase.Began)
			return;

		PlaneFinderBehaviour planeFinder = FindObjectOfType<PlaneFinderBehaviour>();
		if (planeFinder == null)
			return;

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

		if (Physics.Raycast(ray, out hit))
		{
			Vector3 position = hit.point;
			Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

			if (furnitureManager != null)
			{
				furnitureManager.SpawnFurniture(position, rotation);
			}
		}
	}
}
