﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace SomeCodeWithCSharp.Scripts.Pair
{
    public class Pair
    {

        public static Pair Instance = new Pair();

        private readonly double malePecent = 0.5;

        private readonly int charactorSimilarityDegree = 2;
        private readonly int heightSimilarityDegree = 2;

        private Random random;

        private List<Human> humans;

        public void Start()
        {
            random = new Random((int)DateTime.Now.Ticks);

            humans = new List<Human>();
            GenerateHumans(100);
            var HumanGroups = GroupHumans(humans);
            if (HumanGroups.Count() != 2)
            {
                Console.WriteLine("Error");
                Console.Read();
                return;
            }
 
            PairHumans(HumanGroups[0].ToList(), HumanGroups[1].ToList());
            Console.Read();
        }


        private void GenerateHumans(int num)
        {
            humans.Clear();            
            for (int i = 0; i < num; i++)
            {
                int id = i;
                string name = string.Format("Human_{0}", i);
                
                int age = random.Next(0, 80);

                double genderDouble = random.NextDouble();
                Gender gender = genderDouble < malePecent ? Gender.Male : Gender.Female;

                Charactor charactor = (Charactor)random.Next(5);
                int faceScore = random.Next(101);

                Height height = (Height)random.Next(4);

                Human newHuman = new Human(id, name, age, gender, charactor, faceScore);
                newHuman.ChangeHeight(height);
                humans.Add(newHuman);
            }
        }

        private void PairHumans(List<Human> males, List<Human> females)
        {
            var pairs = from m in males
                        join f in females on m.Age equals f.Age
                        where Math.Abs(m.MCharactor - f.MCharactor) < 2 && Math.Abs(m.MHeight - f.MHeight) < 2
                        orderby m.Age
                        select new { male = m, female = f }; //匿名类型  如下foreach 配合 var 使用 
            Console.WriteLine(pairs.Count());
            foreach (var item in pairs)
            {
                Console.WriteLine("Charactor" + item.male.MCharactor.ToString() + item.female.MCharactor.ToString());
                Console.WriteLine("Height:" + item.male.MHeight.ToString() + item.female.MHeight.ToString());
            }   
        }


        private List<IGrouping<Gender, Human>> GroupHumans(List<Human> humans)
        {
            var humanGroups =
                from human in humans
                group human by human.MGender
                into humanGroup
                orderby humanGroup.Key
                select humanGroup;


            humanGroups.Count();

            return humanGroups.ToList();
        }
    }
}