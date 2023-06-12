using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public interface IUpdatableProjectile
    {
        void Update(Vector2 offset, List<Unit> units);
    }
}