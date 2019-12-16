using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Abp.Organizations;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestUse.Authorization.Users;


namespace TestUse.Products
{

        public class ProductManager : IDomainService
        {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;
        private readonly UserManager _userManager;

        public ProductManager(
            IRepository<Product> productRepository,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            UserManager userManager)
        {
            _productRepository = productRepository;
            _organizationUnitRepository = organizationUnitRepository;
            _userManager = userManager;
        }
    }
}
