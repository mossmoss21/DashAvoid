using UnityEngine;

public class script : MonoBehaviour
{

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 100, 50), "BGM1"))
        {
            AudioManager.Instance.PlayBGM("BGM1");
        }
        if (GUI.Button(new Rect(110, 100, 100, 50), "BGM2"))
        {
            AudioManager.Instance.PlayBGM("BGM2");
        }
        if (GUI.Button(new Rect(210, 100, 100, 50), "BGM3"))
        {
            AudioManager.Instance.PlayBGM("BGM3");
        }
        if (GUI.Button(new Rect(310, 100, 100, 50), "BGMSTOP"))
        {
            AudioManager.Instance.StopBGM();
        }
        if (GUI.Button(new Rect(10, 200, 100, 50), "SE1"))
        {
            AudioManager.Instance.PlaySE("SE1");
        }
        /*if (GUI.Button(new Rect(110, 200, 100, 50), "SE2"))
        {
            AudioManager.Instance.PlaySE("se2");
        }
        if (GUI.Button(new Rect(210, 200, 100, 50), "SE3"))
        {
            AudioManager.Instance.PlaySE("se3");
        }*/
        if (GUI.Button(new Rect(310, 200, 100, 50), "SESTOP"))
        {
            AudioManager.Instance.StopSE();
        }

    }
}