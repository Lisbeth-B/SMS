using SalesManagementSystem.db;
using SalesManagementSystem.Domain;
using SalesManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesManagementSystem.Infra
{
    public class ConsultantRepository : IRepository<ConsultantEntity>
    {
        private readonly SalesManagementSystemEntities _dbContext;

        public ConsultantRepository(SalesManagementSystemEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(ConsultantEntity consultantEntity)
        {
            Consultant consultant = new Consultant
            {
                Id = consultantEntity.Id,
                Name = consultantEntity.Name,
                Surname = consultantEntity.Surname,
                IdNumber = consultantEntity.IdNumber,
                Sex = (byte)consultantEntity.Sex,
                DateOfBirth = consultantEntity.DateOfBirth.Date,
                ReferrerId = consultantEntity.ReferrerId
            };

            _dbContext.Consultants.Add(consultant);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Consultant consultant = _dbContext.Consultants.Find(id);
            _dbContext.Consultants.Remove(consultant);
            _dbContext.SaveChanges();
        }

        public IEnumerable<ConsultantEntity> List()
        {
            List<Consultant> consultantList = _dbContext.Consultants.ToList();

            List<ConsultantEntity> result = new List<ConsultantEntity>();

            foreach (Consultant consultant in consultantList)
            {
                result.Add(new ConsultantEntity(id: consultant.Id,
                                                name: consultant.Name,
                                                surname: consultant.Surname,
                                                idNumber: consultant.IdNumber,
                                                sex: (SexEnum)consultant.Sex,
                                                dateOfBirth: consultant.DateOfBirth,
                                                referrerId: consultant.ReferrerId ?? null));
            }

            return result;
        }

        public ConsultantEntity GetById(int id)
        {
            Consultant consultant = _dbContext.Consultants.Find(id);

            if (consultant == null)
            {
                return null;
            }

            return new ConsultantEntity(id: consultant.Id,
                                        name: consultant.Name,
                                        surname: consultant.Surname,
                                        idNumber: consultant.IdNumber,
                                        sex: (SexEnum)consultant.Sex,
                                        dateOfBirth: consultant.DateOfBirth,
                                        referrerId: consultant.ReferrerId);
        }

        public void Update(ConsultantEntity consultantEntity)
        {
            Consultant consultant = _dbContext.Consultants.Find(consultantEntity.Id);
            consultant.Name = consultantEntity.Name;
            consultant.Surname = consultantEntity.Surname;
            consultant.IdNumber = consultantEntity.IdNumber;
            consultant.Sex = (byte)consultantEntity.Sex;
            consultant.DateOfBirth = consultantEntity.DateOfBirth.Date;
            consultant.ReferrerId = consultantEntity.ReferrerId;
            _dbContext.SaveChanges();
        }
    }
}