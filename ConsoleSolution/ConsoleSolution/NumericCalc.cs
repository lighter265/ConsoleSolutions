using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSolution
{
    public class Matrix
    {
        //--メンバ--------------------------------------
        public uint size_x { get; } //横方向サイズ
        public uint size_y { get; } //縦方向サイズ
        private double[,] _mat;      //行列本体

        //--コンストラクタ------------------------------
        public Matrix(uint size)
        {
            size_x = size;
            size_y = size;
            _mat = new double[size, size];
            this.Fill(0);
        }

        public Matrix(uint size, double f)
        {
            size_x = size;
            size_y = size;
            _mat = new double[size, size];
            this.Fill(f);
        }

        //--メソッド-------------------------------------
        public void Fill(double num)
        {
            for (int y = 0; y < size_y; y++)
            {
                for (int x = 0; x < size_x; x++)
                {
                    _mat[x, y] = num;
                }
            }
        }

        public double GetDeterminant()
        {
            switch (size_x)
            {
                case 1: //1次
                    return _mat[0, 0];
                case 2: //2次
                    return _mat[0, 0] * _mat[1, 1] - _mat[0, 1] * _mat[1, 0];
                default: //3次以上
                    return sub_GetDeterminant();
            }
        }

        private double sub_GetDeterminant()
        {
            double ret = 1.0;

            for (int y = 0; y < size_y; y++)
            {
                for (int x = 0; x < size_x; x++)
                {
                    double buffer = _mat[x, y] / _mat[y, y];
                    for (int k = 0; k < size_x; k++) _mat[x, k] -= _mat[y, k] * buffer;
                }
            }

            for (int i = 0; i < size_x; i++)
            {
                ret *= _mat[i, i];
            }

            return ret;
        }
    }
}
