using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroHealth : MonoBehaviour {
    
    public int waitingDie;
    int nrMouse = 0;
    int nrOfSprite = 0;
    static int nrOfPuss = 1;
    public Sprite[] sprites;
    public GameObject hero;
    public Text mouseScoreUI,pussnr;
    public GameObject deathScreen,winScreen;
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(WaitForDie());
            CameraMovement.moveSpeed = 0.0f;
            hero.GetComponent<HeroMovement>().moveSpeed = 0.0f;
            hero.GetComponent<Transform>().Rotate(hero.GetComponent<Transform>().rotation.x, hero.GetComponent<Transform>().rotation.y, 180);
            deathScreen.SetActive(true);
            print("Leg");
        }

        if (coll.gameObject.CompareTag("Mouse"))
        {
            Destroy(coll.gameObject);

            hero.GetComponent<HeroMovement>().moveSpeedy -= 0.4f;

            if (nrMouse % 2 == 0 && nrMouse != 0 && nrMouse != 10)
            {
                hero.GetComponent<SpriteRenderer>().sprite = sprites[nrOfSprite];
                nrOfSprite++;
            }
            nrMouse++;
            mouseScoreUI.text = nrMouse.ToString();
            if (nrMouse == 10)
            {
                pussnr.text = nrOfPuss.ToString();
                winScreen.SetActive(true);
                CameraMovement.moveSpeed = 0.0f;
                hero.GetComponent<HeroMovement>().moveSpeed = 0.0f;
            }
        }
    }
    IEnumerator WaitForDie()
    {
        yield return new WaitForSeconds(waitingDie);
        nrOfPuss++;
        SceneManager.LoadScene("scene1");
    }
    public void Restart()
    {
        nrOfPuss = 1;
        SceneManager.LoadScene("scene1");
    }
}
