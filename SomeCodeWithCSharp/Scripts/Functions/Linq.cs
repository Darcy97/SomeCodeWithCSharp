using System.Linq;
using System;
using System.Collections.Generic;

public static class MLinq
{

    public static void TestLinq()
    {
        int[] values = new int[] { 0, 1, 3, 12, 14, 56, 34, 22, 2 };

        var result = from v in values
                     where v < 22
                     orderby v descending //descending 指定排列顺序从大到小 不加则为从小到大
                     select v;

        foreach (var item in result)
        {
            Console.Write("{0} ", item);
        }
        Console.Read();
    }

    public static void TestLinqSuper_Join()
    {

        List<Master> masterList = new List<Master>
        {
            new Master("a", 0, Type.TypeA),
            new Master("b", 1, Type.TypeB),
            new Master("c", 2, Type.TypeC),
            new Master("d", 3, Type.TypeB),
            new Master("e", 4, Type.TypeC)
        };

        List<Skill> skillList = new List<Skill>
        {
            new Skill(10, 20, Type.TypeA, "S_A"),
            new Skill(10, 20, Type.TypeB, "S_B"),
            new Skill(30, 40, Type.TypeC, "S_C"),
            new Skill(10, 20, Type.TypeB, "S_D"),
            new Skill(20, 10, Type.TypeA, "S_E"),
            new Skill(12, 18, Type.TypeC, "S_F"),
            new Skill(50, 100, Type.TypeB, "S_G")
        };

        //         var res = from m in masterList
        //                   join s in skillList on m.Type equals s.Type
        //                   select new { master = m, skill = s };
        // 
        //         Console.WriteLine(res.Count());
        //         foreach (var item in res)
        //         {
        //             Console.WriteLine("Master: " + item.master.Name);
        //             Console.WriteLine("Skill: " + item.skill.Name);
        //         }

        //没有任何意义 仅测试用法
        var anoRes = from m in masterList
                     join s in skillList on m.Type equals s.Type
                     where m.ID > 2
                     orderby s.Demage
                     select new { master = m, skill = s }; //匿名类型  如下foreach 配合 var 使用 

        Console.WriteLine("++++++++++++" + anoRes.Count());
        foreach (var item in anoRes)
        {           
            Console.WriteLine("Master: " + item.master.Name + " ID: " + item.master.ID);
            Console.WriteLine("Skill: " + item.skill.Name + " Demage: " + item.skill.Demage);
        }
        Console.Read();

    }

    public class Master
    {
        
        public Type Type { get; private set; }
        public string Name { get; private set; }
        public int ID { get; private set; }

        public Master(string name, int id, Type type)
        {
            Name = name;
            ID = id;
            Type = type;
        }
    }

    public struct Skill
    {

        public Type Type { get; private set; }  
        public int Demage { get; private set; }
        public int Cause { get; private set; }
        public string Name { get; private set; }    

        public Skill(int demage, int cause, Type type, string name) : this()
        {
            Demage = demage;
            Cause = cause;
            Type = type;
            Name = name;
        }
    }

    public enum Type
    {
        TypeA, 
        TypeB,
        TypeC
    }
}