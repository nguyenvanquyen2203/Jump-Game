using UnityEngine;

public class ItemUndulate : MonoBehaviour
{
    public float amplitude;
    public float angularFrequency;
    private float x = 0;
    private float time = 0;
    Vector3 orginalPos;
    private void Start()
    {
        orginalPos = transform.position;
        
    }
    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        x = amplitude * Mathf.Cos(time * angularFrequency * Mathf.PI / 180);
        transform.position = orginalPos + Vector3.up * x;
    }
}
