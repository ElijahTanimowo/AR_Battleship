using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    static UIManager _instance = null;
    public TMP_Text title;

    public bool player1Won;
    public bool player2Won;

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
