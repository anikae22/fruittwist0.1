using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCodedDoor : MonoBehaviour
{
    public Animator anim;
   public int blueKey = 0;

   [SerializeField]

   [Header("fruitSound")]

   public AudioSource aud;

   public AudioClip fruitClip;

     [Range(0f, 1f)]

    public float fruitVolume = 0.5f;

    [Header("doorSound")]

    public AudioSource aud2;

    public AudioClip doorClip;
    [Range(0f, 1f)]

    public float doorVolume = 0.5f;



   void OnTriggerEnter(Collider other)
   {
       Debug.Log(other.tag);
       if (other.gameObject.CompareTag("BlueKey"))
       {
           blueKey += 1;
           aud.PlayOneShot(fruitClip);
           Destroy(other.gameObject);
       }
       if(other.gameObject.CompareTag("BlueDoor"))
       {
           if(blueKey>0)
           {
               blueKey -= 1;
               aud.PlayOneShot(doorClip);
               Destroy(other.gameObject);
           }
           else
           {
               Debug.Log("You need a blue key");
               
           }
       }
   }
}