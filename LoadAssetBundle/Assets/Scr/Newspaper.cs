using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Newspaper : MonoBehaviour
{
    [SerializeField] NewspaperPage _pagePrefab;
    [SerializeField] Button _nextButton;
    [SerializeField] Button _prevButton;

    private NewspaperPage[] _pages;
    [SerializeField] private int _currentPage = -1;


    public void Init(NewspaperJson json)
    {
        int countPages = json.pathImage.Length / 2;
        _pages = new NewspaperPage[countPages];

        for (int i = 0; i < countPages; i++)
        {
            _pages[i] = Instantiate(_pagePrefab, transform);
            _pages[i].transform.localPosition = new Vector3(0, 0.001f * (countPages - i), 0);

            _pages[i].StartCoroutine(_pages[i].SetImage(json.pathImage[i*2], json.pathImage[i * 2 + 1]));
        }

        _nextButton.interactable = (_currentPage < _pages.Length - 1);
        _prevButton.interactable = (_currentPage >= 0);
    }

    public void Next()
    {
        _currentPage++;
        _pages[_currentPage].Next();

        _nextButton.interactable = (_currentPage < _pages.Length - 1);
        _prevButton.interactable = (_currentPage >= 0);
    }

    public void Prev()
    {        
        _pages[_currentPage].Prev();
        _currentPage--;

        _nextButton.interactable = (_currentPage < _pages.Length - 1);
        _prevButton.interactable = (_currentPage >= 0);
    }
}
