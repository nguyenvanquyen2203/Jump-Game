using UnityEngine;

public class DeathRotate : MonoBehaviour
{
    public float rotateSpeed;
    private float rotationSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        
    }
    void Start()
    {
        rotationSpeed = rotateSpeed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotationSpeed > 0f) rotationSpeed -= Time.fixedDeltaTime * 15f;
        transform.Rotate(Vector3.forward * Time.fixedDeltaTime * rotationSpeed);
    }
}
