using UnityEngine;

namespace Gather.Scripts.Character
{

    public interface ICharacter
    {
        public void Move(Vector3 dir);
        public void Attack();
        public void Grab();
        public void Throw();
    }

}