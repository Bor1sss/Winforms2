using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace First_Project
{
    [Serializable]

    [KnownType(typeof(Flash))]
    [KnownType(typeof(DVD))]
    [KnownType(typeof(HDD))]
    [XmlInclude(typeof(Flash))]
    [XmlInclude(typeof(DVD))]
    [XmlInclude(typeof(HDD))]
    [DataContract]
    public abstract class StorageInfo
    {



        public StorageInfo()
        {
            Manufactur = "Manufactur";
            Model = "Model";
            Name = "Name";
            Storage = "Storage";
            Kol = 0;

        }
        [DataMember]
        public string Manufactur { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]

        public string Storage { get; set; }
        [DataMember]
        public int Kol { get; set; }



        public virtual void Print(Ilog ilog) { }




    }
    [Serializable]
    [DataContract]
    public class Flash : StorageInfo
    {
        [DataMember]
        public double Speed { get; set; }
        public Flash() : base()
        {


            Speed = 0;

        }
        [JsonConstructor]
        public Flash(string manufactur, string model, string name, string storage, int kol, double sped)
        {
            Manufactur = manufactur;
            Model = model;
            Name = name;
            Storage = storage;
            Kol = kol;
            Speed = sped;

        }

        public override void Print(Ilog ilog)
        {
            ilog.Print("Manufactrur " + Manufactur + '\n' + "Model " + Model + '\n' + "Name " + Name + '\n' + "Storage " + Storage + '\n' + "Kol " + Kol + '\n' + "Speed " + Speed + '\n');
        }

    }



    [Serializable]
    [DataContract]

    public class HDD : StorageInfo
    {
        [DataMember]
        public double Speed { get; set; }
        public HDD() : base()
        {


            Speed = 0;

        }
        [JsonConstructor]
        public HDD(int sped)
        {
            Speed = sped;
        }
        public HDD(string manufactur, string model, string name, string storage, int kol, double sped)
        {
            Manufactur = manufactur;
            Model = model;
            Name = name;
            Storage = storage;
            Kol = kol;
            Speed = sped;

        }

        public override void Print(Ilog ilog)
        {
            ilog.Print("Manufactrur " + Manufactur + '\n' + "Model " + Model + '\n' + "Name " + Name + '\n' + "Storage " + Storage + '\n' + "Kol " + Kol + '\n' + "Speed " + Speed + '\n');
        }




    }

    [Serializable]
    [DataContract]
    public class DVD : StorageInfo
    {
        [DataMember]
        public double Speed { get; set; }
        public DVD() : base()
        {


            Speed = 0;

        }
        [JsonConstructor]
        public DVD(string manufactur, string model, string name, string storage, int kol, double sped)
        {
            Manufactur = manufactur;
            Model = model;
            Name = name;
            Storage = storage;
            Kol = kol;
            Speed = sped;

        }

        public override void Print(Ilog ilog)
        {
            ilog.Print("Manufactrur " + Manufactur + '\n' + "Model " + Model + '\n' + "Name " + Name + '\n' + "Storage " + Storage + '\n' + "Kol " + Kol + '\n' + "Speed " + Speed + '\n');
        }

    }
}
