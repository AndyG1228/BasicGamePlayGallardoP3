using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float beckon = 2;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && beckon <= 0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            beckon = 2;
        }
        if (beckon >= 0)
        {
            beckon -= Time.deltaTime;
        }
    }
}
