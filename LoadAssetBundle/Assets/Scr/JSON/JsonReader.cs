using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    [SerializeField] Newspaper _newspaperPrefab;

    private GameObject _currentObj;
    private string _meta;

    private void Awake()
    {
        SimpleCloudHandler.ChangeTargetEvent += Show;
    }

    private void OnDestroy()
    {
        SimpleCloudHandler.ChangeTargetEvent -= Show;
    }

    public void Show(string meta, GameObject parent)
    {
        if (meta == _meta)
        {
            return;
        }
        _meta = meta;

        if (_currentObj != null)
        {
            GameObject.Destroy(_currentObj);
        }

        var info = JsonUtility.FromJson<Json>(meta);
        if (info.type == "Newspaper")
        {
            var newspaper = GameObject.Instantiate(_newspaperPrefab, parent.transform);
            var newspaperInfo = JsonUtility.FromJson<NewspaperJson>(meta);
            newspaper.Init(newspaperInfo);
            _currentObj = newspaper.gameObject;
        }
    }

    [ContextMenu("Initialization")]
    public void Test()
    {
        Show("{\"type\":\"Newspaper\",\"pathImage\":[\"https://raw.githubusercontent.com/Nata1ika/LoadAssetBundle/blob/master/newspaper/0.jpg\",\"https://raw.githubusercontent.com/Nata1ika/LoadAssetBundle/blob/master/newspaper/1.jpg\",\"https://raw.githubusercontent.com/Nata1ika/LoadAssetBundle/blob/master/newspaper/2.jpg\",\"https://raw.githubusercontent.com/Nata1ika/LoadAssetBundle/blob/master/newspaper/3.jpg\",\"https://raw.githubusercontent.com/Nata1ika/LoadAssetBundle/blob/master/newspaper/4.jpg\",\"https://raw.githubusercontent.com/Nata1ika/LoadAssetBundle/blob/master/newspaper/5.jpg\"]}", gameObject);
    }
}
