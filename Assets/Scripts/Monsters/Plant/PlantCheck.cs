using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCheck : MonoBehaviour
{
    public IAttackable monster;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        monster.Attack();
    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        monster.canAttack = false;
    }*/
}
