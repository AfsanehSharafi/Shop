﻿using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Catalogs
{
    //[Auditable]
    public class CatalogType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public int? ParetCatalogTypeId { get; set; }
        public CatalogType? ParentCatalogType { get; set; }

        public ICollection<CatalogType> SubType { get; set; }
    }
}
