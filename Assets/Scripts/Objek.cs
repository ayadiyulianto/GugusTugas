using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objek : MonoBehaviour
{
    public Sprite[] sprites;
    public float lifeTime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, sprites.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index];
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
