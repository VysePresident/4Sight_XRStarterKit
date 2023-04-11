using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
	public static FurnitureManager Instance;

	public List<GameObject> instantiatedFurnitureList;

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

	public void AddFurniture(GameObject furniture, Transform parent)
	{
		GameObject instantiatedFurniture = Instantiate(furniture, parent);
		instantiatedFurnitureList.Add(instantiatedFurniture);
	}
}
