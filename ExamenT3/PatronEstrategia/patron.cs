using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.PatronEstrategia
{
    public class patron 
    {
        private IEstrategiaPatron _estrategiaPatron;

        public patron()
        {
        }

        public patron(IEstrategiaPatron _estrategiaPatron)
        {
            this._estrategiaPatron = _estrategiaPatron;
        }
        public void SetStrategy(IEstrategiaPatron _estrategiaPatron, int IdRutina)
        {
            this._estrategiaPatron = _estrategiaPatron;
            _estrategiaPatron.EjerciciosParaRutina(IdRutina);
        }
    }
}