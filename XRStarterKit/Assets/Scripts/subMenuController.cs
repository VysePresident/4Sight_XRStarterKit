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

	public GameObject currentFurnitureObject;
	private RealtimeView furnitureRealtimeView;
	public GameObject furnitureDetailsPanel;

	public void UpdateFurnitureDetailsPanel(GameObject selectedFurniture)
	{
		// Get the SelectionTest component from the selected furniture
		SelectionTest selectionTest = selectedFurniture.GetComponent<SelectionTest>();

		// Update the UI Text components with the furniture details
		furnitureNameText.text = selectionTest.furnitureName;
		descriptionText.text = selectionTest.furnitureDescription;
		priceText.text = selectionTest.furniturePrice.ToString();
	}

	public void ToggleFurnitureDetailsPanel()
	{
		if (furnitureDetailsPanel.activeSelf)
		{
			furnitureDetailsPanel.SetActive(false);
		}
		else
		{
			// Update the FurnitureDetailsPanel with the selected furniture details
			UpdateFurnitureDetailsPanel(currentFurnitureObject);
			furnitureDetailsPanel.SetActive(true);
		}
	}


	public void ShowDetails()
	{
		ToggleFurnitureDetailsPanel();
		Debug.Log("Show furniture details");
	}

	public void HideDetails()
	{
		furnitureDetailsPanel.SetActive(false); // Deactivate the panel
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


	//public void AddToCart()
	//{
	//	// Implement the logic to add the furniture to the cart
	//	Debug.Log($"Add {currentFurnitureDetails.furnitureName} to cart");
	//}

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
