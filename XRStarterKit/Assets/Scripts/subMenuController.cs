using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Normal.Realtime;
using TMPro;
using System.Collections;


public class subMenuController : MonoBehaviour
{
	public TextMeshProUGUI furnitureNameText;
	public TextMeshProUGUI sizeText;
	public TextMeshProUGUI priceText;
	public TextMeshProUGUI textureText;

	public GameObject currentFurnitureObject;
	private RealtimeView furnitureRealtimeView;
	public GameObject furnitureDetailsPanel;
	private GameObject furnitureDetailsPanelInstance;

	public void UpdateFurnitureDetailsPanel(GameObject selectedFurniture)
	{
		// Get the SelectionTest component from the selected furniture
		Debug.Log("Update Furniture Details");
		SelectionTest selectionTest = selectedFurniture.GetComponent<SelectionTest>();

		// Update the UI Text components with the furniture details
		furnitureNameText.text = selectionTest.furnitureName;
		sizeText.text = selectionTest.furnitureSize;
		priceText.text = "$"+selectionTest.furniturePrice.ToString();
		textureText.text = selectionTest.furnitureTexture;
		Debug.Log(furnitureNameText.text + sizeText.text + priceText.text);
	}

	public void ToggleFurnitureDetailsPanel()
	{
		if (furnitureDetailsPanelInstance == null)
		{
			Debug.Log("furnitureDetailsPanelInstance is null");
			furnitureDetailsPanelInstance = Instantiate(furnitureDetailsPanel);
			furnitureDetailsPanelInstance.transform.SetParent(transform, false);
			furnitureNameText = furnitureDetailsPanelInstance.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
			sizeText = furnitureDetailsPanelInstance.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
			priceText = furnitureDetailsPanelInstance.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>();
			textureText = furnitureDetailsPanelInstance.transform.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>();
			UpdateFurnitureDetailsPanel(currentFurnitureObject);
		}
		else
		{
			Destroy(furnitureDetailsPanelInstance);
			furnitureDetailsPanelInstance = null;
		}
	}

	private IEnumerator UpdateFurnitureDetailsPanelWithDelay(GameObject selectedFurniture)
	{
		yield return new WaitForEndOfFrame();
		UpdateFurnitureDetailsPanel(selectedFurniture);
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


	public void CloseARView()
	{
		// Load the main menu scene or another scene
		SceneManager.LoadScene("MainMenu");
	}
}
