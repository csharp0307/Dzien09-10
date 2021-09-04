using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationExample
{
    public class City
    {
        int id;
        String name;

        public City(int id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id { get { return id; }  }
        public string Name { get { return name; } }
    }
}