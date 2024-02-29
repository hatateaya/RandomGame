using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    class Mensastatos
    {
        public List<Mensastato> list;
        public Mensastatos(EstajhoNewMode newMode)
        {
            Dictionary<MensastatoType, double> generateFactors = new Dictionary<MensastatoType, double>();

            switch (newMode)
            {
                case EstajhoNewMode.Player:
                    break;
                case EstajhoNewMode.Actor:
                    break;
                case EstajhoNewMode.MTF:
                    break;
                case EstajhoNewMode.Abby:
                    break;
                case EstajhoNewMode.Parent:
                    break;
                case EstajhoNewMode.Classmate:
                    break;
                case EstajhoNewMode.Dilei:
                    break;
                default:
                    break;
            };

            foreach(MensastatoType key in generateFactors.Keys)
            {
                var random = new Random(Program.save.seed);
                if (random.NextDouble() <= generateFactors[key])
                {
                    list.Add(new Mensastato(key));
                }
            }
        }
    }
    class Mensastato
    {
        MensastatoType Type;
        double Value;
        public Mensastato(MensastatoType mensasatoType)
        {
            this.Type = mensasatoType;
            this.Value = new Random(Program.save.seed).NextDouble();
        }
    }
    enum MensastatoType
    {
        Overdose,
        NSSI,
        GD,
        Abby,
        Trans,
        ASD,
        ADHD,
        Anorexia,
        Bipolar,
        BPD,
        Delirium,
        Depression,
        Depersonalization,
        Amnesia,
        Hypochondriasis,
        DID,
        Insomnia,
        OCD,
        PTSD,
        S,
        M,
        CD,
    }
    // maybe ICD-11?
}
