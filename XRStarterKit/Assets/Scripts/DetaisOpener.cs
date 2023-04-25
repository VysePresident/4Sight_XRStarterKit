/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetaisOpener : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    public void OpenPanel()
    {
        Debug.Log("OpenPanel");

        if(Panel != null)
        {
			Debug.Log("Panel != null");

			Panel.SetActive(true);
        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetaisOpener : MonoBehaviour
{
	public GameObject panelPrefab;
	private GameObject panelInstance;

	public void OpenPanel()
	{
		Debug.Log("OpenPanel");

		if (panelPrefab != null)
		{
			Debug.Log("Panel Prefab != null");

			if (panelInstance == null)
			{
				panelInstance = Instantiate(panelPrefab);
				panelInstance.transform.SetParent(transform, false);
			}
			else
			{
				panelInstance.SetActive(true);
			}
		}
	}

	public void ClosePanel()
	{
		if (panelInstance != null)
		{
			panelInstance.SetActive(false);
		}
	}
}
