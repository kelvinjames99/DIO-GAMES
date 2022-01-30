using DIO_GAMES.Interfaces;

namespace DIO_GAMES.Classes
{
    public class GamesRepositorio : IRepositorio<Games>
    {

        private List<Games> listaGames = new List<Games>();

        public bool VerificaValidezId(int id)
        {
            if (id > listaGames.Count - 1)
            {
                return false;
            }
            return true;
        }
        public void Atualiza(int id, Games game)
        {
            listaGames[id] = game;
        }

        public void Exclui(int id)
        {
            listaGames[id].Excluir();
        }

        public void Insere(Games game)
        {
            listaGames.Add(game);
        }

        public List<Games> Lista()
        {
            return listaGames;
        }

        public int ProximoId()
        {
            return listaGames.Count;
        }

        public Games RetornaPorId(int id)
        {
            return listaGames[id];
        }
    }
}