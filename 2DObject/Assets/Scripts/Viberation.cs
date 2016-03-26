using UnityEngine;
using System.Collections;

public class Viberation : MonoBehaviour
{
    public AudioClip audioClip;
    public int Flag = 0;
    AudioSource audioSource;
    GameObject obj;
    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collider = Physics2D.OverlapPoint(tapPoint);
        if (collider != null)
        {
            obj = collider.transform.gameObject;
            if (obj.tag == "Tex" && Flag == 0)
            {
                audioSource.PlayOneShot(audioClip);
                Flag = 1;
            }
            //Destroy(obj);
        }
        else if (Flag == 1)
        {
            audioSource.PlayOneShot(audioClip);
            Flag = 0;
        }
        //}
    }
}