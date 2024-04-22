using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody myRB;
    [SerializeField] private AudioClip caminar;
    [SerializeField] private AudioClip tocarnivel;
    [SerializeField] private AudioClip salirnivel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private AudioSource audioSource3;
    [SerializeField] private float x_Movement;
    [SerializeField] private float z_Movement;
    [SerializeField] private bool isMoving;
    [SerializeField] private float velocityModifier = 5f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (x_Movement != 0 || z_Movement != 0)
        {
            if (!isMoving)
            {
                audioSource.Play();
                isMoving = true;
            }
        }
        else if (isMoving)
        {
            audioSource.Stop();
            isMoving = false;
        }
    }
    void FixedUpdate()
    {
        myRB.velocity = new Vector3(x_Movement * velocityModifier, myRB.velocity.y, z_Movement * velocityModifier);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("entrada1"))
        {
            audioSource2.Play();
        }
        else if (other.CompareTag("nivel1"))
        {
            SceneManager.LoadScene("nv1");
        }
        else if (other.CompareTag("nivel2"))
        {
            SceneManager.LoadScene("nv2");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("entrada1"))
        {
            audioSource3.Play();
        }
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        x_Movement = context.ReadValue<Vector3>().x;
        z_Movement = context.ReadValue<Vector3>().z;
    }
}
