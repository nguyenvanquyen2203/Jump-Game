using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    private static CameraCtrl instance;
    public static CameraCtrl Instance { get { return instance; } }
    public List<Vector2> yFloorLimits;
    private Transform m_target;
    private CameraFollow camFollow;
    private float viewportHeight;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        camFollow = GetComponent<CameraFollow>();

        float orthographicSize = Camera.main.orthographicSize;

        viewportHeight = orthographicSize * 2;
    }
    void Start()
    {
        m_target = camFollow.GetTarget();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        foreach (Vector2 floorLimit in yFloorLimits)
        {
            if (floorLimit.x <= m_target.position.y && floorLimit.y >= m_target.position.y)
            {
                ChangeCamLimit(Mathf.Min(floorLimit.x + viewportHeight / 2, floorLimit.y - viewportHeight / 2), Mathf.Max(floorLimit.x + viewportHeight / 2, floorLimit.y - viewportHeight / 2));
                return;
            }
        }
    }
    private void ChangeCamLimit(float bottomY, float topY)
    {
        camFollow.ChangeYLimit(bottomY, topY);
    }
    public float GameHeight() => (yFloorLimits[yFloorLimits.Count -  1][1] - yFloorLimits[0][0] > 0) ? yFloorLimits[yFloorLimits.Count - 1][1] - yFloorLimits[0][0] : viewportHeight;
    public float CenterY() => (yFloorLimits[yFloorLimits.Count - 1][1] + yFloorLimits[0][0]) / 2;
}
