using System;

namespace AlfredoRevillaRoniAdaTest1.Services
{
    public class JobServiceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public int Floor { get; set; }

        public Guid RoomTypeId { get; set; }
    }
}