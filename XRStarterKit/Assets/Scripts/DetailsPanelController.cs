using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DetailsPanelController : MonoBehaviour
{
	public GameObject detailsPanel;
	public TextMeshProUGUI furnitureNameText;
	public TextMeshProUGUI descriptionText;
	public TextMeshProUGUI priceText;


	public void Show(FurnitureDetails furnitureDetails)
	{
		if (furnitureDetails == null) return;

		Debug.Log("Show() called");

		furnitureNameText.text = furnitureDetails.furnitureName;
		descriptionText.text = furnitureDetails.description;
		priceText.text = $"${furnitureDetails.price}";

		detailsPanel.SetActive(true);
	}


	public void Hide()
	{
		detailsPanel.SetActive(false);
	}
}
