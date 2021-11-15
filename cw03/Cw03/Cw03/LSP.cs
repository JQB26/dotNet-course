namespace Cw03
{
    public class LSP
    {
        // 3.1
        
        //=== INCORRECT IMPLEMENTATION ===
        /*
        class Rectangle
        {
            public virtual int Height { get; set; }
            public virtual int Width { get; set; }

            public int GetArea()
            {
                return Width * Height;
            }
        }

        class Square : Rectangle
        {
            public override int Height
            {
                get => base.Height;
                set => base.Height = base.Width = value;
            }

            public override int Width
            {
                get => base.Width;
                set => base.Width = base.Height = value;
            }
        }
        */

        private interface IShape
        {
            public int GetArea();
        }

        public class Rectangle : IShape
        {
            public virtual int Height { get; set; }
            public virtual int Width { get; set; }

            public int GetArea()
            {
                return Width * Height;
            }
        }

        public class Square : IShape
        {
            public virtual int Side { get; set; }

            public int GetArea()
            {
                return Side * Side;
            }
        }


         
    }
}