using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class PillKill : MonoBehaviour
{

    bool dead = false;
    AudioSource AS;
    NavMeshAgent NM;
    Animator anim;
    public bool removeAfterDie = false;
    public UnityEvent dieEvent;
    public float dieDelay = 5f;
    public GameObject dieFX;
    public GameObject dieRemoveFX;
    public GameObject enemy;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (!dead)
            {
                AS = enemy.GetComponent<AudioSource>();
                NM = enemy.GetComponent<NavMeshAgent>();
                anim = enemy.GetComponent<Animator>();

                dead = true;
                AS.Stop();
                AS.pitch = 1;

                NM.enabled = false;
                if (anim)
                    anim.SetTrigger("die");

                dieEvent.Invoke();
                if (dieFX)
                    Instantiate(dieFX, transform.position, Quaternion.identity);
                if (removeAfterDie)
                    Invoke("Remove", dieDelay);
            }
        }
           
    }

    void Remove()
    {
        Destroy(enemy);
        if (dieRemoveFX)
            Instantiate(dieRemoveFX, transform.position, Quaternion.identity);
    }

}
