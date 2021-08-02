using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Controller : NetworkBehaviour
{

    [Command]
    void ServerMove(Vector2 direction)
    {
        
    }

    [ClientRpc]
    void ClientMove(Vector2 direction)
    {
        
    }
}
