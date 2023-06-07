using TMPro;
using UnityEngine;

public class SetScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI  score;

    private void OnEnable()
    {
        score.text = "0";
        ScoreManager.OnScoreChanged += SetText;
    }

    private void SetText()
    {
        score.text = ScoreManager.TotalScore.ToString();
    }
}
