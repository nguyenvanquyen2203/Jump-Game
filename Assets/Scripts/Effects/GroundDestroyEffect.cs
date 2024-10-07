using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyEffect : MonoBehaviour
{
    private static GroundDestroyEffect instance;
    public static GroundDestroyEffect Instance { get { return instance; } }
    [SerializeField] private ParticleSystem[] groundDestroys;
    // Start is called before the first frame update
    private void Reset()
    {
        groundDestroys = GetComponentsInChildren<ParticleSystem>();
    }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        foreach (var groundDestroy in groundDestroys) groundDestroy.gameObject.SetActive(false);
    }
    public void Active(Vector3 groundPos)
    {
        foreach (var groundDestroy in groundDestroys)
        {
            if (!groundDestroy.gameObject.activeSelf)
            {
                groundDestroy.transform.position = groundPos;
                groundDestroy.gameObject.SetActive(true);
                return;
            }
        }
    }
}
