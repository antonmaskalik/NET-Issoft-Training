using System;

namespace Net01_2
{
    internal class SquareMatrix<T>
    {
        int _size;
        protected T[] _array;

        public int Size { get { return _size; } }

        /// <summary>
        /// Creates a delegate to call an event handler.
        /// </summary>
        /// <param name="args">The Parameter keeping the state of the event.</param>    
        public delegate void MatrixHandler(MatrixEventArgs<T> args);
        public event MatrixHandler? MatrixChangeEvent;

        /// <summary>
        /// Sets size of matrix.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="size" /> must be non-negative and not equal to zero.
        /// </exception>
        public SquareMatrix(int size)
        {
            if (size > 0)
            {
                _size = size;
                _array = new T[(int)Math.Pow(size, 2)];
            }
            else
            {
                throw new ArgumentException("Can not set size: size of matrix is not correct.");
            }
        }

        /// <summary>
        /// Sets or get element of matrix.
        /// </summary>
        ///  <see cref="MatrixEventArgs"/>
        /// <param name="i">The first index of matrix.</param>
        /// <param name="j">The second index of matrix.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="i" /> must be non-negative and less than the size of matrix.
        /// <paramref name="j" /> must be non-negative and less than the size of matrix.
        /// </exception>
        public virtual T this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < _size && j >= 0 && j < _size)
                {
                    return _array[i * _size + j];
                }
                else
                {
                    throw new ArgumentException("Can not get element: Indexes of matrix are not correct.");
                }
            }

            set
            {
                if (i >= 0 && i < _size && j >= 0 && j < _size)
                {
                    T initialValue = _array[i * _size + j];
                    _array[i * _size + j] = value;

                    NotifyEvent(i, j, initialValue);
                }
                else
                {
                    throw new ArgumentException("Can not set element: Indexes of matrix are not correct.");
                }
            }
        }

        /// <summary>
        /// Notify about an event.
        /// </summary>
        ///  <see cref="MatrixEventArgs"/>
        /// <param name="i">The first index of matrix.</param>
        /// <param name="j">The second index of matrix.</param>
        /// <param name="initialValue">TThe initial value of the matrix.</param>
        protected void NotifyEvent(int i, int j, T initialValue)
        {
            MatrixChangeEvent?.Invoke(new MatrixEventArgs<T>(i, j, initialValue));
        }
    }
}

