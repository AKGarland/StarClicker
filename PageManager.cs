using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageManager : MonoBehaviour {

    public void QuitRequest(string name)
    {
        Application.Quit( );
    }

    public void LoadPage(string name)
    {
        SceneManager.LoadScene(name);
    }
}
