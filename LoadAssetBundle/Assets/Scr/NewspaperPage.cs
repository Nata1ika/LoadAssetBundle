﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperPage : MonoBehaviour
{
    [SerializeField] Animator _animatorController;
    [SerializeField] MeshRenderer _first;
    [SerializeField] MeshRenderer _second;

    public IEnumerator SetImage(string firstPath, string secondPath)
    {
        WWW www = new WWW(firstPath);
        yield return www;
        _first.material.mainTexture = www.texture;

        www = new WWW(secondPath);
        yield return www;
        _second.material.mainTexture = www.texture;
    }

    public void Next()
    {
        _animatorController.SetTrigger("next");
    }

    public void Prev()
    {
        _animatorController.SetTrigger("prev");
    }
}