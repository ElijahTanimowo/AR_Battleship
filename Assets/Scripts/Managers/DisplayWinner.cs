using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayWinner : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI displayWinnerText;
    [SerializeField] GameObject displayObject;

    // Start is called before the first frame update
    void Start()
    {
        if (UIManager.Instance != null) 
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
        }
    }

}
