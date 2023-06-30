using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCharacter : MonoBehaviour
{
    private CharacterController characterController;

    public float speed;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        characterController.Move(move * Time.deltaTime * speed);
    }
}
