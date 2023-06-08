using System;
using TMPro;
using UnityEngine;

public class SetScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI  score;

    private Action setTextAction => SetText;

    private void OnEnable()
    {
        score.text = "0";
        ScoreManager.OnScoreChanged += setTextAction;
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreChanged -= setTextAction;
    }

    private void SetText()
    {
        score.text = ScoreManager.TotalScore.ToString();
    }
}
