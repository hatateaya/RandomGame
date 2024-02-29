using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    class Estajho
    {
        public EventApplier eventApplier;
        public Mensastatos mensastatos;
        public Estajho(EstajhoNewMode estajhoNewMode) {
            mensastatos = new Mensastatos(estajhoNewMode);
            eventApplier = new EventApplier();
        }
    }
    enum EstajhoNewMode
    {
        Player,
        Actor,
        MTF,
        Abby,
        Parent,
        Classmate,
        Dilei,
    }
}
