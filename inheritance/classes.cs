using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace inheritance
{
    public class Gadget
    {
        protected static Random rnd = new Random();
        protected int resolution = 0;
        public virtual string getInfo()
        {
            this.resolution = 240 + 120 * (rnd.Next() % 3);
            return $"разрешение экрана {resolution}";
        }

    }
    public class Laptop : Gadget
    {
        byte cores = 0;
        int memory = 0;
        string bluetooth = string.Empty;
        public Laptop()
        {
            this.cores = (byte)(6 + rnd.Next() % 7);
            this.memory = rnd.Next() % 2049;
            this.bluetooth = rnd.Next() % 2 == 0 ? "есть" : "нет";
        }
        public override string getInfo()
        {   
            return $"{cores} ядер, {memory} GB памяти, bluetooth {bluetooth}, "+base.getInfo();
        }
    }
    public class Tablet : Gadget
    {
        string camera = string.Empty;
        int touching = 0;
       public Tablet()
        {
            camera = rnd.Next() % 2 == 0 ? "есть" : "нет";
            touching = 1 + rnd.Next() % 10;
        }
        public override string getInfo()
        {
            return $"камера {camera}, поддерживаемых касаний одновременно {touching}, " + base.getInfo();
        }
    }
   public class Smartphone : Gadget
    {
        byte simslots = 0;
        byte megapixels = 0;
        int battery = 0;
      public Smartphone()
        {
            this.simslots = (byte)(1 + rnd.Next() % 2);
            this.megapixels = (byte)(5 + rnd.Next() % 47);
            this.battery = (1200+rnd.Next() % 2001);
        }
        public override string getInfo()
        {
            return $"поддерживаемых симок {simslots}, камера {megapixels} мегапикселей, батарея {battery} mAh, " + base.getInfo();
        }
    }
}