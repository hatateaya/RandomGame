﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui.Trees;

namespace RandomGame
{
    class Estajho : TreeNode
    {
        public string id;
        public string name;
        public Gender gender;
        // true: female false:male
        public EventApplier eventApplier;
        public Mensastatos mensastatos;
        public Realitys realitys;
        public Relations relations;
        public Estajho(EstajhoNewMode estajhoNewMode) {
            realitys = new Realitys();
            mensastatos = new Mensastatos(estajhoNewMode);
            eventApplier = new EventApplier();

            gender = Gender.Female;
            name = GenerateName(gender);
            relations = new Relations();
            id = Program.save.New("estajho", this);
        }
        Gender GenerateGender(EstajhoNewMode estajhoNewMode)
        {
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
        public override IList<ITreeNode> Children => relations.GetAnothers(id).Cast<ITreeNode>().ToList();
        public override string Text { get => name; set => name = value; }
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
