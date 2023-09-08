using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeDeathController : MonoBehaviour
{
    private Snake _snake;
    private int w,h;

    void Start()
    {
        _snake = FindObjectOfType<SnakeHolder>().Snake;
        h = FindObjectOfType<GenerateFloor>().height;
        w = FindObjectOfType<GenerateFloor>().weight;
    }

    void Update()
    {
        var head = _snake[0];
        if (head.X >= w / 2 || head.Y >= h / 2 || head.X < -w / 2 || head.Y < -h / 2) // map border
        {
            SceneManager.LoadScene(0);
        }

        for (int i = 1; i < _snake.Count; i++)
        {
            if (_snake[0].X == _snake[i].X && _snake[0].Y == _snake[i].Y)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
