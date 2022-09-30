using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Validation;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quantifeed.Excercise.Business.Baskets.Dto;
using Quantifeed.Excercise.Business.Orders;
using Quantifeed.Excercise.Business.Orders.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantifeed.Excercise.Business.Baskets
{
    public class BasketAppService : AsyncCrudAppService<Basket, BasketDto, Guid, PagedAndSortedResultRequestDto, CreateBasketDto>, IBasketAppService
    {
        public BasketAppService(IRepository<Basket, Guid> repository) : base(repository)
        {
        }

        //private readonly IMapper mapper;
        //private readonly IRepository<Order, Guid> orderRepo;

        //public OrderAppService(IMapper mapper, IRepository<Order, Guid> orderRepo) : base(orderRepo)
        //{
        //    this.mapper = mapper;
        //    this.orderRepo = orderRepo;
        //}

        ////public override async Task<OrderDto> CreateAsync(CreateOrderDto input)
        ////{
        ////    //if (orderRepo.GetAll().FirstOrDefault(x => x.Id == input.Id) != null)
        ////    //    throw new AbpValidationException(null, new ValidationResult[] {
        ////    //        new ValidationResult("OrderId has already existed")
        ////    //    });

        ////    return await base.CreateAsync(input);
        ////}
    }
}
