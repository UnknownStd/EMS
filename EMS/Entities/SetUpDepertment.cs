using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace EMS.Entities
{
    public class SetUpDepertment:BaseEntity
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
		[Required] public string DepartmentName { get; set; } = string.Empty;
        public int? DisplayNo { get; set; }
    }
}
