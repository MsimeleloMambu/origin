using System;
using NUnit.Framework;
using System.Linq;
using NSubstitute;

namespace Checkers.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ABoardHas12BlackAnd12WhitePieces()
        {
            Board b = new Board();
            int blackCount = b.Pieces(Color.Black).Count();
            int whiteCount = b.Pieces(Color.White).Count();
            Assert.That(blackCount == 12);
            Assert.That(whiteCount == 12);
        }

        static object[] legalMovesOnEmptyBoard =
        {
            new object[] {Color.Black, 1, new int[] { 5, 6 } },
            new object[]{Color.Black, 2, new int[] {6,7}},
            new object[] {Color.Black, 3, new int[] { 7, 8 } },
            new object[] {Color.Black, 4, new int[] {8}},
            new object[] {Color.Black, 5, new int[] {9}},
            new object[] {Color.Black, 6, new int[] {9, 10}},
            new object[] {Color.Black, 7, new int[] {10,11}},
            new object[] {Color.Black, 8, new int[] {11, 12}},
            new object[] {Color.Black, 9, new int[] {13, 14}},
            new object[] {Color.Black, 10, new int[] {14, 15}},
            new object[] {Color.Black, 11, new int[] {15, 16}},
            new object[] { Color.Black, 12, new int[] {16} },
            new object[] { Color.Black, 13, new int[] {17} },
            new object[] { Color.Black, 14, new int[] {17, 18} },
            new object[] { Color.Black, 15, new int[] {18, 19} },
            new object[] { Color.Black, 16, new int[] {19, 20} },
            new object[] { Color.Black, 17, new int[] {21, 22} },
            new object[] { Color.Black, 18, new int[] {22, 23} },
            new object[] { Color.Black, 19, new int[] {23, 24} },
            new object[] { Color.Black, 20, new int[] {24} },
            new object[] { Color.Black, 21, new int[] {25} },
            new object[] { Color.Black, 22, new int[] {25, 26} },
            new object[] { Color.Black, 23, new int[] {26, 27} },
            new object[] { Color.Black, 24, new int[] {27, 28} },
            new object[] { Color.Black, 25, new int[] {29, 30} },
            new object[] { Color.Black, 26, new int[] {30, 31} },
            new object[] { Color.Black, 27, new int[] {31, 32} },
            new object[] { Color.Black, 28, new int[] {32} },
            new object[] { Color.Black, 29, new int[] {} },
            new object[] { Color.Black, 30, new int[] {} },
            new object[] { Color.Black, 31, new int[] {} },
            new object[] { Color.Black, 32, new int[] {} },

            new object[] { Color.White, 9, new int[] {5, 6} },
            new object[] { Color.White, 10, new int[] {6, 7} },
            new object[] { Color.White, 11, new int[] {7, 8} },
            new object[] { Color.White, 12, new int[] {8} },
            new object[] { Color.White, 13, new int[] {9} },
            new object[] { Color.White, 14, new int[] {9, 10} },
            new object[] { Color.White, 15, new int[] {10, 11} },
            new object[] { Color.White, 16, new int[] {11, 12} },
            new object[] { Color.White, 17, new int[] {13, 14} },
            new object[] { Color.White, 18, new int[] {14, 15} },
            new object[] { Color.White, 19, new int[] {15, 16} },
            new object[] { Color.White, 20, new int[] {16} },
            new object[] { Color.White, 21, new int[] {17} },
            new object[] { Color.White, 22, new int[] {17, 18} },
            new object[] { Color.White, 23, new int[] {18, 19} },
            new object[] { Color.White, 24, new int[] {19, 20} },
            new object[] { Color.White, 25, new int[] {21, 22} },
            new object[] { Color.White, 26, new int[] {22, 23} },
            new object[] { Color.White, 27, new int[] {23, 24} },
            new object[] { Color.White, 28, new int[] {24} },
            new object[] { Color.White, 29, new int[] {25} },
            new object[] { Color.White, 30, new int[] {25, 26} },
            new object[] { Color.White, 31, new int[] {26, 27} },
            new object[] { Color.White, 32, new int[] {27, 28} },
            new object[] { Color.White, 5, new int[] {1} },
            new object[] { Color.White, 6, new int[] {1, 2} },
            new object[] { Color.White, 7, new int[] {2, 3} },
            new object[] { Color.White, 8, new int[] {3, 4} },
            new object[] { Color.White, 1, new int[] {} },
            new object[] { Color.White, 2, new int[] {} },
            new object[] { Color.White, 3, new int[] {} },
            new object[] { Color.White, 4, new int[] {} }
        };

        [Test]
        [TestCaseSource(nameof(legalMovesOnEmptyBoard))]
        public void APieceKnowsTheLegalMovesItCanMake(Color c, int pos, int[] expected)
        {
            IPiece p = new Piece(c, pos);
            IBoard b = Substitute.For<IBoard>();
            b.Pieces(c).Returns(new int[] { pos });
            b.Pieces(Arg.Is<Color>(x => x != c)).Returns(Array.Empty<int>());
            b.Occupant(Arg.Any<int>()).Returns((IPiece)null);
            int[] result = p.NormalMoves(b).ToArray();
            Array.Sort(expected);
            Array.Sort(result);
            Assert.AreEqual(expected, result);
            foreach (int x in expected)
            {
                b.Received().Occupant(x);
            }
        }

    }
}

