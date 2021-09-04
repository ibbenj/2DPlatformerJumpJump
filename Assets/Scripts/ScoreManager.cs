using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public static int score= 0;

    // Start is called before the first frame update
    void Start()
    {
        if(instance==null){
            instance= this;
        }
        score= StateNameController.score;
        text.text= "x "+ score.ToString();
    }

    public void ChangeScore(int coinValue){
        score += coinValue;
        text.text= "x "+ score.ToString();
    }
}
