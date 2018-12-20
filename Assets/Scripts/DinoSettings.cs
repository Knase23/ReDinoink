using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSettings : MonoBehaviour
{

    private static DinoSettings instance = null;


    [Header("Movement Settings")]
    //Max velocity
    [Range(0, 20)] [SerializeField]
    internal float movmentVelocityMax;

    // On Ground
    [Range(0, 10)] [SerializeField]
    internal float dragGround;
    [Range(0, 200)] [SerializeField]
    internal float accelerationGround;

    //In Air
    [Range(0, 10)] [SerializeField]
    internal float dragAir;
    [Range(0, 200)] [SerializeField]
    internal float accelerationAir;

    /// <summary>
    /// Float : 1f = 1 Unit
    /// </summary>
    [Header("Jump Settings")]
    [Range(1, 10)] [SerializeField] [Tooltip("Is based on Units(1 = 1 unit)")]
    internal float jumpHeight;
    
    [Range(5, 20)][SerializeField]
    internal float jumpSpeed;

    [Range(0, 10)][SerializeField]
    internal float fallMultiplier;
    [Range(0, 10)][SerializeField]
    internal float lowJumpMultiplier;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
   
    }
}
