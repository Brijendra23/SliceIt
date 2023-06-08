using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetrb;
    private float minSpeed = 12f;
    private float maxSpeed = 17f;
    private float maxTorque = 10f;
    private float xRange = 4f;
    private float yRange = -6f;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem particleExplosion;
   
    // Start is called before the first frame update
    void Start()
    {
        targetrb=GetComponent<Rigidbody>();
        targetrb.AddForce(RandomForce(),ForceMode.Impulse);
        targetrb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPosition();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(particleExplosion, transform.position, particleExplosion.transform.rotation);
        gameManager.UpdateScore(pointValue) ;

    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Sensor"))
        { Destroy(gameObject); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), yRange);
    }
}
