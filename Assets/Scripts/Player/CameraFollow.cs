using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform m_FollowTarget;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Vector2 leftBottomLimit;
    [SerializeField] private Vector2 rightTopLimit;
    [SerializeField] private Vector3 positionOffset;

    [Range(0f, 1f)]
    public float smoothTime;
    // Start is called before the first frame update
    void Awake()
    {   
        m_FollowTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        CamFollow();
    }
    private void CamFollow()
    {
        Vector3 targetPosition = m_FollowTarget.position + positionOffset;
        targetPosition = new Vector3(Mathf.Clamp(m_FollowTarget.position.x, leftBottomLimit.x, rightTopLimit.x), 
            Mathf.Clamp(m_FollowTarget.position.y, leftBottomLimit.y, rightTopLimit.y), targetPosition.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref velocity, smoothTime);
    }
    public Transform GetTarget() => m_FollowTarget;
    public void ChangeYLimit(float bottomY, float topY)
    {
        leftBottomLimit.y = bottomY;
        rightTopLimit.y = topY;
    }
}
