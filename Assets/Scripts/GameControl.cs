using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText, player3MoveText;

    private List<Player> players = new List<Player>();

    public static int diceSideThrown = 0;
    public static int turn = 0;

    public static bool gameOver = false;
    public static bool moveAllowed = false;
    public static bool wasAKill = false;

    // Start is called before the first frame update
    void Start()
    {
        whoWinsTextShadow = GameObject.Find("WhoWinsText");

        Player player = new Player(GameObject.Find("Player1"));
        Player player2 = new Player(GameObject.Find("Player2"));
        Player player3 = new Player(GameObject.Find("Player3"));
        players.Add(player);
        players.Add(player2);
        players.Add(player3);
        whoWinsTextShadow.gameObject.SetActive(false);
    }

    // Update is called once per frame

    void Update(){
        checkWinner();
        if(moveAllowed){
            players[turn].movePlayer(diceSideThrown);
            moveAllowed = false;
        }
        checkOverlap(players[turn]);
    }

    private void checkWinner(){
        for(int i = 0; i<3; i++){
            if(players[i].isWinner()){
                gameOver = true;
                whoWinsTextShadow.GetComponent<Text>().text = "Player"+(i+1)+" Wins!";
                whoWinsTextShadow.gameObject.SetActive(true);
            }
        }
    }

    private void checkOverlap(Player mainPlayer){
        foreach (Player player in players){
            if( player != mainPlayer && mainPlayer.getPosition() != 0 && player.getPosition() != 0){
                if(Vector3.Distance(player.getVectorPosition(), mainPlayer.getVectorPosition()) == 0 && mainPlayer.getPosition() == player.getPosition()){
                    player.die();
                    wasAKill = true;
                }
            }
        }
    }
}
