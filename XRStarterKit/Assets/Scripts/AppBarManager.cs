using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;

public class AppBarManager : MonoBehaviour
{
	public GameObject appBarPrefab;
	private GameObject appBarInstance;
	public Camera mainCamera;
	public float distanceFromCamera = 2f;
	public float verticalOffset = -0.3f;

	void Start()
	{
		mainCamera = Camera.main;
	}

	void Update()
	{
		if (appBarInstance != null)
		{
			Vector3 cameraForward = mainCamera.transform.forward;
			Vector3 cameraUp = mainCamera.transform.up;
			Vector3 appBarPosition = mainCamera.transform.position + cameraForward * distanceFromCamera + cameraUp * verticalOffset;
			appBarInstance.transform.position = appBarPosition;
			appBarInstance.transform.LookAt(mainCamera.transform.position);
			appBarInstance.transform.rotation = Quaternion.Euler(0, appBarInstance.transform.rotation.eulerAngles.y, 0);
		}
	}

	public void ShowAppBar(BoundsControl target)
	{
		if (appBarInstance == null)
		{
			appBarInstance = Instantiate(appBarPrefab, transform);
			appBarInstance.GetComponent<AppBar>().Target = target;
			appBarInstance.GetComponent<RectTransform>().localScale = new Vector3(0.01f, 0.01f, 0.01f); // Adjust the scale as needed
		}
	}

	public void HideAppBar()
	{
		if (appBarInstance != null)
		{
			Destroy(appBarInstance);
			appBarInstance = null;
		}
	}
}
