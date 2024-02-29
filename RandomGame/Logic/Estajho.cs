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
        public Gender gender;
        // true: female false:male
        public EventApplier eventApplier;
        public Mensastatos mensastatos;
        public Realitys realitys;
        public Estajho(EstajhoNewMode estajhoNewMode) {
            realitys = new Realitys();
            mensastatos = new Mensastatos(estajhoNewMode);
            eventApplier = new EventApplier();
            gender = Gender.Female;
            name = GenerateName(gender);
        }
        static string GenerateName(Gender gender)
        {
            string[] maleNames = {
            "Hiroto","Shota","Ren","Sora","Yuto","Yudo","Yuma","Eita","Sho" };
            string[] femaleNames = {
            "Rin","Sakura","Yua","Hina","Miu","Yui","Miyu","Misaki","Aoi" };
            switch (gender)
            {
                case Gender.Male:
                case Gender.Ftm:
                    return(Tools.RandomSelect(maleNames));
                case Gender.Female:
                case Gender.Mtf:
                    return(Tools.RandomSelect(femaleNames));
                default:
                    return "DefaultName";
            }
        }
    }
    enum Gender
    {
        Male,
        Female,
        Mtf,
        Ftm,
        Mtx,
        Ftx,
        Futa,
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
