using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Vector3 checkPos;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           // player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = checkPos;
           // player.GetComponent<CharacterController>().enabled = true;

        }
    }
}
