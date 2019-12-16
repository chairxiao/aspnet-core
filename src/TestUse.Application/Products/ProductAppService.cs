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
using Abp.Application.Services;
using TestUse.Products.Dto;

namespace TestUse.Products
{
    public class ProductAppService : AsyncCrudAppService<Product, ProductDto, long, PagedProductResultRequestDto>
    {
        private readonly Manager _roleManager;
        private readonly UserManager _userManager;

        public ProductAppService(
            IRepository<Product,long> productRepository,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            UserManager userManager):base(productRepository)
        {
            _roleManager = ProductManager;
            _productRepository = productRepository;
            _organizationUnitRepository = organizationUnitRepository;
            _userManager = userManager;
        }

        public List<Product> GetProductsInOu(long organizationUnitId)
        {
            return _productRepository.GetAllList(p => p.OrganizationUnitId == organizationUnitId);
        }

        [UnitOfWork]
        public virtual List<Product> GetProductsInOuIncludingChildren(long organizationUnitId)
        {
            var code = _organizationUnitRepository.Get(organizationUnitId).Code;

            var query =
                from product in _productRepository.GetAll()
                join organizationUnit in _organizationUnitRepository.GetAll() on product.OrganizationUnitId equals organizationUnit.Id
                where organizationUnit.Code.StartsWith(code)
                select product;

            return query.ToList();
        }

        public async Task<List<Product>> GetProductsForUserAsync(long userId)
        {
            var user = await _userManager.GetUserByIdAsync(userId);
            var organizationUnits = await _userManager.GetOrganizationUnitsAsync(user);
            var organizationUnitIds = organizationUnits.Select(ou => ou.Id);

            return await _productRepository.GetAllListAsync(p => organizationUnitIds.Contains(p.OrganizationUnitId));
        }

        [UnitOfWork]
        public virtual async Task<List<Product>> GetProductsForUserIncludingChildOusAsync(long userId)
        {
            var user = await _userManager.GetUserByIdAsync(userId);
            var organizationUnits = await _userManager.GetOrganizationUnitsAsync(user);
            var organizationUnitCodes = organizationUnits.Select(ou => ou.Code);

            var query =
                from product in _productRepository.GetAll()
                join organizationUnit in _organizationUnitRepository.GetAll() on product.OrganizationUnitId equals organizationUnit.Id
                where organizationUnitCodes.Any(code => organizationUnit.Code.StartsWith(code))
                select product;

            return query.ToList();
        }
    }
}
