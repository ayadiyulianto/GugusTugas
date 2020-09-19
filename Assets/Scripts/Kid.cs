using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Kid : MonoBehaviour
{
    public Image[] hpImages;
    private int hp;
    public Image shield;
    private bool isProtected = false;
    public Text textScore;
    public AudioClip audioCough;
    public AudioClip audioRestore;
    private AudioSource MediaPlayerCough;
    private AudioSource MediaPlayerRestoreHealth;

    // Start is called before the first frame update
    void Start()
    {
        Data.score = 0;
        hp = hpImages.Length;
        shield.enabled = isProtected;

        MediaPlayerCough = gameObject.AddComponent<AudioSource>();
        MediaPlayerCough.clip = audioCough;
        MediaPlayerRestoreHealth = gameObject.AddComponent<AudioSource>();
        MediaPlayerRestoreHealth.clip = audioRestore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Virus")) {
            if (isProtected) {
                isProtected = false;
                shield.enabled = false;
            } else {
                Data.score -= 10;
                textScore.text = Data.score.ToString();
                if (hp > 0) hp -= 1;
                updateHP();
                MediaPlayerCough.Play();
            }
        } else if (collision.tag.Equals("Sanitizer") && !isProtected) {
            isProtected = true;
            shield.enabled = true;
            MediaPlayerRestoreHealth.Play();
        } else if (collision.tag.Equals("Meds") && hp < hpImages.Length) {
            hp += 1;
            updateHP();
            MediaPlayerRestoreHealth.Play();
        }

        Destroy(collision.gameObject);
    }

    void updateHP() {
        if (hp <= 0) SceneManager.LoadScene("Gameover");

        for (int i=0; i<hpImages.Length; i++) {
            hpImages[i].enabled = (i < hp);
        }
    }
}