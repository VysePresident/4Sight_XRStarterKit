using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using UnityEngine;

public class AppBarPositioning : MonoBehaviour
{
	public AppBar appBar;
	public BoundsControl target;

	private void Start()
	{
		if (appBar == null || target == null) return;
	}

	private void Update()
	{
		appBar.transform.position = target.gameObject.transform.position;
	}
}
