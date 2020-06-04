using System;
using System.Collections.Generic;
using System.Drawing;
using BankSystem.Properties;

namespace BankSystem
{
    class BusinessManager
    {
        public struct Business
        {
            public Business(String name_, Bitmap image_)
            {
                name = name_;
                image = image_;
            }

            public String name;
            public Bitmap image;
        };

        private Dictionary<ulong, Business> BusinessDic;
        BusinessManager()
        {
            BusinessDic = new Dictionary<ulong, Business>();
            BusinessDic[1] = new Business("N11", Resources.n11);
        }

        public static BusinessManager Instance = new BusinessManager();

        public bool Find(ulong id, out Business outBusiness)
        {
            foreach (KeyValuePair<ulong, Business> val in BusinessDic)
            {
                if (val.Key == id)
                {
                    outBusiness = val.Value;
                    return true;
                }
            }

            outBusiness = default;
            return false;
        }

    }
}
