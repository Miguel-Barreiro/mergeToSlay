
using MergeToStay.Services;
using UnityEngine;
using Zenject;

namespace MergeToStay
{
    public class DrawDebugAction : MonoBehaviour
    {

        [Inject]
        private CombatService _combatService;


        public void DrawDebug()
        {
            int howMany = 1;
            _combatService.CreateDrawCardEvent(howMany);
        }

    }
}

