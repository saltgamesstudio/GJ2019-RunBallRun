using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRockTrigger : MonoBehaviour
{
    public GameObject bigRock;
    private Rigidbody2D bigRockRigid;
    public float force;



    // Start is called before the first frame update
    void Start()
    {
        bigRockRigid = bigRock.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {


            bigRockRigid.constraints = RigidbodyConstraints2D.None;
            bigRockRigid.AddForce(Vector2.right * force);
        }
    }
}
