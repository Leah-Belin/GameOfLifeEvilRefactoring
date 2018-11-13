using EvilGameOfLife;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLifeTests
{
    [TestClass]
    public class GameBoardTests
    {
        [TestMethod]
        public void GetBoard_NoInput()
        {
            var sut = new GameBoard();
            var expected = new int[100, 100];

            var actual = sut.GetBoard();

            actual.Length.Should().Be(expected.Length);
            actual.Cast<int>().All(x => x == 0).Should().BeTrue();
        }

        [TestMethod]
        public void GetBoard_OneLiveCell_NoGenerations()
        {
            var sut = new GameBoard();
            var expected = new int[100, 100];

            sut.AddPoint(20, 20);
            var actual = sut.GetBoard();

            actual.Length.Should().Be(expected.Length);
            actual[20, 20].Should().Be(1);
        }

        [TestMethod]
        public void GetBoard_OneCell_OneGeneration()
        {
            var sut = new GameBoard(10, 10);
            var expected = new int[10, 10];

            sut.AddPoint(2, 2);
            sut.IncrementGeneration(1);
            var actual = sut.GetBoard();

            actual.Length.Should().Be(expected.Length);
            actual.Cast<int>().All(x => x == 0).Should().BeTrue();
        }

        [TestMethod]
        public void GetBoard_ThreeAdjacentCells_OneGeneration()
        {
            var sut = new GameBoard(10, 10);
            var expected = new int[10, 10];

            sut.AddPoint(2, 2);
            sut.AddPoint(2, 3);
            sut.AddPoint(2, 4);
            sut.IncrementGeneration(1);
            var actual = sut.GetBoard();

            actual.Length.Should().Be(expected.Length);
            CellsAreAlive(actual, new List<(int, int)> { (1, 3), (2, 3), (3, 3) }).Should().BeTrue();
            actual.Cast<int>().Where(x => x == 1).Count().Should().Be(3);
        }

        [TestMethod]
        public void GetBoard_AdjacentCells_TwoGenerations()
        {
            var sut = new GameBoard(10, 10);
            var expected = new int[10, 10];

            sut.AddPoint(2, 2);
            sut.AddPoint(2, 3);
            sut.AddPoint(2, 4);
            sut.IncrementGeneration(2);
            var actual = sut.GetBoard();

            actual.Length.Should().Be(expected.Length);
            CellsAreAlive(actual, new List<(int, int)> { (2, 2), (2, 3), (2, 4) }).Should().BeTrue();
            actual.Cast<int>().Where(x => x == 1).Count().Should().Be(3);
        }

        private bool CellsAreAlive(int[,] board, List<(int x, int y)> cells)
        {
            var allAlive = true;

            foreach (var (x, y) in cells)
            {
                allAlive = board[x, y] == 1;
            }

            return allAlive;
        }
    }
}
