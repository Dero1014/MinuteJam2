/*========================================*/
/*  This script holds player components   */
/*========================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponents : MonoBehaviour
{

    [HideInInspector]
    public static Rigidbody2D _rb;

    /*  Singleton start */
    public static PlayerComponents instance;
    private void Awake() { instance = this; }
    /*  Singleton end   */

    void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
}
