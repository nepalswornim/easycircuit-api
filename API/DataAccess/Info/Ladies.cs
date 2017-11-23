using System;
using System.Collections.Generic;
namespace API.DataAccess.Info
{
    public class Ladies
    {
        public int Id { get; set; }
        public string Image { get; set; } = "";
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
    }
}