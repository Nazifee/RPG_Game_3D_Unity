using RPG.Combat;
using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Controller
{
    public class PlayerController : MonoBehaviour
    {
        void Update()
        {
           if(InteractWithCombat() == true)
            {
                return;
            }
           if(InteractWithMoment() == true)
            {
                
                return;
            }
            
        }

        private bool InteractWithCombat()
        {
           RaycastHit[] hits= Physics.RaycastAll(GetMouseRay());
            foreach(RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null)
                {
                    continue;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target); //saldırı
                }
                return true;
            }
            return false;

        }
        private bool InteractWithMoment()
        {
       
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit == true)
            {
                if (Input.GetMouseButton(0))
                {
                   
                    GetComponent<Mover>().StartMoveAction(hit.point); //hareket ediyoruz
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }

}
