using System;

namespace WSUniversalLib
{
    public class Calculation
    {
        int productType;

        public Calculation(int productType, int materialType, int count, int width, int length)
        {
            this.productType = productType;
            this.materialType = materialType;
            this.count = count;
            this.width = width;
            this.length = length;
        }

        int materialType;
        int count;
        float width;
        float length;
        public int GetQuantityForProduct()
        {
            if (count < 1 || width <= 0 || length <= 0)
                return -1;

            float coeffiecient = 0f;

            switch (productType)
            {
                case 1:
                    coeffiecient = 1.1f;
                    break;
                case 2:
                    coeffiecient = 2.5f;
                    break;
                case 3:
                    coeffiecient = 8.43f;
                    break;


                default:
                    return -1;
            }

            float percent = 0f;

            switch (materialType)
            {
                case 1:
                    percent = 0.3f;
                    break;
                case 2:
                    percent = 0.12f;
                    break;


                default:
                    return -1;
            }
            float result = coeffiecient * count * length * width;
            result += result / 100f * percent;

            return (int)Math.Ceiling(result);
            
        }
    }
}
