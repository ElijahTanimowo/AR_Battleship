using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    static UIManager _instance = null;
    public GameObject playButton;
    public TMP_Text title;

    public static UIManager Instance
    {
        get
        {
            if (!_instance)
                _instance = new GameObject("UIManager").AddComponent<UIManager>();

            return _instance;

		}
    }

    void Awake()
    {

    }
    public void onPlay()
    {
        //when button pressed, load main scene
        
    }
}
