using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  MonsterMouvement : MonoBehaviour
{

    // --------------- patrol ----------------

    public Transform[] PatrolPoints;
    public float Speed = 2f;
    public int PatrolDestination = 0;
    public SpriteRenderer Monster_Sprite;
   public bool IsHitting = false;
    [SerializeField] Monsters_SCript isliving;

    // --------------- chase -----------------
    public Transform Player;
    [SerializeField] public bool IsChasing = false;
    public float chaseDistance = 3f;

    void Update()
    {
        
        if (!IsHitting && isliving.IsAlive == true)
        {
            Speed = 2f;
            enemymove();
        }
        else
        {

            Speed = 0f;

        }
    }

    private void enemymove()
    {
        // if the bool ischasing is false and if the player is withint the chase distance then the monster will follow the player on the X axis
        if (IsChasing )
        {
           
            if (transform.position.x > Player.position.x)
            {
                //  transform.localScale = new Vector3(1, 1, 1);
                transform.localScale = new Vector3(3f, 3f, 3f);
                transform.position += Vector3.left * Speed * Time.deltaTime;
            }

            if (transform.position.x < Player.position.x)
            {
                //  transform.localScale = new Vector3(1, 1, 1);
                transform.localScale = new Vector3(-3f, 3f, 3f);
                transform.position += Vector3.right * Speed * Time.deltaTime;
                
            }
        }
        // if the bool ischasing is false and if the player is withint the chase distance then the bool ischasing is flipped to true
        else
        {
            if (Vector2.Distance(transform.position, Player.position) < chaseDistance)
            {
                IsChasing = true;
            }
            //the monster will go to the first patrol point then flip himself
            if (PatrolDestination == 0)
            {  
                transform.position = Vector2.MoveTowards(transform.position, PatrolPoints[0].position, Speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, PatrolPoints[0].position) < 0.2f)
                {
                   // transform.localScale = new Vector3(-1,1,1);
                    transform.localScale = new Vector3(-3f, 3f, 3f);
                    PatrolDestination = 1;
                }
            }
            //the monster will go to the second patrol point then flip himself
            if (PatrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, PatrolPoints[1].position, Speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, PatrolPoints[1].position) < 0.2f)
                {
                    //  transform.localScale = new Vector3(1, 1, 1);
                    transform.localScale = new Vector3(3f, 3f, 3f);
                    PatrolDestination = 0;
                }
            }
        }
    }
}
