using System.Collections;
using UnityEngine;

public class BlueBird : RunMonster
{
    // Start is called before the first frame update
    private void Awake()
    {
        InitMonster();
    }
    void Start()
    {
        StartCoroutine(BirdMove());
        Move();
    }
    private IEnumerator BirdMove()
    {
        ChangeDirection();
        yield return new WaitForSeconds(3f);
        StartCoroutine(BirdMove());
    }
    protected override void Death()
    {
        base.Death();
        StopAllCoroutines();
    }
}
