using GameStore.api.Data;
using GameStore.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.api.Repositories;

public class EntityFrameworkGamesRepository(GameStoreContext dbContext) : IGamesRepository
{
    public async Task<IEnumerable<Game>> GetAllAsync() => await dbContext.Games.AsNoTracking().ToListAsync();

    public async Task<Game?> GetAsync(int id) => await dbContext.Games.FindAsync(id);

    public async Task CreateAsync(Game game)
    {
        dbContext.Games.Add(game);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Game updatedGame)
    {
        dbContext.Update(updatedGame);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await dbContext.Games.Where(game => game.Id == id)
                        .ExecuteDeleteAsync();
    }
}