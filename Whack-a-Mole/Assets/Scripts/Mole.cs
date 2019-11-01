using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    private Health health;
    private HUD score;

    public float lifeTime, timer;
    public bool isAlive = true;

    private void Awake()
    {
        health = FindObjectOfType<Health>();
        score = FindObjectOfType<HUD>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            timer += Time.deltaTime;
            lifeTime -= Time.deltaTime;
            
            if (timer >= lifeTime)
            {
                Destroy(gameObject);
                timer = 0;
                health.Damage();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void OnMouseDown()
    {
        score.hitCount++;
        isAlive = false;
    }

}
