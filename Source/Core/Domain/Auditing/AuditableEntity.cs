﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Core.Domain.Auditing
{
    [Table("AuditableEntity", Schema = "dbo")]
    public class AuditableEntity : BaseEntity
    {
        [Key]
        public int AuditableEntityId { get; set; }
        public string EntityName { get; set; }
        public bool EnableAudit { get; set; }

        public virtual ICollection<AuditableAttribute> AuditableAttributes { get; set; }
    }
}
