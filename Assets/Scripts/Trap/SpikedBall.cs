using UnityEngine;

public class SpikedBall : MonoBehaviour
{
    [SerializeField] private float pulsat;
    private float angleRotation;
    private int direction;
    [SerializeField] private float phaseAngle;
    // Start is called before the first frame update
    void Start()
    {
        angleRotation = 0;
        direction = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        angleRotation += Time.fixedDeltaTime * pulsat * direction;
        if (angleRotation * direction >= 180)
        {
            angleRotation *= -1;
        }
        Rotate(angleRotation);
        if (angleRotation * direction >= phaseAngle) direction *= -1;
    }
    private void Rotate(float _phaseAngle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, _phaseAngle);
    }
}
