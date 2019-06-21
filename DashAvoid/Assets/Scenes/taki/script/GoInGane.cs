using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoInGane : MonoBehaviour {

    [SerializeField] Graphics turebottom;




    public void OnClickStartButton()
    {
        SceneManager.LoadScene("InGame");
    }
}
