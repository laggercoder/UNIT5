using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float maxSpeed = 17;
    private float minSpeed = 13;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpaw = -6;
    private Spawnager gameManager;
    private int pointValue = 1;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRb= GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        //ForceMode.Impulse là chỉ phương thức tác dụng của lực 
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        // thêm một lực xoắn cho vật thể , truyền vào hai giá trị là hướng của lực và lực)
        transform.position = RandomSpawn();
        gameManager = GameObject.Find("GameManager").GetComponent<Spawnager>();

        
    }

    // Update is called once per frame
    void Update()   
    {
        
    }
    private void OnMouseDown()
    {
       if(gameManager.isActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
            if (gameObject.CompareTag("Bad"))
            {
                gameManager.gameOver();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.gameOver();
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawn()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpaw);
    }
    
    
}
