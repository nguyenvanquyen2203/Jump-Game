using UnityEngine;

public class CreateChain : MonoBehaviour
{
    public GameObject chainPrefab;
    public float distanceChain;
    public Transform lastChain;
    private Vector3 platformPos;
    private Vector3 distanceVector;
    private void Awake()
    {
        platformPos = lastChain.localPosition;
        Vector3 chainPos = transform.position;
        distanceVector = platformPos.normalized * distanceChain;
        for (int i = 1; i <= platformPos.magnitude / distanceChain; i++)
        {
            chainPos += distanceVector;
            GameObject chain = Instantiate(chainPrefab, chainPos, Quaternion.identity);
            chain.transform.SetParent(transform);
        }
    }
}
