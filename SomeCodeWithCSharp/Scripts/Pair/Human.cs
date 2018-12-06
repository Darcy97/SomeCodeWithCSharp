using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomeCodeWithCSharp.Scripts.Pair
{
    public class Human
    {
        public Human(int iD,
            string name, 
            int age, Gender mGender,
            Charactor mCharactor, 
            int faceScore,
            Height mHeight,
            Weight mWeight)
        {
            ID = iD;
            Name = name;
            Age = age;
            MGender = mGender;
            MCharactor = mCharactor;
            MHeight = mHeight;
            MWeight = mWeight;
            ChangeFaceScore(faceScore);
        }

        public Human(int iD, string name, int age, Gender mGender, Charactor mCharactor, int faceScore)
        {
            ID = iD;
            Name = name;
            Age = age;
            MGender = mGender;
            MCharactor = mCharactor;
            ChangeFaceScore(faceScore);
        }



        #region Prop
        public int ID { get; private set; } 
        public String Name { get; private set; }
        public int Age { get; private set; }
        public Gender MGender { get; private set; }  
        public Human Lover { get; private set; }
        public Charactor MCharactor { get; private set; }
        public int FaceScore { get; private set; }
        public Height MHeight { get; private set; }
        public Weight MWeight { get; private set; }

        public bool IsSingle
        {
            get
            {
                return Lover == null;
            }
        }

        #endregion


        #region HumanChangeMethod
        public void ChangeFaceScore(int value)
        {

            if (value > 100)
                FaceScore = 100;
            if (value < 0)
                FaceScore = 0;
        }

        public void ChangeCharactor(Charactor to)
        {
            MCharactor = to;
        }

        public void ChangeGender()
        {
            MGender = (Gender)(-(int)(MGender) + 1);
        }

        public void ChangeHeight(Height to)
        {
            MHeight = to;
        }

        public void ChangeWeight(Weight to)
        {
            MWeight = to;
        }

        public void GetLover(Human lover)
        {
            Lover = lover;
        }

        #endregion

    }

    public enum Gender
    {
        Male,
        Female
    }

    /// <summary>
    /// 临近性格相似度高
    /// </summary>
    public enum Charactor
    {
        A,
        B,
        C,
        D,
        E
    }

    public enum Height
    {
        A,
        B,
        C,
        D
    }

    public enum Weight
    {
        A,
        B,
        C,
        D,
        E
    }

}
