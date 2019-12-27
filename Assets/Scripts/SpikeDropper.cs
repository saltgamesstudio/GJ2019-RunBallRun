using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDropper : MonoBehaviour
{
    public GameObject spike;
    private Rigidbody2D spikeRigid;
    // Start is called before the first frame update
    void Start()
    {
        spikeRigid = spike.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spikeRigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
