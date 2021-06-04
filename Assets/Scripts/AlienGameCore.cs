using Assets.Scripts.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    class AlienGameCore : IInitializable, IDisposable
    {
        [Inject]
        private Player _player;
        /*[Inject]
        private IEnemy _alien;*/

        [Inject]
        private ICoroutineService _coroutineService;

        [Inject]
        private Alien.Factory _alienFactory;


        private List<Alien> _aliens;
        private Coroutine _spawnAlienCoroutine;

        public void Initialize()
        {
            Debug.Log("GameCore Initialize!");
            _aliens = new List<Alien>();
            _spawnAlienCoroutine = _coroutineService.RunCoroutine(EnemySpawnCoroutine(5f));
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _player.ShootAt(GetRandomEnemy());
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _player.PreviousWeapon();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _player.NextWeapon();
            }
        }

        private IEnumerator EnemySpawnCoroutine(float delay)
        {
            while (true)
            {
                Debug.Log("New enemy was created!");
                Alien newAlien = _alienFactory.Create();
                _aliens.Add(newAlien);
                yield return new WaitForSeconds(delay);
            }
        }

        private IEnemy GetRandomEnemy()
        {
            int enemyIndex = UnityEngine.Random.Range(0, _aliens.Count);
            return _aliens[enemyIndex];
        }
        public void Dispose()
        {
            Debug.Log("GameCore disposed!");
            if(_coroutineService != null)
            {
                _coroutineService.EndCoroutine(_spawnAlienCoroutine);
            }
        }

    }
}