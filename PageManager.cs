using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageManager : MonoBehaviour {
    // This is a separate script because GameManager persists between scene & so can't be 
    // used on button OnClick functions. Each scene will have its own PageManager.

    public void QuitRequest(string name)
    {
        Application.Quit( );
    }

    public void LoadPage(string name)
    {
        SceneManager.LoadScene(name);
    }
}
