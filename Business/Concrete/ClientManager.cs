﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ClientManager:IClientService
    {
        IClientDal _clientDal;
        public ClientManager(IClientDal clientDal)
        {
            _clientDal = clientDal;
        }
        public List<Client> GetAll()
        {
            return _clientDal.GetAll();
        }

        public Client GetById(int id)
        {
            return _clientDal.Get(x => x.ClientID == id);
        }

        public void TAdd(Client t)
        {
            _clientDal.Insert(t);
        }

        public void TDelete(Client t)
        {
            _clientDal.Delete(t);
        }

        public void TUpdate(Client t)
        {
            _clientDal.Update(t);
        }
    }
}