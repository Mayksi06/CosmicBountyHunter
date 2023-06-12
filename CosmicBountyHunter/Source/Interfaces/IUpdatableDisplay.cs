using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicHunter
{
    public interface IUpdatableDisplay
    {
        void Update(float current, float max);
    }
}