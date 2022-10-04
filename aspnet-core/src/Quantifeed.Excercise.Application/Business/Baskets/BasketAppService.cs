using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Runtime.Validation;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quantifeed.Excercise.Business.Baskets.Dto;
using Quantifeed.Excercise.Business.Orders;
using Quantifeed.Excercise.Business.Orders.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Quantifeed.Excercise.Business.Baskets
{
    public class BasketAppService : AsyncCrudAppService<Basket, BasketDto, Guid, PagedAndSortedResultRequestDto, CreateBasketDto>, IBasketAppService
    {
        public BasketAppService(IRepository<Basket, Guid> repository) : base(repository)
        {
        }

        private readonly IMapper mapper;
        private readonly IRepository<Basket, Guid> basketRepo;

        public BasketAppService(IMapper mapper, IRepository<Basket, Guid> basketRepo) : base(basketRepo)
        {
            this.mapper = mapper;
            this.basketRepo = basketRepo;
        }

        ////public override async Task<OrderDto> CreateAsync(CreateOrderDto input)
        ////{
        ////    //if (orderRepo.GetAll().FirstOrDefault(x => x.Id == input.Id) != null)
        ////    //    throw new AbpValidationException(null, new ValidationResult[] {
        ////    //        new ValidationResult("OrderId has already existed")
        ////    //    });

        ////    return await base.CreateAsync(input);
        ////}
        ///

        public override async Task<PagedResultDto<BasketDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var basketCount = await basketRepo.CountAsync();
            var basketDtos = await mapper.ProjectTo<BasketDto>(
                basketRepo.GetAllIncluding(x => x.ChildOrders).OrderBy(string.IsNullOrEmpty(input.Sorting) ? "1" : input.Sorting).Skip(input.SkipCount).Take(input.MaxResultCount)
            ).ToArrayAsync();

            return new PagedResultDto<BasketDto>(basketCount, Array.AsReadOnly(basketDtos));
        }
    }
}
