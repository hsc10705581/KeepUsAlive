using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("Level01");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
