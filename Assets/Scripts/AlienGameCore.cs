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

        [Inject]
        private ICoroutineService _coroutineService;

        [Inject]
        private Alien.Factory _alienFactory;


        private List<IEnemy> _aliens;
        private IEnemy _alien;
        private Coroutine _spawnAlienCoroutine;

        public void Initialize()
        {
            Debug.Log("GameCore Initialize!");
            _aliens = new List<IEnemy>();
            _spawnAlienCoroutine = _coroutineService.RunCoroutine(EnemySpawnCoroutine(5f));
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SetTarget();
                _player.ShootAt(_alien);
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

        private void SetTarget()
        {
            if (_alien == null)
            {
                _alien = GetRandomEnemy();
                return;
            }
            else if (_alien.Alive)
            {
                return;
            }
            else
            {
                _alien = GetRandomEnemy();
            }
        }


        private IEnemy GetRandomEnemy()
        {
            if(_aliens.Count <= 0)
            {
                return null;
            }
            int enemyIndex = UnityEngine.Random.Range(0, _aliens.Count);
            IEnemy enemy = _aliens[enemyIndex];
            _aliens.Remove(enemy);
            return enemy;
        }
        private IEnumerator EnemySpawnCoroutine(float delay)
        {
            while (true)
            {
                IEnemy newAlien = _alienFactory.Create();
                _aliens.Add(newAlien);
                Debug.Log($"New enemy was created! Enemy count: {_aliens.Count}");
                yield return new WaitForSeconds(delay);
            }
        }
        public void Dispose()
        {
            Debug.Log("GameCore disposed!");
            if(_coroutineService != null && _spawnAlienCoroutine != null)
            {
                _coroutineService.EndCoroutine(_spawnAlienCoroutine);
            }
        }

    }
}