using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    class Estajho
    {
        public string name;
        public bool gender;
        // true: female false:male
        public EventApplier eventApplier;
        public Mensastatos mensastatos;
        public Realitys realitys;
        public Estajho(EstajhoNewMode estajhoNewMode) {
            realitys = new Realitys();
            mensastatos = new Mensastatos(estajhoNewMode);
            eventApplier = new EventApplier();
            gender = true;
            name = GenerateName(gender);
        }
        static string GenerateName(bool gender)
        {
            string[] maleNames = {
            "Hiroto","Shota","Ren","Sora","Yuto","Yudo","Yuma","Eita","Sho" };
            string[] femaleNames = {
            "Rin","Sakura","Yua","Hina","Miu","Yui","Miyu","Misaki","Aoi" };
            switch (gender)
            {
                case false:
                    return(Tools.RandomSelect(maleNames));
                case true:
                    return(Tools.RandomSelect(femaleNames));
            }
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
