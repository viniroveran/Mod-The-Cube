using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private bool scaleUp = true;
    private bool moveCube = true;
    private int timerCounter = 0;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(Random.value, Random.value, Random.value, 1.0f);

        StartCoroutine(timer());
    }
    
    void Update()
    {
        Material material = Renderer.material;

        // Rotate cube
        transform.Rotate(20.0f * Time.deltaTime, 20.0f * Time.deltaTime, 50.0f * Time.deltaTime);

        // Move cube
        if (transform.position.z < -5)
            moveCube = true;

        if (transform.position.z > 5)
            moveCube = false;

        if (moveCube)
            transform.position += Vector3.forward * Time.deltaTime;
        else
            transform.position -= Vector3.forward * Time.deltaTime;

        // Change cube size
        if (Vector3.Distance(transform.localScale, Vector3.one ) > 5.0f)
            scaleUp = false;

        if (Vector3.Distance(transform.localScale, Vector3.one) < 1.5f)
            scaleUp = true;

        if (scaleUp)
            transform.localScale += Vector3.one * Time.deltaTime;
        else
            transform.localScale -= Vector3.one * Time.deltaTime;

        // Change cube color
        if (timerCounter > 2)
        {
            material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
            timerCounter = 0;
        }
    }

    IEnumerator timer()
    {
        while (true)
        {
            timeCount();
            yield return new WaitForSeconds(1);
        }
    }

    void timeCount()
    {
        timerCounter += 1;
    }
}
