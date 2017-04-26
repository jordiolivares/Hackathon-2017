using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    //public float jumpTime;
    //private float jumpCounter;
    //private bool endOfJump;

	public GameObject monsterAttack;
	public float attackRange;
	public float attackHeight;
	public float attackDelay;
	private float attackDelayCounter;
    private bool attacking;

    private bool onGround;
    public LayerMask isGround;
    public Transform groundCheck;
    public float groundCheckRadius;
    //public bool flyingType;

	public float maxHealth;
	private float currentHealth;
	public Text healthText;

	public float foodGoal;
	private float currentFood;
	public Text foodText;

	public GameController myGameController;
    private Rigidbody2D myRigidBody;

    private enum Direction {
        NONE,
        UP,
        DOWN,
        LEFT,
        RIGHT
    };

	private Direction facingDirection = Direction.RIGHT;
    private Direction direction;

    // Use this for initialization
    void Start() {
		currentHealth = maxHealth;
		currentFood = 0;
        myRigidBody = GetComponent<Rigidbody2D>();
        attacking = false;
		monsterAttack.transform.position = new Vector2 (monsterAttack.transform.position.x + attackRange, monsterAttack.transform.position.y + attackHeight);
        direction = Direction.NONE;
    }

    // Update is called once per frame
    void Update() {
		healthText.text = "Health: " + currentHealth;
		foodText.text = "Food: " + currentFood;
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGround);
        //if (!attacking) {
        //Movimiento derecha
        switch (direction) {
            case Direction.NONE:
                break;
			case Direction.LEFT:
				if (facingDirection != direction) {
					facingDirection = direction;
					transform.RotateAround (transform.position, new Vector3 (0, 1, 0), 180);
				}
                myRigidBody.velocity = new Vector2(-moveSpeed, myRigidBody.velocity.y);
                break;
            case Direction.RIGHT:
				if (facingDirection != direction) {
					facingDirection = direction;
					transform.RotateAround (transform.position, new Vector3 (0, 1, 0), 180);
				}
                myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
                break;
            case Direction.UP:
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                break;
            case Direction.DOWN:
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, -jumpForce);
                break;
        }
        if (!(Application.platform == RuntimePlatform.Android))
        {
            pcMovement();
        }
		if (attacking && attackDelayCounter > 0) {
			attackDelayCounter -= Time.deltaTime;
		}
		if (attacking && attackDelayCounter <= 0) {
			monsterAttack.SetActive (true);
			Invoke ("EndMonsterAttack", 0.3f);
			attacking = false;
		}
		if (currentHealth <= 0) {
			myGameController.GameRestart ();
		}

		if (currentFood >= foodGoal) {
			myGameController.GameWin ();
		}
    }
    public void moveRight() {
        direction = Direction.RIGHT;
    }
    public void moveLeft()
    {
        direction = Direction.LEFT;
    }
    public void moveUp()
    {
        if (onGround) {
            direction = Direction.UP;
        }
    }
    public void moveDown()
    {
        direction = Direction.DOWN;
    }
    public void stopMoving() {
        direction = Direction.NONE;
    }

    public void startEating(){
        attacking = true;
    }

    public void stopEating()
    {
        attacking = false;
    }
    private void pcMovement() {
        if (Input.GetKey(KeyCode.D))
        {
            direction = Direction.RIGHT;
        }
        else

        //Movimiento izquierda
        if (Input.GetKey(KeyCode.A))
        {
            direction = Direction.LEFT;
        }
        else

        //Movimiento arriba/salto
        if (Input.GetKey(KeyCode.W) && onGround)
        {
            direction = Direction.UP;
        }
        else

        //Movimiento abajo
        if (Input.GetKey(KeyCode.S))
        {
            direction = Direction.DOWN;
        }
        else
        {
            direction = Direction.NONE;
        }

        //Comer
        if (Input.GetKeyDown(KeyCode.Space) && !attacking)
        {
			attackDelayCounter = attackDelay;
            attacking = true;
        }
    }
	public void EndMonsterAttack(){
		monsterAttack.SetActive (false);
	}

	public void damagePlayer(int dmgTaken){
		currentHealth -= dmgTaken;
	}

	public void setMaxHealth(){
		currentHealth = maxHealth;
	}

	public void pointsGained(int ptsGained){
		Debug.Log(ptsGained);
		currentFood += ptsGained;
	}

	public void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Person") {
			//health -= 1;
			Debug.Log ("Ouch");
		}
	}
}
