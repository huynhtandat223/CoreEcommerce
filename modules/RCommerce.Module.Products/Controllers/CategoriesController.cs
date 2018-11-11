using RCommerce.Module.Products.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RCommerce.Module.Core.Controllers;
using Infrastructures.RepositoryEntities.Data;
using RCommerce.Module.Core.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace RCommerce.Module.Products.Controllers
{
    [Authorize]
    public class CategoriesController : GenericController<Category>
    {
        private readonly IMapper _mapper;
        public CategoriesController(IRepository<Category> repo, IMapper mapper) : base(repo)
        {
            _mapper = mapper;
        }

        public IActionResult Grouped()
        {
            var categoriesDb = _repo.Query().ToList();
            var allCategories = _mapper.Map<List<CategoryDto>>(categoriesDb);

            var categoriesRoots = allCategories
                .Where(i => i.ParentId == 0)
                .ToList();
            foreach (var categoryRoot in categoriesRoots)
            {
                categoryRoot.Children = allCategories.Where(i => i.ParentId == categoryRoot.Id).ToList();
                foreach (var child2 in categoryRoot.Children)
                {
                    child2.Children = allCategories.Where(i => i.ParentId == child2.Id).ToList();
                }
            }

            return Ok(new CategoryWrapperDto {
                Grouped = categoriesRoots,
                UnGrouped = allCategories
            });
        }
    }
}
