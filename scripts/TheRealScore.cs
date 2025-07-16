using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheRealScore : MonoBehaviour
{
    [SerializeField] public Text MyscoreText;
    public int ScoreAmount;
    public GameObject mortar1;

    void Start()
    {
        ScoreAmount = 0;
        MyscoreText.text = "Score : " + ScoreAmount;
    }

    public void OnMouseDown()
    {
        ScoreAmount += 10;
         MyscoreText.text = "Score : " + ScoreAmount;
    }

}
