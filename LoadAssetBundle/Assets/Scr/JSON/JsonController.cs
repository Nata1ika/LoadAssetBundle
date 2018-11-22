using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonController : MonoBehaviour
{
    private void Start()
    {
        string[] path = new string[6];
        for (int i = 0; i < path.Length; i++)
        {
            path[i] = string.Format("https://raw.githubusercontent.com/Nata1ika/LoadAssetBundle/uniWebView/newspaper/{0}.jpg", i);
        }

        var newspaper = new NewspaperJson(path);
        Debug.Log(JsonUtility.ToJson(newspaper));
    }
}
