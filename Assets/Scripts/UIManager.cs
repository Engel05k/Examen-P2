using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI livesText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateLives(int current)
    {
        livesText.text = $"Lives: {current}";
    }
}