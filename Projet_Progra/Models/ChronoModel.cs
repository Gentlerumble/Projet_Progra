using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Progra.Models
{
    internal class ChronoModel
    {
        public TimeSpan TempsEcoule { get; set; } = TimeSpan.Zero;
        public bool EstEnCours { get; set; } = false;
    }
}
