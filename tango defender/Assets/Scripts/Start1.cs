using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Start1 : MonoBehaviour {

    public void LoadStage()
    {
        SceneManager.LoadScene("game");
    }
}
