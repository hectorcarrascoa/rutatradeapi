using Layer.Dao.IRepository;
using Layer.Entity;
using Layer.Entity.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Layer.Dao.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DataContext _dbContext;

        public UserRepository(DataContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<UserDto> UserAuthenticationAsync(string userName,string userPassword)
        {
            try
            {
                var item = await (from us in _dbContext.User
                                  join pr in _dbContext.Profile on us.IdProfile equals pr.Id
                                  join cli in _dbContext.Client on us.IdClient equals cli.Id
                                  where us.UserName == userName && us.UserPassword == userPassword
                                  select new UserDto
                                  {
                                      Active = us.Active,
                                      Id = us.Id,
                                      IdClient = us.IdClient,
                                      IdProfile = us.IdProfile,
                                      UserEmail = us.UserEmail,
                                      UserFirstAccess = us.UserFirstAccess,
                                      UserId = us.UserId,
                                      UserLastNames = us.UserLastNames,
                                      FullName = us.UserNames + " " + us.UserLastNames,
                                      UserTitle = us.UserTitle,
                                      UserName = us.UserName,
                                      UserNames = us.UserNames,
                                      UserPhone = us.UserPhone,
                                      UserPicture = us.UserPicture,
                                      IdProfileNavigation = new ProfileDto
                                      {
                                          Active = pr.Active,
                                          Id = pr.Id,
                                          IdClient = pr.IdClient,
                                          ProfileName = pr.ProfileName
                                      },
                                      IdClientNavigation = new ClientDto
                                      {
                                          Id = cli.Id,
                                          Active = cli.Active,
                                          ClientName = cli.ClientName,
                                          ClientAddress = cli.ClientAddress,
                                          ContactEmail = cli.ContactEmail,
                                          ContactName = cli.ContactName,
                                          ContactPhone = cli.ContactPhone,
                                          IdCity = cli.IdCity
                                      }

                                  }).FirstOrDefaultAsync();

                return (UserDto)item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<User>> GetUserByCompany(FiltroReporteDto filter)
        {
            var data = await (from us in _dbContext.User
                              where us.IdClient == filter.IdClient
                              select us).OrderBy(o=>o.UserName).ToListAsync();

            return data;
        }

        public async Task<IEnumerable<UserDto>> GetAllUserAsync(FiltroReporteDto filter)
        {
            var items = await (from us in _dbContext.User
                               join pr in _dbContext.Profile on us.IdProfile equals pr.Id
                               join cli in _dbContext.Client on us.IdClient equals cli.Id
                               join bi in _dbContext.Client on us.IdClient equals bi.Id
                               where us.IdClient == filter.IdClient
                               select new UserDto
                               {
                                   Active = us.Active,
                                   Id = us.Id,
                                   IdClient = us.IdClient,
                                   IdProfile = us.IdProfile,
                                   UserEmail = us.UserEmail,
                                   UserFirstAccess = us.UserFirstAccess,
                                   UserId = us.UserId,
                                   UserLastNames = us.UserLastNames,
                                   UserName = us.UserName,
                                   UserNames = us.UserNames,
                                   UserPhone = us.UserPhone,
                                   UserPicture = us.UserPicture,
                                   Client = cli.ClientName,
                                   Profile = pr.ProfileName,
                                   FullName = us.UserNames + " " + us.UserLastNames,
                                   UserTitle = us.UserTitle,
                                   BackGround = "images/cards/15-640x480.jpg",
                                   IdClientNavigation = new ClientDto
                                   {
                                       Id = cli.Id,
                                       Active = cli.Active,
                                       ClientName = cli.ClientName,
                                       ClientAddress = cli.ClientAddress,
                                       ContactEmail = cli.ContactEmail,
                                       ContactName = cli.ContactName,
                                       ContactPhone = cli.ContactPhone,
                                       IdCity = cli.IdCity
                                   },
                                   IdProfileNavigation = new ProfileDto
                                   {
                                       Active = pr.Active,
                                       Id = pr.Id,
                                       IdClient = pr.IdClient,
                                       ProfileName = pr.ProfileName
                                   },
                               }).OrderBy(o=>o.UserNames).ToListAsync();

            return items;
        }
    }
}
