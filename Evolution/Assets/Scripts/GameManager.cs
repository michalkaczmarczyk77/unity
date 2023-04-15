using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager gameInstance;
    public static int livingObjects = 0;
    public static int spawnedObjects = 0;

    public static int matrixLength = 8;
    public static int[] coreMatrix;  // species matrix. It does not change over the time

    /*
        public GameState gameState;
        public static event Action<GameState> OnGameStateChange;
        public static event Action<GameState> OnGameStart;
        public static event Action<GameState> OnGamePause;
        public static event Action<GameState> OnObjectSpawn;
        public static event Action<GameState> OnObjectBorn;
    */

    public Dictionary<string, UnityEvent> eventDictionary;
    private UnityAction onMoSpawn, onMoExpire, onMoBorn, onMoDead;

        private void Awake()
    {
        //gameInstance = this;
        onMoDead    = new UnityAction(OnMoDead);
        onMoSpawn   = new UnityAction(OnMoSpawn);
        onMoExpire  = new UnityAction(OnMoExpire);
        onMoBorn    = new UnityAction(OnMoBorn);

        //GameManager.StartListening("MO:DEAD"    , onMoDead);
        //GameManager.StartListening("MO:SPAWNED" , onMoSpawn);
        //GameManager.StartListening("MO:EXPIRED" , onMoExpire);
        //GameManager.StartListening("MO:BORN"    , onMoBorn);
/*
        if (coreMatrix == null)
        {
            coreMatrix = generateCoreMatrix(matrixLength);
            Debug.Log("Core Matrix Created" + coreMatrix);
        }
*/
    }

    public int[] generateCoreMatrix(int matrixLength)
    {
        int[] _coreMatrix = new int[matrixLength];

        for (var i = 0; i < matrixLength; i++)
        {
            _coreMatrix[i] = UnityEngine.Random.Range(0, 2);
        }

        return _coreMatrix;
    }

    public static GameManager instance
    {
        get
        {
            if (!gameInstance)
            {
                gameInstance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (!gameInstance)
                {
                    Debug.LogError("There needs to be one active GameManager script on a GameObject in your scene.");
                }
                else
                {
                    gameInstance.Init();
                }
            }

            return gameInstance;
        }
    }

    private void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }


    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if (gameInstance == null) return;
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }
    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }

    private void OnMoSpawn()
    {
        spawnedObjects++;
        printNumbers();
    }
    private void OnMoExpire()
    {
        spawnedObjects--;
        printNumbers();
    }

    private void OnMoBorn()
    {
        spawnedObjects--;
        livingObjects++;
        printNumbers();
    }

    private void OnMoDead()
    {
        livingObjects--;
        printNumbers();
    }

/*
    public void UpdateGameStage(GameState newState)
    {
        gameState = newState;

        switch (newState)
        {
            case GameState.SpawnedObjects:
                HandleOnObjectSpawn(newState);
                break;
            case GameState.GameStart:
                HandleGameStart();
                break;
            case GameState.GamePause:
                HandleGamePaused();
                break;
            case GameState.GameEnd:
                HandleGameEnd();
                break;
            case GameState.LivingObjects:
                HandleObjectBorn();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState),newState,null);
        }

        //OnGameStateChange(newState);
        OnGameStateChange?.Invoke(newState);

    }
*/
    private static void printNumbers()
    {
        Debug.Log("---> Spawned: "+spawnedObjects+" # Living: "+livingObjects);
    }
}
