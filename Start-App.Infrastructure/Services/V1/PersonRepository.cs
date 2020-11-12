/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Start_App.Domain.Context;
using Start_App.Domain.Entities;
using Start_App.Domain.Interface;
using Start_App.Helper;

namespace Start_App.Application.Services.V1.Repository
{
    public class PersonRepository : IService<Person>
    {
        private readonly AdventureWorks2017Context _context;
        private readonly ILogger<PersonRepository> _logger;

        public PersonRepository(AdventureWorks2017Context context,
            ILogger<PersonRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


        public Person Add(Person entityToAdd)
        {
            _logger.LogInformation($"Person request parameters: {JsonSerializer.Serialize(entityToAdd)}");
            var entity = _context.People.Add(entityToAdd);
            int count = _context.SaveChanges();
            _logger.LogInformation($"{count} person created");
            return entity.Entity;
            
        }

        public async Task<Person> AddAsync(Person entityToAdd)
        {
            _logger.LogInformation($"Person request parameters: {JsonSerializer.Serialize(entityToAdd)}");
            var entity = await _context.People.AddAsync(entityToAdd);
            int count = await _context.SaveChangesAsync();
            _logger.LogInformation($"{count} employee created ");
            return entity.Entity;
        }

        public bool Delete(int id)
        {
            var people = _context.People.Find(id);
            if (people is null)
            {
                return false;
            }
            _context.People.Remove(people);
            var count = _context.SaveChanges();
            _logger.LogInformation($"{count} person deleted ");
            return true;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Person Details(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> DetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Person>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public PagedList<Person> GetPagedAll(IPagedRequestBase request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<Person>> GetPagedAllAsync(IPagedRequestBase request)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges(string message)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync(string message)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Person entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Person entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
