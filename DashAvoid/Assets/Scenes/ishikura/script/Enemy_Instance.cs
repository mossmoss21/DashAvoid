using UnityEngine;
using System.Collections;

public class Enemy_Instance : MonoBehaviour
{

    public GameObject instance;     // リスポーン値
    public GameObject Obj;          // 何をリスポーンさせるか

    bool instantMode = false;       

    // Update is called once per frame
    void Update()
    {
        if (!instantMode)
        {
            instantMode = true;
            StartCoroutine("instant");
        }
    }
    private IEnumerator instant()
    {
        yield return new WaitForSeconds(50 * Time.deltaTime);
        Instantiate(Obj, instance.transform.position, Quaternion.identity);
        instantMode = false;
    }
}