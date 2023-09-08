using UnityEngine;

public class FoodController : MonoBehaviour
{
    [SerializeField] private GameObject _foodSprite;
    private GenerateFloor _generateFloor;
    private GameObject _food;
    private Snake _snake;

    public int Score { get; private set; } = 0;

    void Start()
    {
        _generateFloor = FindObjectOfType<GenerateFloor>();
        _snake = FindObjectOfType<SnakeHolder>().Snake;
        GenerateFood();
    }

    private void GenerateFood()
    {
        var go = Instantiate(_foodSprite);
        int x = Random.Range(-_generateFloor.weight / 2, _generateFloor.weight / 2);
        int y = Random.Range(-_generateFloor.height / 2, _generateFloor.height / 2);
        go.transform.position = new Vector3(x, y, 0f);
        go.GetComponent<Renderer>().sortingOrder = 10;
        _food = go;
    }

    void Update()
    {
        if ((int)_food.transform.position.x == _snake[0].X && (int)_food.transform.position.y == _snake[0].Y)
        {
            _snake.CreateNewSnakePart();
            Destroy(_food);
            GenerateFood();
            Score++;
        }
    }
}
