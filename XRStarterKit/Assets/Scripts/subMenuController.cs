using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Normal.Realtime;


public class subMenuController : MonoBehaviour
{
	public Text furnitureNameText;
	public Text descriptionText;
	public Text priceText;

	private FurnitureDetails currentFurnitureDetails;
	private GameObject currentFurnitureObject;

	private RealtimeView furnitureRealtimeView;

	public void SetFurnitureDetails(FurnitureDetails furnitureDetails, GameObject furnitureObject)
	{
		if (furnitureDetails == null || furnitureObject == null)
		{
			Debug.LogError("FurnitureDetails or furnitureObject is null.");
			return;
		}

		currentFurnitureDetails = furnitureDetails;
		currentFurnitureObject = furnitureObject;

		// Update UI elements with furniture details
		if (furnitureNameText != null) furnitureNameText.text = furnitureDetails.furnitureName;
		if (descriptionText != null) descriptionText.text = furnitureDetails.description;
		if (priceText != null) priceText.text = $"${furnitureDetails.price}";
	}


	//public void Remove()
	//{
	//	FurnitureController.AddedFurniture.Remove(currentFurnitureObject);
	//	if (furnitureRealtimeView != null)
	//	{
	//		Realtime.Destroy(currentFurnitureObject);
	//	}
	//	else
	//	{
	//		Debug.LogWarning("Furniture RealtimeView is missing. Falling back to regular Destroy method.");
	//		FurnitureController.AddedFurniture.Remove(currentFurnitureObject);
	//		Destroy(currentFurnitureObject);
	//	}
	//}
	public void Remove()
	{
		FurnitureController.AddedFurniture.Remove(currentFurnitureObject);

		RealtimeView furnitureRealtimeView = currentFurnitureObject.GetComponent<RealtimeView>();
		if (furnitureRealtimeView != null)
		{
			Debug.Log("remove");
			Realtime.Destroy(furnitureRealtimeView);
		}
		else
		{
			Debug.LogWarning("Furniture RealtimeView is missing. Falling back to regular Destroy method.");
			Destroy(currentFurnitureObject);
		}
	}



	public void ShowDetails()
	{
		// You can display additional details or open another UI panel here.
		Debug.Log("Show furniture details");
	}

	public void AddToCart()
	{
		// Implement the logic to add the furniture to the cart
		Debug.Log($"Add {currentFurnitureDetails.furnitureName} to cart");
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void CloseARView()
	{
		// Load the main menu scene or another scene
		SceneManager.LoadScene("MainMenu");
	}
}
