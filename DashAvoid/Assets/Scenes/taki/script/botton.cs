using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botton : MonoBehaviour {


    public void OnClickStartButton()
    {
        SceneManager.LoadScene("InGame");
    }
}
