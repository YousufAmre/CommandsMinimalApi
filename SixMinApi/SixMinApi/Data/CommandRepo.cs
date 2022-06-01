using Microsoft.EntityFrameworkCore;
using SixMinApi.Models;

namespace SixMinApi.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext context;

        public CommandRepo(AppDbContext context)
        {
            this.context = context;
        }
        public async Task CreateCommand(Command cmd)
        {
            if(cmd == null)
                throw new ArgumentNullException(nameof(cmd));
            await context.AddAsync(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));
            context.Commands.Remove(cmd);
        }

        public async Task<IEnumerable<Command>> GetAllCommands()
        {
            return await context.Commands.ToListAsync();
        }

        public async Task<Command?> GetCommandById(int id)
        {
            return await context.Commands.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
