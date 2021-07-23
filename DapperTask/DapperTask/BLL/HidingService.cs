using DapperTask.Core;
using DapperTask.Entities;
using EFlecture.Core.Specifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DapperTask.BLL
{
    public class HidingService : IHidingService
    {
        private readonly IRepository<Users> userRepository;
        private readonly IRepository<Merchants> merchantRepository;
        private readonly IRepository<Orders> orderRepository;

        public HidingService(IRepository<Users> userRepository, IRepository<Merchants> merchantRepository, IRepository<Orders> orderRepository)
        {
            this.userRepository = userRepository;
            this.merchantRepository = merchantRepository;
            this.orderRepository = orderRepository;
        }

        public void GetByEmail(string email)
        {

            var user = userRepository.Get(x => x.Email, email).FirstOrDefault();

            if (user != null)
            {
                user.FullName = Encode(user.FullName);
                user.Gender = Encode(user.Gender);
                user.Email = Encode(user.Email);
                userRepository.Update(user);
            }
          

            var merchant = merchantRepository.Get(i => i.UserId, user.Id).FirstOrDefault();

            if (merchant != null)
            {
                merchant.User.FullName = Encode(merchant.User.FullName);
                merchant.User.Gender = Encode(merchant.User.Gender);
                merchant.User.Email = Encode(merchant.User.Email);
                merchantRepository.Update(merchant);
            }

            var order = orderRepository.Get(i => i.UserId, user.Id).FirstOrDefault();

            if (order != null)
            {
                order.User.FullName = Encode(order.User.FullName);
                order.User.Gender = Encode(order.User.Gender);
                order.User.Email = Encode(order.User.Email);

                dynamic orderJson = JsonConvert.DeserializeObject(order.OrderJson);
                orderJson.User.FullName = Encode(orderJson.User.FullName);
                orderJson.User.Gender = Encode(orderJson.User.Gender);
                orderJson.User.Email = Encode(orderJson.User.Email);

                if (merchant != null)
                {
                    foreach (var item in orderJson.Order.Products)
                    {
                        item.Merchant.Name = Encode(item.Merchant.Name);
                    }
                }

                order.OrderJson = JsonConvert.SerializeObject(orderJson);

                orderRepository.Update(order);
            }
        }
        private string Encode(string decoded)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(decoded));
        }
    }
}
