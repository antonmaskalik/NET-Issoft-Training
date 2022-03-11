using System;

namespace Net01_2
{
    internal class Program
    {
        static int value = 10;
        static int sizeMatrix = 3;
        static int i = 1;
        static int j = 1;

        static void Main(string[] args)
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(sizeMatrix);
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(sizeMatrix);

            squareMatrix.MatrixChangeEvent += EventHandler;
            diagonalMatrix.MatrixChangeEvent += EventHandler;

            squareMatrix.MatrixChangeEvent += delegate (MatrixEventArgs<int> args)
            {
                if (i == args.I && j == args.J && !Equals(args.Value, value))
                {
                    Console.WriteLine("(Anonymous method) Matrix element value [{0},{1}] changed to {2}", args.I, args.J, value);
                }
            };
            diagonalMatrix.MatrixChangeEvent += delegate (MatrixEventArgs<int> args)
            {
                if (i == args.I && j == args.J && !Equals(args.Value, value))
                {
                    Console.WriteLine("(Anonymous method) Matrix element value [{0},{1}] changed to {2}", args.I, args.J, value);
                }
            };

            squareMatrix.MatrixChangeEvent += args =>
            {
                if (i == args.I && j == args.J && !Equals(args.Value, value))
                {
                    Console.WriteLine("(Lambda expression) Matrix element value [{0},{1}] changed to {2}", args.I, args.J, value);
                }
            };
            diagonalMatrix.MatrixChangeEvent += args =>
            {
                if (i == args.I && j == args.J && !Equals(args.Value, value))
                {
                    Console.WriteLine("(Lambda expression) Matrix element value [{0},{1}] changed to {2}", args.I, args.J, value);
                }
            };

            squareMatrix[i,j] = value;
            diagonalMatrix[i,j] = value;
        }

        /// <summary>
        /// Matrix change event handler.
        /// <param name="args">The Parameter keeping the state of the event.</param>  
        public static void EventHandler(MatrixEventArgs<int> args)
        {
            if (i == args.I && j == args.J && !Equals(args.Value, value))
            {
                Console.WriteLine("(Method) Matrix element value [{0},{1}] changed to {2}", args.I, args.J, value);
            }
        }
    }
}
