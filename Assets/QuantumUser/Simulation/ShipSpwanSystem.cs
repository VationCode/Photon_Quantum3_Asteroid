using UnityEngine.Scripting;

namespace Quantum.Asteroids
{
    [Preserve]
    public unsafe class ShipSpawnSystem : SystemSignalsOnly, ISignalOnPlayerAdded // ISignalOnPlayerAdded : 플레이어가 추가됬다는 신호를 확인하면 밑의 내용을 실행
    {
        public void OnPlayerAdded(Frame frame, PlayerRef player, bool firstTime)
        {
            {
                RuntimePlayer data = frame.GetPlayerData(player);

                // resolve the reference to the avatar prototype.
                var entityPrototypAsset = frame.FindAsset<EntityPrototype>(data.PlayerAvatar);

                // Create a new entity for the player based on the prototype.
                var shipEntity = frame.Create(entityPrototypAsset);

                // Create a PlayerLink component. Initialize it with the player. Add the component to the player entity.
                frame.Add(shipEntity, new PlayerLink { PlayerRef = player });
            }
        }
    }
}