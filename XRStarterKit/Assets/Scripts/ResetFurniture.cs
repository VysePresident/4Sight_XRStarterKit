using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class ResetFurniture : MonoBehaviour
{
	public void Restart()
	{
		// Find all GameObjects with RealtimeView components
		RealtimeView[] realtimeViews = FindObjectsOfType<RealtimeView>();

		// Iterate through each RealtimeView and destroy the associated GameObject
		foreach (RealtimeView realtimeView in realtimeViews)
		{
			if (realtimeView.gameObject.CompareTag("Furniture"))
			{
				Realtime.Destroy(realtimeView.gameObject);
			}
		}
	}
}
