using NUnit.Framework;
using System.Text;

namespace tictactoe_csharp
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void testOnlyAvailableMove()
        {
            var game = new Game("XOXOX-OXO");
            Assert.AreEqual(5, game.Move('X'));

            game = new Game("XOXOXOOX-");
            Assert.AreEqual(8, game.Move('O'));
        }

        [Test]
        public void testStartingDefaultMove()
        {
            Game game = new Game("---------");
            Assert.AreEqual(0, game.Move('X'));
        }

        [Test]
        public void testNoAvailableMove()
        {
            Game game = new Game("XXXXXXXXX");
            Assert.AreEqual(-1, game.Move('X'));
        }

        [Test]
        public void testFindWinningRowMove()
        {
            Game game = new Game("OO-XX-OOX");
            Assert.AreEqual(5, game.Move('X'));
        }

        [Test]
        public void testWinByRowConditions()
        {
            Game game = new Game("---XXX---");
            Assert.AreEqual('X', game.Winner());

            game = new Game("------OOO");
            Assert.AreEqual('O', game.Winner());

            game = new Game("YYY------");
            Assert.AreEqual('Y', game.Winner());
        }
    }

}
