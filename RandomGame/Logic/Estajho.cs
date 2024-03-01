﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    class Estajho
    {
        public string id;
        public string name;
        public Gender gender;
        public EventApplier eventApplier;
        public Mensastatos mensastatos;
        public Realitys realitys;
        public Relations relations;
        public Estajho(EstajhoNewMode estajhoNewMode) {
            id = Logic.save.New("estajho", this);
            gender = GenerateGender(estajhoNewMode);
            name = GenerateName(gender);
            realitys = new Realitys();
            mensastatos = new Mensastatos(estajhoNewMode,gender, realitys);
            relations = new Relations();
            if (estajhoNewMode != EstajhoNewMode.Parent)
            {
                new Relation(RelationType.Parent, new Estajho(EstajhoNewMode.Parent).id, id);
                new Relation(RelationType.Parent, new Estajho(EstajhoNewMode.Parent).id, id);
            }
            eventApplier = new EventApplier(this);
        }
        Gender GenerateGender(EstajhoNewMode estajhoNewMode)
        {
            // Should be update with factors.
            Gender gender;
            switch (estajhoNewMode)
            {
                case EstajhoNewMode.Actor:
                    gender = (Gender)Tools.RandomSelect(Gender.Mtf, Gender.Mtx, Gender.Female, Gender.Futa);
                    break;
                case EstajhoNewMode.MTF:
                    gender = (Gender)Tools.RandomSelect(Gender.Mtx, Gender.Mtx, Gender.Futa);
                    break;
                case EstajhoNewMode.Abby:
                    gender = (Gender)Tools.RandomSelect(Gender.Mtx, Gender.Ftx, Gender.Futa);
                    break;
                case EstajhoNewMode.Dilei:
                    gender = Gender.Female;
                    break;
                case EstajhoNewMode.Random:
                case EstajhoNewMode.RandomYINANS:
                    gender = (Gender)Tools.RandomSelect(Gender.Male, Gender.Female, Gender.Mtf, Gender.Mtx, Gender.Ftm, Gender.Ftx, Gender.Futa);
                    break;
                case EstajhoNewMode.MD:
                case EstajhoNewMode.Parent:
                case EstajhoNewMode.Classmate:
                case EstajhoNewMode.RandomNormal:
                case EstajhoNewMode.Player:
                default:
                    gender = (Gender)Tools.RandomSelect(Gender.Male, Gender.Female);
                    break;
            }
            return gender;
        }
        string GenerateName(Gender gender)
        {
            string[] maleNames = {
            "Hiroto","Shota","Ren","Sora","Yuto","Yudo","Yuma","Eita","Sho" };
            string[] femaleNames = {
            "Rin","Sakura","Yua","Hina","Miu","Yui","Miyu","Misaki","Aoi" };
            switch (gender)
            {
                case Gender.Male:
                case Gender.Ftm:
                    return (Tools.RandomSelect(maleNames));
                case Gender.Female:
                case Gender.Mtf:
                    return (Tools.RandomSelect(femaleNames));
                default:
                    return (Tools.RandomSelect(femaleNames.Union<string>(maleNames).ToArray<string>()));
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
        MD,
        RandomNormal,
        RandomYINANS,
        Random,
    }
}
