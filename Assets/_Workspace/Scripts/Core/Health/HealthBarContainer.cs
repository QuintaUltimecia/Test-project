using UnityEngine;

public class HealthBarContainer : MonoBehaviour
{
    public static HealthBarContainer Instance;
    public static Transform Transform { get;private set; }

    public void Awake()
    {
        Instance = this;
        Transform = transform;
    }
}
