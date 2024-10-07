using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlayer : MonoBehaviour
{
    private Animator animator;
    private GameManager manager;
    private string state;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        manager = GameManager.Instance;
    }
    public void ChangeState(string _state)
    {
        state = _state;
    }
    public void RunAnim()
    {
        animator.Play(state);
    }
    public void OnEnable()
    {
        gameObject.SetActive(true);
    }
    public void OnDisable()
    {
        gameObject.SetActive(false);
    }
    public void SpawnPlayer()
    {
        manager.SpawnPlayer();
    }
    public void Disappear(Transform disappearPos)
    {
        transform.position = disappearPos.position;
        OnEnable();
        ChangeState("Disappear");
        RunAnim();
    }
    public void Appear(Transform spawnPoint)
    {
        transform.position = spawnPoint.position;
        OnEnable();
        ChangeState("Appear");
        RunAnim();
    }
}
