using UnityEngine;

[RequireComponent(typeof(ResourcesLoader))]
public class EntryPointBehaviour : MonoBehaviour
{
    private void Awake()
    {
        EntryPoint entryPoint = new EntryPoint(GetComponent<ResourcesLoader>());
    }
}
