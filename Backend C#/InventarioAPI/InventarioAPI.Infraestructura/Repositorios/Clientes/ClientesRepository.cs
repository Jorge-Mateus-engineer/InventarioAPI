﻿using InventarioAPI.Infraestructura.Database.Contextos;
using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Infraestructura.Repositorios.Clientes
{
    public class ClientesRepository : IClienteRepository
    {

        private readonly InventarioContext _context;

        public ClientesRepository(InventarioContext context)
        {
            _context = context;
        }

        public void Delete(ClienteEntity entity)
        {
            _context.Clientes.Remove(entity);
            _context.SaveChanges();
        }

        public List<ClienteEntity> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public ClienteEntity GetByEmail(string email)
        {
            return _context.Clientes.SingleOrDefault(c => c.correo == email);
        }

        public ClienteEntity GetById(int id)
        {
            return _context.Clientes.Find(id);
        }

        public ClienteEntity Insert(ClienteEntity entity)
        {
            _context.Clientes.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public ClienteEntity Update(ClienteEntity entity)
        {
            _context.Clientes.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
