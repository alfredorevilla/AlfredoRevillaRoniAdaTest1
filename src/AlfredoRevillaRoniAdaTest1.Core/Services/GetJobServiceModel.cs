using System.ComponentModel.DataAnnotations;

namespace AlfredoRevillaRoniAdaTest1.Services
{
    public class GetJobServiceModel
    {
        [Range(1, 50)]
        public int PageSize { get; set; }
    }
}