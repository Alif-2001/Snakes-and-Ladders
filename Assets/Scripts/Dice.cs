using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    // Start is called before the first frame update
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private int whosTurn = 0;
    private bool coroutineAllowed = true;

	// Use this for initialization
	private void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
	}

  private void OnMouseDown()
  {
      if (!GameControl.gameOver && coroutineAllowed){
          StartCoroutine("RollTheDice");
      }
  }

  private IEnumerator RollTheDice()
  {
      coroutineAllowed = false;
      int randomDiceSide = 0;
      for (int i = 0; i <= 20; i++)
      {
          randomDiceSide = Random.Range(0, 6);
          rend.sprite = diceSides[randomDiceSide];
          yield return new WaitForSeconds(0.05f);
      }

      GameControl.diceSideThrown = randomDiceSide + 1;
      GameControl.turn = whosTurn;
      GameControl.moveAllowed = true;
      if(randomDiceSide == 5 || GameControl.wasAKill){} 
      else if (whosTurn == 0){
        whosTurn += 1;
      } else if (whosTurn == 1){
        whosTurn += 1;
      } else if (whosTurn == 2){
        whosTurn -= 2;
      }
      GameControl.wasAKill = false;
      coroutineAllowed = true;
    }
}
