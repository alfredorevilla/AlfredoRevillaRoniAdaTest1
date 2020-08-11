using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey(nameof(RoomTypeId))]
        public RoomTypeRepositoryModel RoomType { get; set; }
    }
}