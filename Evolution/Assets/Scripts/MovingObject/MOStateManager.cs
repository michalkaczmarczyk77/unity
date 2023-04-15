using System;
using Unity.VisualScripting;
using UnityEngine;
using static EventManager;

public class MOStateManager : MonoBehaviour
{
    private short gender; // 0 - male; 1 - female
    private int liveTime = 0;
    private float age = 0f;

    private MOBaseState currentState;

    public bool isCollided = false;
    public ParticleSystem explosion;

    public MOFallingState      StateFailing    = new MOFallingState();
    public MOLivingState       StateLiving     = new MOLivingState();
    public MOExplodingState    StateExploding  = new MOExplodingState();
    public MODeadState         StateDead       = new MODeadState();
    public MODeadState         StateExpired    = new MOExpiredState();

    public short Gender { get => gender; }
    public int LiveTime { get => liveTime; }
    public float Age { get => age; set => age = value; }

    private void Awake()
    {
        gender = (short)Mathf.Round(UnityEngine.Random.Range(1, 3)-1);
        liveTime = (int)Mathf.Round(UnityEngine.Random.Range(20, 40));
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = StateFailing;
        currentState.EnterState(this);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(MOBaseState state)
    {
        currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
    }

    public void clone()
    {
        System.Random rnd = new System.Random();
        MOStateManager clone = Instantiate(this, new Vector2(0.2f * rnd.Next(-20, 20), 0.2f * rnd.Next(0, 20)), Quaternion.identity);
        clone.name= this.name;
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
