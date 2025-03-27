using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectToInstantiate;

    public void InstantiateObjectPosition(Transform asset)
    {
        Instantiate(_objectToInstantiate, asset.position, Quaternion.identity);
    }
}
