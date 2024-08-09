using UnityEngine;

namespace mBuilding.Scripts.Services
{
    public class SomeCommonService
    {
        // Например провайдер состояния, или провайдер настроек, сервис аналитики, платежки - чего угодно
        public SomeCommonService()
        {
            Debug.Log(GetType().Name + " has been created");
        }
    }
}