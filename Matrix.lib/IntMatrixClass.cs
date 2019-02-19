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

        public int Size { get => _rows; set => _rows = value; }
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

        public int GetElementAt( int i, int j ) => _matrix[ i * _columns + j ];

        public object Clone() { return this.MemberwiseClone(); }
    }
}