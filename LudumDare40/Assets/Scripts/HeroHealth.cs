using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroHealth : MonoBehaviour {
    
    public int waitingDie;
    int nrMouse = 0;
    int nrOfSprite = 0;
    public Sprite[] sprites;
    public GameObject hero;
    // Use this for initialization
    void Start()
    {
    }
    private void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(WaitForDie());
            CameraMovement.moveSpeed = 0.0f;
            hero.GetComponent<HeroMovement>().moveSpeed = 0.0f;
            hero.GetComponent<Transform>().Rotate(hero.GetComponent<Transform>().rotation.x, hero.GetComponent<Transform>().rotation.y, 180);
            print("Leg");
        }

        if (coll.gameObject.CompareTag("Mouse"))
        {
            Destroy(coll.gameObject);

            hero.GetComponent<HeroMovement>().moveSpeedy -= 0.5f;

            if (nrMouse % 2 == 0 && nrMouse != 0)
            {
                hero.GetComponent<SpriteRenderer>().sprite = sprites[nrOfSprite];
                nrOfSprite++;
            }
            nrMouse++;
        }
    }
    IEnumerator WaitForDie()
    {
        yield return new WaitForSeconds(waitingDie);
        SceneManager.LoadScene("scene1");
    }
}
