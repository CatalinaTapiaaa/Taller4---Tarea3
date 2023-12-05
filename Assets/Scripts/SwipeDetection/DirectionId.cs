using UnityEngine;

namespace GG.Infrastructure.Utils.Swipe
{
    public class DirectionId
    {
        public const string ID_UP = "Arriba";
        public const string ID_DOWN = "Abajo";
        public const string ID_LEFT = "Izquierda";
        public const string ID_RIGHT = "Derecha";
        public const string ID_UP_LEFT = "Arriba Izquierda";
        public const string ID_UP_RIGHT = "Arriba Derecha";
        public const string ID_DOWN_LEFT = "Abajo Izquierda";
        public const string ID_DOWN_RIGHT = "Abajo Derecha";

        public readonly string Id;
        public readonly Vector3 Direction;

        public DirectionId(string id, Vector3 direction)
        {
            Id = id;
            Direction = direction;
        }
    }
}
