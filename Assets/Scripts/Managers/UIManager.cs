using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    static UIManager _instance = null;
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
        title = GameObject.FindGameObjectWithTag("TitleText").GetComponent<TMP_Text>();

		// Singleton UIManager
		if (_instance && _instance.GetInstanceID() != GetInstanceID())
			Destroy(gameObject);
		else
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	// Can be used to have strings used to change Scenes
	public void OnSceneChange(string name)
	{
		if (!string.IsNullOrEmpty(name))
		{
			// Load Scene
			SceneManager.LoadScene(name);
		}
	}
	public void onPlay()
    {
		//when button pressed, load main scene
		SceneManager.LoadScene("Main");
    }
}
