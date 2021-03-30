using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public float rotationSpeed;
    public Image hiddenPokemon;
    public bool isShowingPokemon;
    Animator animator;
    public string PokemonName;
    void Start()
    {
        animator = transform.GetComponent<Animator>();
        isShowingPokemon = false;
    }

    void Update()
    {

    }

    public void FlipBack()
    {
        if (StateSelectCard.selectedTwo.Equals(GameManager.GetInstance().stateSelectCard))
            return;

        if (StateSelectCard.selectedZero.Equals(GameManager.GetInstance().stateSelectCard)
            || StateSelectCard.selectedOne.Equals(GameManager.GetInstance().stateSelectCard))
        {
            animator.SetTrigger("flipBack");
            GameManager.GetInstance().IncrementSelectedCard(1);
            GameManager.GetInstance().stateSelectCard = (StateSelectCard)(GameManager.GetInstance().selectedCards);
            GameManager.GetInstance().SetCardSelected(gameObject);
            // GameManager.GetInstance().AreSamePokemon();
            if (StateSelectCard.selectedTwo.Equals(GameManager.GetInstance().stateSelectCard))
            {
                print(GameManager.GetInstance().AreSamePokemon());
                if (GameManager.GetInstance().AreSamePokemon())
                {
                    StartCoroutine("DisableCardEquals");
                }
                else
                {
                    StartCoroutine("DisableCardNoEquals");
                }
            }
        }
    }

    IEnumerator DisableCardEquals()
    {
        yield return new WaitForSeconds(animator.runtimeAnimatorController.animationClips[0].length);
        GameManager.GetInstance().selectedCardOne.GetComponent<Image>().color = Color.gray;
        GameManager.GetInstance().selectedCardTwo.GetComponent<Image>().color = Color.gray;
        GameManager.GetInstance().stateSelectCard = StateSelectCard.selectedZero;
        GameManager.GetInstance().selectedCards = 0;
        //    GameManager.GetInstance().DisableCardEquals();
    }

    IEnumerator DisableCardNoEquals()
    {
        yield return new WaitForSeconds(animator.runtimeAnimatorController.animationClips[0].length);
        GameManager.GetInstance().selectedCardOne.GetComponent<CardController>().animator.SetTrigger("flipFront");
        GameManager.GetInstance().selectedCardTwo.GetComponent<CardController>().animator.SetTrigger("flipFront");
        yield return new WaitForSeconds(animator.runtimeAnimatorController.animationClips[1].length);
        GameManager.GetInstance().stateSelectCard = StateSelectCard.selectedZero;
        GameManager.GetInstance().selectedCards = 0;
        GameManager.GetInstance().SetCardSelected(null);
    }

}


