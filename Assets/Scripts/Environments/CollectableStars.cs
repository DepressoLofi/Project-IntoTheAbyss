using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableStars : MonoBehaviour
{
    public void IsCollected()
    {
        Destroy(gameObject);
    }
}
