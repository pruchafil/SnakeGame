using UnityEngine;

public class GenerateFloor : MonoBehaviour
{
    [SerializeField] private GameObject _floor;
    public int height, weight;

    void Start()
    {
        for (int i = -height / 2; i < height / 2; i++)
        {
            for (int j = -weight / 2; j < weight / 2; j++)
            {
                var go = Instantiate(_floor);
                go.transform.position = new Vector3(j, i, 0f);
            }
        }
    }
}
