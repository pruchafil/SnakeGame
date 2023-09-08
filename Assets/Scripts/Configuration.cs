using UnityEngine;

public class Configuration : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public float WaitTime { get; set; }
}
