﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    class Mensasato
    {
        MensastatoType type;
        int value;
        public Mensasato(MensastatoType mensasatoType)
        {
            this.type = mensasatoType;
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
