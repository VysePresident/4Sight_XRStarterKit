using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class AppBarPositioning: MonoBehaviour
{
	public AppBar appBar;
	public GameObject targetObject;
	public float yOffset = -0.5f;

	void Update()
	{
		if (appBar != null && targetObject != null)
		{
			Bounds bounds = targetObject.GetComponent<Collider>().bounds;
			Vector3 appBarPosition = bounds.center + new Vector3(0, bounds.extents.y * yOffset, 0);
			appBar.transform.position = appBarPosition;
		}
	}
}
