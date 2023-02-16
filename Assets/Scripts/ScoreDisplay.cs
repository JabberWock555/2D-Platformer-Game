using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public static int ScoreValue;
    private Text Display;

    private void Awake()
    {
        ScoreValue = 0;
        Display = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        Display.text = "Score: " + ScoreValue;
    }
}
