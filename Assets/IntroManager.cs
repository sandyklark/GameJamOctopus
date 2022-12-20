using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public List<GameObject> _introPanelList = new List<GameObject>();

    public int SlideIndex = 0;
    public GameObject ParentPanel;
    public void NextSlide()
    {
        SlideIndex++;
        for (int i = 0; i < _introPanelList.Count; i++)
        {
            _introPanelList[i].SetActive(false);
        }
        _introPanelList[SlideIndex].SetActive(true);
    }

    public void EndSlide()
    {
        // for (int i = 0; i < _introPanelList.Count; i++)
        // {
        //     _introPanelList[i].SetActive(false);
        // }
        // ParentPanel.SetActive(false);
        SceneManager.LoadScene(2);
    }
}
