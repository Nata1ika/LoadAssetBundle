using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    [SerializeField] GameObject _newspaperPrefab;

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
            _currentObj = GameObject.Instantiate(_newspaperPrefab, parent.transform);
        }
    }
}
