using System;
using System.ComponentModel.DataAnnotations;

namespace AlfredoRevillaRoniAdaTest1.Repositories
{
    public class JobRepositoryModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public int Floor { get; set; }

        public Guid RoomTypeId { get; set; }
    }
}