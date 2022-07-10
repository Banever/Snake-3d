using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newmove : MonoBehaviour
{
    public CharacterController Controller;
    public float speed;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("horizontal");
        float vertical = Input.GetAxisRaw("vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
    }
}
