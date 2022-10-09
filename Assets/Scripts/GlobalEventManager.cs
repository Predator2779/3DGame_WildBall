using System.Collections.Generic;
using UnityEngine;

public class GlobalEventManager : MonoBehaviour
{
    private GameManager _gameManager;

    private delegate void OnEnter();
    private OnEnter OnEnterDelegate;

    private void Start()
    {
        _gameManager = GetComponent<GameManager>();
    }

    //[SerializeField] private List<PlanetGravity> _planets = new List<PlanetGravity>();

    ///// <summary>
    ///// Start. Подписка на событие входа в зону гравитации.
    ///// </summary>
    //private void Start() => SubscribeOnListPlanet();

    /// <summary>
    /// Подписка на 
    /// </summary>
    //private void SubscribeOnListPlanet()
    //{
    //    foreach (var planet in _planets)
    //    {
    //        GetComponent<PlanetGravity>().gravityEnterDelegate += PrintPlanetInfo;
    //    }
    //}

    ///// <summary>
    ///// Вывод информации о планете.
    ///// </summary>
    ///// <param name="planetName"></param>
    //private void PrintPlanetInfo(PlanetGravity planet)
    //{
    //    print("glloba");
    //    this.GetComponent<PlanetInfo>().SelectPlanetInfo(planet);

    //    planet.GetComponent<PlanetGravity>().gravityEnterDelegate = null;
    //}
}