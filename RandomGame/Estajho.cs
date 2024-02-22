﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    class Estajho
    {
        public EventApplier eventApplier;
        public Estajho(EstajhoNewMode estajhoNewMode) {
            if (estajhoNewMode == EstajhoNewMode.RandomNormal)
            {

            }
            else if (estajhoNewMode == EstajhoNewMode.RandomYINANS)
            {

            }
            eventApplier = new EventApplier();
        }
    }
    enum EstajhoNewMode
    {
        RandomNormal,
        RandomYINANS
    }

    class EstajhoLoop
    {

        public Loop()
        {
            List<object> list = PairTool.GetList("estajho");
            foreach (object item in list) {
                ((Estajho)item).eventApplier.Try();
            }
        }
    }
}
