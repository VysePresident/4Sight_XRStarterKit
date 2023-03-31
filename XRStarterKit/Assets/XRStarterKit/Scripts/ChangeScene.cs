using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ar()
    {
        SceneManager.LoadScene("ARBasic");
    }

    public void addFurniture()
    {
        SceneManager.LoadScene("ShopMenuScene");
    }
}
