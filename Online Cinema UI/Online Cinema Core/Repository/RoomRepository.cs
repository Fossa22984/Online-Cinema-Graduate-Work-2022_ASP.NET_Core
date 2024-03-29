﻿using Microsoft.EntityFrameworkCore;
using Online_Cinema_Core.Context;
using Online_Cinema_Core.Repository.Interface;
using Online_Cinema_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Online_Cinema_Core.Repository
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(OnlineCinemaContext context) : base(context) { }

        public async Task CreateRoomAsync(Room room)
        {
            await CreateAsync(room);
        }

        public async Task<IEnumerable<Room>> GetAllRoomAsync()
        {
            return await FindAll().Include(x => x.Owner).Include(x => x.Movie).ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetRoomByConditionAsync(Expression<Func<Room, bool>> predicate)
        {
            return await FindByCondition(predicate).Include(x => x.Owner).Include(x => x.Movie).ToListAsync();
        }

        public async Task<Room> GetRoomByIdAsync(int Id)
        {
            return await FindByCondition(x => x.Id == Id).AsNoTracking().Include(x => x.Owner).Include(x => x.Movie).FirstOrDefaultAsync();
        }

        public async Task RemoveRoomAsync(Room room)
        {
            await DeleteAsync(room);
        }

        public async Task UpdateRoomAsync(Room room)
        {
            await UpdateAsync(room);
        }
    }
}
