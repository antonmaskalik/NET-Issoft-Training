
namespace Net01_2
{
    internal class MatrixEventArgs<T>
    {
        int _i;
        int _j;
        T _value;

        /// <summary>
        /// Sets size of matrix.
        /// </summary>
        /// <param name="i">The first index of matrix.</param>
        /// <param name="j">The second index of matrix.</param>
        /// <param name="value">The value of matrix with indexes (i;j).</param>       
        public MatrixEventArgs (int i, int j, T value)
        {
            _i = i; 
            _j = j;
            _value = value;
        }

        /// <summary>
        /// Get index i.
        /// </summary>
        public int I {get { return _i; } }

        /// <summary>
        /// Get index j.
        /// </summary>
        public int J {get { return _j; } }

        /// <summary>
        /// Get value of matrix with indexes (i;j).
        /// </summary>
        public T Value {get { return _value; } }
    }
}
