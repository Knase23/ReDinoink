using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [Range(1,4)]
    public int playerNumber = 1;
    public GameObject selectedDinoPrefab;
    private DinoController dino;
    // Start is called before the first frame update
    void Start()
    {

        //selectedDinoPrefab = playerSelectColor[playerNumber - 1].selectedDino;

        GameObject p = Instantiate(selectedDinoPrefab, transform);
        p.name = p.name.Remove(p.name.Length - 7, 7);

        dino = GetComponentInChildren<DinoController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!dino.stunned)
        {
            dino.Move(Input.GetAxisRaw("Horizontal"));
            dino.Jump(Input.GetButton("Jump"));
        }
        else
        {
            dino.Move(0);
            dino.Jump(false);
        }

        if(Input.GetKey(KeyCode.E))
        {
            dino.AnimateStunned();
        }
        
    }
}
