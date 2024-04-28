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
    public GameObject messagePanel; // Referencia al panel de mensaje en el Canvas
    public float displayTime = 5.0f; // Tiempo que se mostrará el mensaje
    public NPCMove npcMovement; // Referencia al script de movimiento del NPC
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        messagePanel.SetActive(false); // Oculta el panel de mensaje al inicio
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
    public void Interaction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(InteractWithNPC());
        }
    }
    private IEnumerator InteractWithNPC()
    {
        // Asegúrate de que el jugador esté cerca del NPC y de que el NPC no se esté moviendo
        if (Vector3.Distance(transform.position, npcMovement.transform.position) < 3.0f && !npcMovement.IsMoving)
        {
            messagePanel.SetActive(true); // Muestra el panel de mensaje
            npcMovement.PauseMovement(); // Detiene el movimiento del NPC

            yield return new WaitForSeconds(displayTime); // Espera por el tiempo definido

            messagePanel.SetActive(false); // Oculta el panel de mensaje
            npcMovement.ResumeMovement(); // Reanuda el movimiento del NPC
        }
    }
}
