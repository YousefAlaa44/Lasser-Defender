using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    void Start()
    {
        Text myText = GetComponent<Text>();
        myText.text = ScoreKeeper.score.ToString();
        ScoreKeeper.Reset();
    }

    
}
