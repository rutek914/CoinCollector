using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 30f;
    [SerializeField] private float rotationSpeed = 10000f;

    private Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = movement.normalized * moveSpeed * Time.deltaTime;


        // transform.position to aktualna pozycja postaci, movement to vektor ruchu kt�ry dodajemy do aktualnej pozycji aby przesun�� posta�.
        rb.MovePosition(transform.position + movement);


        // je�eli posta� wgl si� porusza, a nie movement wynosi 0,0,0
        if (movement != Vector3.zero)
        // to: 
        {
            // nowa rotacja dla postaci na podstawie wektora ruchu. posta� b�dzie patrze� w kierunku, w kt�rym, si� porusza
            Quaternion newRotation = Quaternion.LookRotation(movement);

            // powoli obraca posta� w kierunku ruchu, a nie natychmiast. transform.rotation = aktualna pozycja, id� w kierunku newRotation , z pr�dko�ci� rotationspeed
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, newRotation, rotationSpeed * Time.deltaTime));
        }
    }
}
