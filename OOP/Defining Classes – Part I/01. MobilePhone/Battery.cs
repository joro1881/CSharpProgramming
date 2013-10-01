using System;

//Add an enumeration BatteryType 
//(Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.

    public enum BatteryType
    {
        LiIon, NiMH, NiCd
    }
    public class Battery
    {
        //battery characteristics (model, hours idle and hours talk) 
        private string model = null;
        private int idle = 0;
        private int talk = 0;
        private BatteryType type;

        public Battery()
        {
        }
        
        public Battery(string model, int idle, int talk, BatteryType type)
        {
            this.type = type;
            this.Model = model;
            this.Idle = idle;
            this.Talk = talk;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int Idle
        {
            get { return this.idle; }
            set
            {
                this.idle = value;
            }
        }

        public int Talk
        {
            get
            {
                return this.talk;
            }
            set { this.talk = value; }
        }

        public BatteryType Type
        {
            get { return type; }
        }

        public override string ToString()
        {
            return string.Format("Battery type: {0}\n" +
                                 "Model: {1}\n" +
                                 "Hours of idle: {2}\n" +
                                 "Hours of talk: {3}\n",
                                 this.type, this.model, this.idle, this.talk);
        }
    }

