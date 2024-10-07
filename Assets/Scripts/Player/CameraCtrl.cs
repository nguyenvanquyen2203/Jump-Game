using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public List<Vector2> yLimits;
    private Transform m_target;
    private CameraFollow camFollow;
    float viewportHeight;
    // Start is called before the first frame update
    private void Awake()
    {
        camFollow = GetComponent<CameraFollow>();
    }
    void Start()
    {
        m_target = camFollow.GetTarget();

        //Caculator viewport Height
        float orthographicSize = Camera.main.orthographicSize;

        viewportHeight = orthographicSize * 2;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        foreach (Vector2 floorLimit in yLimits)
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
}
