using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClass
{
    public sealed class Father
    {

        public int Age { get; private set; }
        public string Name { get; private set; }
        public Position Position { get; private set; }

        public Father(int age, string name, Position position)
        {
            Age = age;
            Name = name;
            Position = position;
        }
    }

    public struct Position
    {

        public float Longitude;
        public float Dimension;

        public Position(float longitude, float dimension)
        {
            Longitude = longitude;
            Dimension = dimension;
        }
    }
}
