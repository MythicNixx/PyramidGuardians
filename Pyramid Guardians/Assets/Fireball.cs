using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject fireballEffect1;
    public GameObject fireballEffect2;
    public GameObject fireballEffect3;
    public GameObject fireballEffect4;

    private void Awake()
    {
        Instantiate(fireballEffect1, GetComponentInParent<Transform>().transform.position, Quaternion.identity);
        Instantiate(fireballEffect2, GetComponentInParent<Transform>().transform.position, Quaternion.identity);
        Instantiate(fireballEffect3, GetComponentInParent<Transform>().transform.position, Quaternion.identity);
        Instantiate(fireballEffect4, GetComponentInParent<Transform>().transform.position, Quaternion.identity);
    }

}
