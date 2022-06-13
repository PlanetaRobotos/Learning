using UnityEngine;

namespace Infrastructure
{
    public class Walls : MonoBehaviour
    {
        private MonoBehaviourDependenciesContext dependency;

        private void Awake()
        {
            dependency = DependenciesContext.Dependencies.Get<MonoBehaviourDependenciesContext>();
        }
    }
}