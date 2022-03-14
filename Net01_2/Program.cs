using System;

namespace Net01_2
{
    internal class Program
    {
        const int VALUE = 10;
        const int SIZE_MATRIX = 3;
        const int I = 1;
        const int J = 1;

        static void Main(string[] args)
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(SIZE_MATRIX);
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(SIZE_MATRIX);

            squareMatrix.MatrixChangeEvent += EventHandler;
            diagonalMatrix.MatrixChangeEvent += EventHandler;

            squareMatrix.MatrixChangeEvent += delegate (MatrixEventArgs<int> args)
            {
                if (I == args.I && J == args.J && !Equals(args.Value, VALUE))
                {
                    Console.WriteLine("(Anonymous method) Matrix element value [{0},{1}] changed to {2}", args.I, args.J, VALUE);
                }
            };
            diagonalMatrix.MatrixChangeEvent += delegate (MatrixEventArgs<int> args)
            {
                if (I == args.I && J == args.J && !Equals(args.Value, VALUE))
                {
                    Console.WriteLine("(Anonymous method) Matrix element value [{0},{1}] changed to {2}", args.I, args.J, VALUE);
                }
            };

            squareMatrix.MatrixChangeEvent += args =>
            {
                if (I == args.I && J == args.J && !Equals(args.Value, VALUE))
                {
                    Console.WriteLine("(Lambda expression) Matrix element value [{0},{1}] changed to {2}", args.I, args.J, VALUE);
                }
            };
            diagonalMatrix.MatrixChangeEvent += args =>
            {
                if (I == args.I && J == args.J && !Equals(args.Value, VALUE))
                {
                    Console.WriteLine("(Lambda expression) Matrix element value [{0},{1}] changed to {2}", args.I, args.J, VALUE);
                }
            };

            squareMatrix[I,J] = VALUE;
            diagonalMatrix[I,J] = VALUE;
        }

        /// <summary>
        /// Matrix change event handler.
        /// <param name="args">The Parameter keeping the state of the event.</param>  
        public static void EventHandler(MatrixEventArgs<int> args)
        {
            if (I == args.I && J == args.J && !Equals(args.Value, VALUE))
            {
                Console.WriteLine("(Method) Matrix element value [{0},{1}] changed to {2}", args.I, args.J, VALUE);
            }
        }
    }
}
