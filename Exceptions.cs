using System;

namespace Exceptions
{
    //TODO: Create custom exception "MatrixException"


    public class Matrix
    {
        private double[,] array;
        /// <summary>
        /// Number of rows.
        /// </summary>
        public int Rows
        {
            get => array.GetLength(0);
        }

        /// <summary>
        /// Number of columns.
        /// </summary>
        public int Columns
        {
            get => array.GetLength(1);
        }

        /// <summary>
        /// An array of floating-point values that represents the elements of this Matrix.
        /// </summary>
        public double[,] Array
        {
            get => array;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when row or column is zero or negative.</exception>
        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0) throw new ArgumentOutOfRangeException("rows|columns");
            array = new double[rows, columns];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class with the specified elements.
        /// </summary>
        /// <param name="array">An array of floating-point values that represents the elements of this Matrix.</param>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        public Matrix(double[,] array)
        {
            if (array == null) throw new ArgumentNullException("array");
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            this.array = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    this.array[i, j] = array[i, j];
                }
            }

        }

        /// <summary>
        /// Allows instances of a <see cref="Matrix"/> to be indexed just like arrays.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <exception cref="ArgumentException">Thrown when index is out of range.</exception>
        public double this[int row, int column]
        {
            get
            {
                if (row < 0 || column < 0 || row > Rows || column > Columns) throw new ArgumentException("The index out of range");
                return this.Array[row, column];
            }
            set
            {
                if (row < 0 || column < 0 || row > Rows || column > Columns) throw new ArgumentException("The index out of range");
                this.Array[row, column] = value;
            }
        }

        /// <summary>
        /// Adds <see cref="Matrix"/> to the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for adding.</param>
        /// <exception cref="ArgumentNullException">Thrown when parameter is null.</exception>
        /// <exception cref="MatrixException">Thrown when the matrix has the wrong dimensions for the operation.</exception>
        /// <returns><see cref="Matrix"/></returns>
        public Matrix Add(Matrix matrix)
        {
            if (matrix == null) throw new ArgumentNullException("matrix");
            if (this.Rows == matrix.Rows && this.Columns == matrix.Columns)
            {
                int rows = this.Rows;
                int columns = this.Columns;

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        this[i, j] = this[i, j] + matrix[i, j];
                    }
                }
                return this;
            }
            throw new MatrixException("Can`t perform the sum operation with the indicated martices");
        }

        /// <summary>
        /// Subtracts <see cref="Matrix"/> from the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for subtracting.</param>
        /// <exception cref="ArgumentNullException">Thrown when parameter is null.</exception>
        /// <exception cref="MatrixException">Thrown when the matrix has the wrong dimensions for the operation.</exception>
        /// <returns><see cref="Matrix"/></returns>
        public Matrix Subtract(Matrix matrix)
        {
            if (matrix == null) throw new ArgumentNullException("matrix");

            if (this.Rows == matrix.Rows && this.Columns == matrix.Columns)
            {
                int rows = this.Rows;
                int columns = this.Columns;

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        this[i, j] = this[i, j] - matrix[i, j];
                    }
                }

                return this;
            }
            throw new MatrixException("Can`t perform the subsraction operation with the indicated martices");
        }

        /// <summary>
        /// Multiplies <see cref="Matrix"/> on the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for multiplying.</param>
        /// <exception cref="ArgumentNullException">Thrown when parameter is null.</exception>
        /// <exception cref="MatrixException">Thrown when the matrix has the wrong dimensions for the operation.</exception>
        /// <returns><see cref="Matrix"/></returns>
        public Matrix Multiply(Matrix matrix)
        {
            if (matrix == null) throw new ArgumentNullException("matrix");
            int rA = this.Rows;
            int cA = this.Columns;

            int rB = matrix.Rows;
            int cB = matrix.Columns;

            double temp;

            if (cA == rB)
            {
                Matrix newMatrix = new Matrix(rA, cB);

                for (int i = 0; i < rA; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        temp = 0;
                        for (int k = 0; k < cA; k++)
                        {
                            temp += this[i, k] * matrix[k, j];
                        }
                        newMatrix[i, j] = temp;
                    }
                }

                return newMatrix;
            }
            throw new MatrixException("Can`t perform the multiplication operation with the indicated martices");
        }
    }
}




