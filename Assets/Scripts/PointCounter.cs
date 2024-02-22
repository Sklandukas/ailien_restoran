using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    private int points = 0;
    public Text scoreText;

    private void OnEnable()
    {
        FoodOrder.OnMyEvent += AddOneToPoint;
    }

    private void OnDisable()
    {
        FoodOrder.OnMyEvent -= AddOneToPoint;
    }

    private void AddOneToPoint()
    {
        points++;
        Debug.Log("Kintamasis dabar: " + points);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = points.ToString();
        }
        else
        {
            Debug.LogWarning("Score Text is not assigned!");
        }
    }
}
