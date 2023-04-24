using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Normal.Realtime;
using TMPro;

public class subMenuController : MonoBehaviour
{
	public TextMeshProUGUI furnitureNameText;
	public TextMeshProUGUI descriptionText;
	public TextMeshProUGUI priceText;


	private FurnitureDetails currentFurnitureDetails;
	private GameObject currentFurnitureObject;

	private RealtimeView furnitureRealtimeView;
	public DetailsPanelController detailsPanelController;

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


	public void Remove()
	{
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
		if(detailsPanelController == null)
		{
			Debug.Log("Details is null");
		}
		if(currentFurnitureDetails == null)
		{
			Debug.Log("currentFurnitureDetails is null");
		}
		if (detailsPanelController != null && currentFurnitureDetails != null)
		{
			Debug.Log("ShowDetails() called");
			detailsPanelController.Show(currentFurnitureDetails);
		}
	}


	public void AddToCart()
	{
		// Implement the logic to add the furniture to the cart
		Debug.Log($"Add {currentFurnitureDetails.furnitureName} to cart");
	}

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


	public void CloseARView()
	{
		// Load the main menu scene or another scene
		SceneManager.LoadScene("MainMenu");
	}
}
