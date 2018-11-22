using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperJson : Json
{
    public NewspaperJson(string[] path)
    {
        type = "Newspaper";
        pathImage = new string[path.Length];
        for (int i=0; i<path.Length; i++)
        {
            pathImage[i] = path[i];
        }
    }

    public string[] pathImage;
}
