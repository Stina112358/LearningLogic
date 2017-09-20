using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.tag == "TutorialPenguin")
        {
            Destroy(collide.gameObject);
        }
    }
}
