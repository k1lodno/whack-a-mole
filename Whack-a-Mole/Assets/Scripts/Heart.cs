using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public float activeTime, timer;
    private bool isActive = true;
    private Health addHealth;

    private void Awake()
    {
        addHealth = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            activeTime -= Time.deltaTime;

            if (timer >= activeTime)
            {
                Destroy(gameObject);
                timer = 0;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        addHealth.health++;
        isActive = false;
    }
}
