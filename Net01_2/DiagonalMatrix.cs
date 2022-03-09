using System;

namespace Net01_2
{
    internal class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Sets size of matrix.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="size" /> must be non-negative and not equal to zero.
        /// </exception>
        public DiagonalMatrix(int size) : base(size)
        {
            Array.Resize(ref _array, size);
        }

        /// <summary>
        /// Sets or get element of matrix.
        /// </summary>
        ///  <see cref="MatrixEventArgs"/>
        /// <param name="i">The first index of matrix.</param>
        /// <param name="j">The second index of matrix.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="i" /> must be non-negative and less than the size of matrix and i = j.
        /// <paramref name="j" /> must be non-negative and less than the size of matrix and i = j.
        /// </exception>
        public override T this[int i, int j]
        {
            get
            {
                if (i == j && i >= 0 && i < Size && j >= 0 && j < Size)
                {
                    return _array[i];
                }
                else
                {
                    throw new ArgumentException("Can not get element: Indexes of matrix are not correct.");
                }
            }

            set
            {
                if (i == j && i >= 0 && i < Size && j >= 0 && j < Size)
                {
                    T initialValue = _array[i];
                    _array[i] = value;

                    NotifyEvent(i, j, initialValue);
                }
                else
                {
                    throw new ArgumentException("Can not set element: Indexes of matrix are not correct.");
                }
            }
        }
    }
}
