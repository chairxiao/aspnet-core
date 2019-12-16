using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Organizations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestUse.Products.Dto
{
    public class ProductDto : EntityDto<long>, IMustHaveTenant, IMustHaveOrganizationUnit
    {
        public virtual int TenantId { get; set; }

        public virtual long OrganizationUnitId { get; set; }

        public virtual string Name { get; set; }

        public virtual float Price { get; set; }
    }
}

