using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField]
    Text score;  //スコアが表示されるt場所

    float timesScore = 0.00f;

    void Update()
    {
        timesScore += Time.deltaTime;

        score.text = "現在の飛行距離/km：" + timesScore; //スコア
    }
}
