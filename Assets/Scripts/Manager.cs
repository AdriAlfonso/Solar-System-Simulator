using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    readonly float G = 0.1f;
    GameObject[] celestials;

    // Start is called before the first frame update
    void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial");
        InitialVelocity(); 
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        Gravity();
    }

    void Gravity(){
        foreach(GameObject a in celestials){
            foreach(GameObject b in celestials){
                if(!a.Equals(b)){
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float distance = Vector3.Distance(a.transform.position, b.transform.position);

                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (G * (m1 * m2) / (distance * distance)));
                }
            }
        }
    }

    void InitialVelocity(){
        foreach(GameObject a in celestials){
            foreach(GameObject b in celestials){
                if(!a.Equals(b)){
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float distance = Vector3.Distance(a.transform.position, b.transform.position);
                    a.transform.LookAt(b.transform);

                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G * m2) / distance);
                }
            }
        }
    }
}
