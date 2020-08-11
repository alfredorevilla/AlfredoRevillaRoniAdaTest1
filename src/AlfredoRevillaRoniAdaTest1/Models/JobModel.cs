using System;

namespace AlfredoRevillaRoniAdaTest1.Models
{
    public class JobModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public int Floor { get; set; }

        public string RoomTypeName { get; set; }
    }
}