using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatus", menuName = "EnemyStatus")]
public class EnemyStatus : ScriptableObject
{
    public float health = 40;
    public float damage = 10;
    public int score = 1000;
    public float movementSpeed = 1;
    public float attackRate = 1;
    public float bulletSpeed = 1;
    public float detectRange = 1;
    public float actionRange = 1;
}
