using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float jedaMax, jedaMin;
    float jeda;
    public GameObject virus, meds, sanitizer;
    int virusSpawn = 8, medsSpawn = 1, sanitizerSpawn = 1;
    int sumSpawn;
    float jedaRight, jedaLeft;
    float timerRight, timerLeft;

    // Start is called before the first frame update
    void Start()
    {
        sumSpawn = virusSpawn + medsSpawn + sanitizerSpawn;
        jeda = jedaMax;
        jedaRight = Random.Range(0.0f, jeda);
        jedaLeft = Random.Range(0.0f, jeda);
    }

    // Update is called once per frame
    void Update()
    {
        int difficulty = (int) jedaMax - Data.score / 200;
        if (difficulty > jedaMin) jeda = difficulty;

        // Spawn right
        timerRight += Time.deltaTime;
        if (timerRight > jedaRight) {
            GameObject go = randomSpawn();
            Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, Random.Range(0.2f, 1.0f)));
            position.z = 0;
            GameObject objek = Instantiate(go, position, Quaternion.identity);
            objek.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Random.Range(-6, -3), Random.Range(3, 6));

            timerRight = 0;
            jedaRight = Random.Range(0.0f, jeda);
        }

        // Spawn Left
        timerLeft += Time.deltaTime;
        if (timerLeft > jedaLeft) {
            GameObject go = randomSpawn();
            Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, Random.Range(0.2f, 1.0f)));
            position.z = 0;
            GameObject objek = Instantiate(go, position, Quaternion.identity);
            objek.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Random.Range(3, 6), Random.Range(3, 6));

            timerLeft = 0;
            jedaLeft = Random.Range(0.0f, jeda);
        }

    }

    private GameObject randomSpawn()
    {
        int random = Random.Range(0, sumSpawn);
        GameObject go;
        if(random < virusSpawn) {
            go = virus;
        } else if(random < virusSpawn + medsSpawn) {
            go = meds;
        } else {
            go = sanitizer;
        }
        return go;
    }
}
