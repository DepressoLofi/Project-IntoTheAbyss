using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName ="Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public int hitPoint = 1;
    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 0.4f;

    public float agroDistance = 3f;

    
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
