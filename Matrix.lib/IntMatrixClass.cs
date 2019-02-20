using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.lib
{
    public class IntMatrixClass : ICloneable
    {
        private int _rows;
        private int _columns;
        private int[] _matrix;

        public int Rows { get => _rows; set => _rows = value; }
        public int Columns { get => _columns; set => _columns = value; }
        public int[] Matrix { get => _matrix; set => _matrix = value; }

        public IntMatrixClass( int rows )
        {
            _rows = rows;
            _columns = rows;
            _matrix = new int[ _rows * _columns ];
        }

        public IntMatrixClass( int rows, int columns )
        {
            _rows = rows;
            _columns = columns;
            _matrix = new int[ _rows * _columns ];
        }

        public void SetRandomMatrix()
        {
            Random rnd = new Random();
            for ( int i = 0; i < _columns * _rows; i++ ) { _matrix[ i ] = rnd.Next(); }
        }

        public void SetRandomMatrix( int min, int max )
        {
            Random rnd = new Random();
            for ( int i = 0; i < _columns * _rows; i++ ) { _matrix[ i ] = rnd.Next( min, max + 1 ); }
        }

        public void SetMatrixFromMatrix( int[ , ] matr )
        {
            _rows = matr.GetLength( 0 );
            _columns = matr.GetLength( 1 );
            for ( int i = 0; i < _rows; i++ )
            {
                for ( int j = 0; j < _columns; j++ ) { _matrix[ i * _columns + j ] = matr[ i, j ]; }
            }
        }

        public void Show()
        {
            for ( int i = 0; i < _rows; i++ )
            {
                for ( int j = 0; j < _columns; j++ )
                {
                    Console.Write( $"{this.GetElementAt( i, j ), -5}" );
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public IntMatrixClass SumMatrix( IntMatrixClass temp )
        {
            IntMatrixClass result = new IntMatrixClass( _rows, _columns );
            for ( int i = 0; i < _columns * _rows; i++ )
            {
                result.SetElementAt( i, this.GetElementAt( i ) + temp.GetElementAt( i ) );
            }

            return result;
        }

        public IntMatrixClass MultiMatrix( IntMatrixClass temp )
        {
            IntMatrixClass result = new IntMatrixClass( _rows, temp.Columns );
            for ( int i = 0; i < result.Rows; i++ )
            {
                for ( int j = 0; j < result.Columns; j++ )
                {
                    int someSum = SumOfProducts( this.GetRow( i ), temp.GetColumn( j ) );
                    result.SetElementAt( i, j, someSum );
                }
            }

            return result;
        }

        public int[] GetRow( int k )
        {
            int[] result = new int[ _columns ];
            for ( int j = 0; j < _columns; j++ ) { result[ j ] = _matrix[ k * _columns + j ]; }

            return result;
        }

        public int[] GetColumn( int k )
        {
            int[] result = new int[ _rows ];
            for ( int i = 0; i < _rows; i++ ) { result[ i ] = _matrix[ i * _columns + k ]; }

            return result;
        }

        private int SumOfProducts( int[] a, int[] b )
        {
            int result = 0;
            for ( int i = 0; i < a.Length; i++ ) { result += a[ i ] * b[ i ]; }

            return result;
        }

        public int GetElementAt( int i, int j ) => _matrix[ i * _columns + j ];

        public int GetElementAt( int i ) => _matrix[ i ];

        public void SetElementAt( int i, int j, int value ) { _matrix[ i * _columns + j ] = value; }

        public void SetElementAt( int i, int value ) { _matrix[ i ] = value; }

        public object Clone() { return this.MemberwiseClone(); }
    }
}