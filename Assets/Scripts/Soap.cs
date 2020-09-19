using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soap : MonoBehaviour
{
    public Text textScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Virus"))
        {
            Data.score += 10;
            textScore.text = Data.score.ToString();
            Destroy(collision.gameObject);
        }
    }
}
