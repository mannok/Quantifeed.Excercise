using Microsoft.EntityFrameworkCore;
using Quantifeed.Excercise.Users.Dto;
using Quantifeed.Excercise.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Abp.Domain.Repositories;
using Quantifeed.Excercise.Business.Orders;
using RestSharp;
using Quantifeed.Excercise.Business.Orders.Dto;
using Quantifeed.Excercise.Business.Baskets;
using Quantifeed.Excercise.Business.Baskets.Dto;
using Abp.Web.Models;
using Shouldly;
using Xunit.Extensions.Ordering;

namespace Quantifeed.Excercise.Tests.Business
{
    public class OrderAppService_Test : ExcerciseTestBase
    {
        private readonly IRepository<Basket, Guid> basketRepo;
        private readonly RestClient restClient;

        public OrderAppService_Test()
        {
            basketRepo = Resolve<IRepository<Basket, Guid>>();
            restClient = new RestClient("http://127.0.0.1:8000");
        }

        [Fact, Order(1)]
        public async Task SubmitNormalBasket_Test()
        {
            var basket = new CreateBasketDto
            {
                ClientId = "xanthus",
                ChildOrders = new CreateOrderDto[] {
                    new CreateOrderDto{
                        Type =  OrderType.Market,
                        Currency = "HKD",
                        Symbol = "TSLA",
                        NotionalAmount = 10m,
                        Destination = "DestinationZ",
                        Weight = 0.25m
                    },
                    new CreateOrderDto{
                        Type =  OrderType.Limit,
                        Currency = "USD",
                        Symbol = "U",
                        NotionalAmount = 20m,
                        Destination = "DestinationY",
                        Weight = 0.75m
                    }
                }
            };

            var response = await restClient.ExecuteAsync<AjaxResponse<BasketDto>>(new RestRequest("api/services/app/Basket/Create", Method.Post).AddJsonBody(basket));

            response.IsSuccessful.ShouldBeTrue();
        }

        [Fact, Order(2)]
        public async Task OrderCurrencyMustValid_Test()
        {
            var basket = new CreateBasketDto
            {
                ClientId = "xanthus",
                ChildOrders = new CreateOrderDto[] {
                    new CreateOrderDto{
                        Type =  OrderType.Market,
                        Currency = "RMB",
                        Symbol = "TSLA",
                        NotionalAmount = 10m,
                        Destination = "DestinationZ",
                        Weight = 1m
                    }
                }
            };

            var response = await restClient.ExecuteAsync<AjaxResponse<BasketDto>>(new RestRequest("api/services/app/Basket/Create", Method.Post).AddJsonBody(basket));

            response.IsSuccessful.ShouldBeFalse();
            response.Data.Error.ValidationErrors?.Length.ShouldNotBe(0);
        }

        [Fact, Order(3)]
        public async Task BasketMustHaveChildOrders_Test()
        {
            var basket = new CreateBasketDto
            {
                ClientId = "xanthus",
                //ChildOrders = new CreateOrderDto[] { }
            };

            var response = await restClient.ExecuteAsync<AjaxResponse<BasketDto>>(new RestRequest("api/services/app/Basket/Create", Method.Post).AddJsonBody(basket));

            response.IsSuccessful.ShouldBeFalse();
            response.Data.Error.ValidationErrors?.Length.ShouldNotBe(0);
        }

        [Fact, Order(4)]
        public async Task BasketChildOrderWeightsMustEqualTo1_Test()
        {
            var basket = new CreateBasketDto
            {
                ClientId = "xanthus",
                ChildOrders = new CreateOrderDto[] {
                    new CreateOrderDto{
                        Type =  OrderType.Market,
                        Currency = "HKD",
                        Symbol = "TSLA",
                        NotionalAmount = 10m,
                        Destination = "DestinationZ",
                        Weight = 0.25m
                    },
                    new CreateOrderDto{
                        Type =  OrderType.Limit,
                        Currency = "USD",
                        Symbol = "U",
                        NotionalAmount = 20m,
                        Destination = "DestinationY",
                        Weight = 0.74m
                    }
                }
            };

            var response = await restClient.ExecuteAsync<AjaxResponse<BasketDto>>(new RestRequest("api/services/app/Basket/Create", Method.Post).AddJsonBody(basket));

            response.IsSuccessful.ShouldBeFalse();
            response.Data.Error.ValidationErrors?.Length.ShouldNotBe(0);
        }

        [Fact, Order(5)]
        public async Task ClientAOrder_Test()
        {
            var basket = new CreateBasketDto
            {
                ClientId = "A",
                ChildOrders = new CreateOrderDto[] {
                    new CreateOrderDto{
                        Type =  OrderType.Market,
                        Currency = "HKD",
                        Symbol = "TSLA",
                        NotionalAmount = 99m,   // wrong notional amount
                        Destination = "DestinationA",
                        Weight = 1m
                    }
                }
            };

            var response = await restClient.ExecuteAsync<AjaxResponse<BasketDto>>(new RestRequest("api/services/app/Basket/Create", Method.Post).AddJsonBody(basket));

            response.IsSuccessful.ShouldBeFalse();
            response.Data.Error.ValidationErrors?.Length.ShouldNotBe(0);
        }

        [Fact, Order(6)]
        public async Task ClientBOrder_Test()
        {
            var basket = new CreateBasketDto
            {
                ClientId = "B",
                ChildOrders = new CreateOrderDto[] {
                    new CreateOrderDto{
                        Type =  OrderType.Limit,
                        Currency = "USD",
                        Symbol = "TSLA",
                        NotionalAmount = 9000m,   // wrong notional amount
                        Destination = "DestinationB",
                        Weight = 0.75m
                    },
                    new CreateOrderDto{
                        Type =  OrderType.Limit,
                        Currency = "USD",
                        Symbol = "TSLA",
                        NotionalAmount = 999m,   // wrong notional amount
                        Destination = "DestinationB",
                        Weight = 0.25m
                    }
                }
            };

            var response = await restClient.ExecuteAsync<AjaxResponse<BasketDto>>(new RestRequest("api/services/app/Basket/Create", Method.Post).AddJsonBody(basket));

            response.IsSuccessful.ShouldBeFalse();
            response.Data.Error.ValidationErrors?.Length.ShouldNotBe(0);
        }
    }
}
