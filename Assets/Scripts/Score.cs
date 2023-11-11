using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    // Start is called before the first frame update
    void Start()
    {
        displayText.text = "Your Score : " + GameManager.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
