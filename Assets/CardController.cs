using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public float rotationSpeed;
    public Image hiddenPokemon;
    public bool isShowingPokemon;
    GameManager gameManager;
    void Start()
    {
        isShowingPokemon = false;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {

    }

    public void RotateCard()
    {
        if (gameManager.selectedCards >= 2)
            return;

        print("ROTATE CARD");
        if (!isShowingPokemon)
        {
            gameManager.SelectCard(1);
            StartCoroutine("StartRotation");
        }
    }

    IEnumerator StartRotation()
    {
        while (true)
        {
            if (transform.rotation.y >= 1f)
            {
                isShowingPokemon = true;
                yield return new WaitForSeconds(1f);
                StartCoroutine("StartRotationBack");
                yield break;
            }

            if (transform.rotation.y <= 0.71f && transform.rotation.y >= 0.7f)
            {
                hiddenPokemon.gameObject.SetActive(true);
            }
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.Self);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator StartRotationBack()
    {
        while (true)
        {
            if (transform.rotation.y <= 0f)
            {
                isShowingPokemon = false;
                gameManager.SelectCard(-1);
                yield break;
            }

            if (transform.rotation.y <= 0.71f && transform.rotation.y >= 0.7f)
            {
                hiddenPokemon.gameObject.SetActive(false);
            }

            transform.Rotate(Vector3.down * Time.deltaTime * rotationSpeed, Space.Self);
            yield return new WaitForEndOfFrame();
        }
    }
}


