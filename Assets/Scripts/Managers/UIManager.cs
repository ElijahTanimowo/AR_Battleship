using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI displayWinnerText;
    [SerializeField] GameObject displayObject;
    [SerializeField] Button playerButton;
    [SerializeField] GameObject playObj;


    [SerializeField] GameObject displayCanvas;

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

    private void Update()
    {
        FindWinTextObj();
        DisplayWinner();
    }

    private void FindWinTextObj()
    {
        if (displayObject == null)
        {

            displayObject = GameObject.Find("WhoWonText");
            if (displayObject != null)
            {
                playObj = GameObject.Find("Button");
                displayWinnerText = displayObject.GetComponent<TextMeshProUGUI>();
                playerButton = playObj.GetComponent<Button>();
                //playerButton.onClick.AddListener(onPlay);
            }
        }
    }

    private void DisplayWinner()
    {

        if (UIManager.Instance != null && displayWinnerText != null)
        {
            if (UIManager.Instance.player1Won)
            {
                displayWinnerText.text = "Player 1 Won";
                displayObject.SetActive(true);
            }
            else if (UIManager.Instance.player2Won)
            {
                displayWinnerText.text = "Player 2 Won";
                displayObject.SetActive(true);
            }
            else
            {
                displayWinnerText.text = "";
            }
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
        FindWinTextObj();

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
