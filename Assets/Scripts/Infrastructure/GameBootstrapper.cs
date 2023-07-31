using Activity;
using Infrastructure.States;
using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] LoadingCurtain curtain;
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, curtain);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}