using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Rigidbody2D enteredRigidbody;
    private float enterVelocity, exitVelocity;

    private void OnTriggerEnter2D(Collider2D collision) {
        enteredRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        enterVelocity = enteredRigidbody.velocity.x;

        if (gameObject.name == "Blueportal")
        {
            portalcontrol.portalControlInstance.DisableCollider("orange");
            portalcontrol.portalControlInstance.CreateClone("atOrage");
        }
        else if (gameObject.name == "OrangePortal")
        {
            portalcontrol.portalControlInstance.DisableCollider("blue");
            portalcontrol.portalControlInstance.CreateClone("atBlue");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        
        exitVelocity = enteredRigidbody.velocity.x;

        if (enterVelocity != exitVelocity) {
            Destroy(GameObject.Find("Clone"));

        }
        else if (gameObject.name != "Clone") {
            Destroy(collision.gameObject);
            portalcontrol.portalControlInstance.EnableColliders();
            GameObject.Find("Clone").name ="character";
        }
        
    }
    
}
