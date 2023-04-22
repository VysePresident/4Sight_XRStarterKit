using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenInAR : MonoBehaviour
{
	public FurnitureDetails furnitureDetails;
	public void MoveToScene(int sceneID)
    {
		SceneData.Instance.selectedFurniture = furnitureDetails;
		SceneManager.LoadScene(sceneID);
    }
}
