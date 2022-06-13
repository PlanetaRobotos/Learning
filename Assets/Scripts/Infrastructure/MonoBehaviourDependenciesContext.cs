using System;
using UnityEngine;

namespace Infrastructure
{
    public class MonoBehaviourDependenciesContext : MonoBehaviour
    {
        [SerializeField] private Balls balls = default;

        private void Awake()
        {
            DependenciesContext.Dependencies.Add(new Dependency
            {
                Type = typeof(Balls),
                Factory = () => Instantiate(balls).GetComponent<Balls>(),
                IsSingleton = true
            });
        }
    }
}