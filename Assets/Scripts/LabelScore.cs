using TMPro;
using UnityEngine;

public class LabelScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    private FoodController _foodController;

    private void Start()
    {
        _foodController = FindObjectOfType<FoodController>();
    }

    void Update()
    {
        _label.text = _foodController.Score.ToString();
    }
}
