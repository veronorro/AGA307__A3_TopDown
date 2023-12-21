using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    protected static GameManager _GM            { get { return GameManager.INSTANCE; } }
    protected static PlayerMovement _PM         { get { return PlayerMovement.INSTANCE; } }
    protected static UITitle _UIT               { get { return UITitle.INSTANCE; } }
}
