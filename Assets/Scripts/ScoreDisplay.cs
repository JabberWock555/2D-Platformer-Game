using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public static int ScoreValue = 0 ;
    private Text Display;

    private void Awake()
    {
        Display = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        Display.text = "Score: " + ScoreValue;
    }
}
