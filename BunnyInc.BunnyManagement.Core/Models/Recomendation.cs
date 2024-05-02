using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyInc.BunnyManagement.Core.Models
{
    public class Recomendation(RecomendationType recomendationType, string description)
    {
        public RecomendationType RecomendationType { get; } = recomendationType;
        public string Description { get; } = description;
    }

    public enum RecomendationType
    {
        TakeUmbrella,
        TakeSunglasses,
        SitHome,
        GoToShelter
    }
}
