using GameStore.api.Data;
using GameStore.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.api.Repositories;

public class EntityFrameworkGamesRepository(GameStoreContext dbContext) : IGamesRepository
{
    public IEnumerable<Game> GetAll() => dbContext.Games.AsNoTracking().ToList();

    public Game? Get(int id) => dbContext.Games.Find(id);

    public void Create(Game game)
    {
        dbContext.Games.Add(game);
        dbContext.SaveChanges();
    }

    public void Update(Game updatedGame)
    {
        dbContext.Update(updatedGame);
        dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        dbContext.Games.Where(game => game.Id == id)
                        .ExecuteDelete();
    }
}