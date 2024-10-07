using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCheck : MonoBehaviour
{
    public Monster monster;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        monster.CanAttack(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        monster.CanAttack(false);
    }
}
