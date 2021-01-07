using UnityEngine;
public class Player
{
    private int waypointIndex;
    private Path path;
    private GameObject player;

    public Player(){

    }

    public Player(GameObject newPlayer){
        player = newPlayer;
        path = new Path(newPlayer);
    }

    public void setPosition(int newPosition){
        path.setPosition(newPosition);
    }

    public int getPosition(){
        return path.getPosition();
    }

    public Vector3 getVectorPosition(){
        return player.transform.position;
    }

    public Path getPath(){
        return path;
    }

    public GameObject getPlayer(){
        return player;
    }

    public void movePlayer(int move){
        path.move(move);
    }

    public bool isWinner(){
        return path.isWinner();
    }

    public void die(){
        path.die();
    }
}
