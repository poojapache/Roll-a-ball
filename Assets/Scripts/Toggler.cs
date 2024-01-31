using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggler : MonoBehaviour
{
    public GameObject cylinder;
    private bool isCoroutineRunning = false;

    void Start()
    {
        StartCoroutine(ShowAndHide());
    }

    void Update()
    {
        if (!isCoroutineRunning)
        {
            StartCoroutine(ShowAndHide());
        }
    }

    IEnumerator ShowAndHide()
    {
        isCoroutineRunning = true;
        float randomNumber = Random.Range(0, 2);
        yield return new WaitForSeconds(5 + randomNumber);
        // Scale down
        while (cylinder.transform.localScale.x > 0.0f)
        {
            cylinder.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
            yield return null;
        }
        randomNumber = Random.Range(0, 2);
        yield return new WaitForSeconds(5 + randomNumber);

        // Scale up
        while (cylinder.transform.localScale.x < 0.5f)
        {
            cylinder.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
            yield return null;
        }

        isCoroutineRunning = false;
        randomNumber = Random.Range(0, 2);
        yield return new WaitForSeconds(5 + randomNumber);
    }
}
