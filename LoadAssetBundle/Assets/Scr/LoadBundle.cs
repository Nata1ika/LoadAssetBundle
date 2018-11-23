using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vuforia;

/// <summary>
/// This MonoBehaviour implements the Cloud Reco Event handling for this sample.
/// It registers itself at the CloudRecoBehaviour and is notified of new search results.
/// </summary>
public class LoadBundle : MonoBehaviour
{

    private GameObject obj, obj_temp;



    public void OnNewSearchResult()
    {
        string BundleURL;
#if UNITY_EDITOR
        BundleURL = "http://URL_SERVER/models_WEB.unity3d";
#endif

#if UNITY_IPHONE
        BundleURL = "http://URL_SERVER/models_IOS.unity3d"; 
#endif

#if UNITY_ANDROID
        BundleURL = "http://URL_SERVER/models_ANDROID.unity3d";
#endif

        string model_infos = null; //TODO from MetaData;
        string[] infos = model_infos.Split(',');
        string name = infos[0];
        float[] properties = new float[11];
        for (int i = 1; i < infos.Length; i++)
        {
            properties[i - 1] = Single.Parse(infos[i]);
        }
        //StartCoroutine(LoadBundle(BundleURL, name, properties));
    }

    /*
    IEnumerator LoadBundle(string BundleURL, string name, float[] properties)
    {
        // Start a download of the given URL
        WWW www = < a href = "http://WWW.LoadFromCacheOrDownload" > WWW.LoadFromCacheOrDownload </ a > (BundleURL, 1);
        // Wait for download to complete
        yield return www;

        // Load and retrieve the AssetBundle
        AssetBundle bundle = < a href = "http://www.assetBundle" > www.assetBundle </ a >;

        // Load the object asynchronously
        AssetBundleRequest request = bundle.LoadAsync(name, typeof(GameObject));
        // Wait for completion
        yield return request;
        // Get the reference to the loaded object
        obj = request.asset as GameObject;
        obj.transform.localPosition = new Vector3(properties[0], properties[1], properties[2]);
        obj.transform.eulerAngles = new Vector3(properties[3], properties[4], properties[5]);
        obj.transform.localScale = new Vector3(properties[6], properties[7], properties[8]);
        if (www == null)
            throw new Exception("WWW download had an error:" + "sacre error");
        else
            obj_temp = Instantiate(obj) as GameObject;

        bundle.Unload(false);
    }

    IEnumerator assign3DModel(string assetDwnLinkPrefix, string detectedTargetName)
    {
        //assetDwnLinkPrefix is the download link
        string assetDwnLink = assetDwnLinkPrefix + detectedTargetName + ".unity3d";

        using (WWW www = new WWW(assetDwnLink))
        {
            yield return www;
            File.WriteAllBytes(Application.persistentDataPath + "/" + detectedTargetName, < a href = "http://www.bytes" > www.bytes </ a >);
            AssetBundle assetBundle = < a href = "http://www.assetBundle" > www.assetBundle </ a >;
            GameObject gameobj = assetBundle.mainAsset as GameObject;
            GO = Instantiate(gameobj) as GameObject;
            GO.transform.parent = GameObject.Find("CloudRecoTarget").transform;
            GO.SetActive(true);
            assetBundle.Unload(false);
        }
    }
    */
}