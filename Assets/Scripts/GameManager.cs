using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance)
            Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    public int health;
    public PlayerArea playerArea;
    public EnemyController enemy;

    //Followers
    public int basicFollowers;

    //Devout is a wild card follower type
    public int devoutFollowers;

    public void EndTurn()
    {
        playerArea.CallActions();
    }
}
