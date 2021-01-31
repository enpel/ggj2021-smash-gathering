using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gather.Scripts.Player;

public class PlayerInstanceManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;

    private List<Player> _players = new List<Player>();
    // Start is called before the first frame update
    void Start()
    {
        GeneratePlayer(0);
        GeneratePlayer(1);
        GeneratePlayer(2);
        GeneratePlayer(3);
    }

    void GeneratePlayer(int playerId)
    {
        var instance = GameObject.Instantiate(_playerPrefab) as GameObject;
        instance.transform.position = new Vector3(playerId, 1, 0);
        var player = instance.GetComponent<Player>();
       // player.Initialize(playerId);
        _players.Add(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
