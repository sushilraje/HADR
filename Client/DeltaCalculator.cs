using HADRTransfer.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;

namespace HADRTransfer.Client
{
    public class DeltaCalculator<T> : IDisposable
    {
        readonly byte[] refrence = null;

        DeltaCalculator(T refrenceDocument)
        {
            if (refrenceDocument != null)
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    bf.Serialize(ms, refrenceDocument);
                    this.refrence =  ms.ToArray();
                }
            }
        }

        public void GetDelta(T document)
        {
            byte[] documentByteArr;

            if (document != null)
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    bf.Serialize(ms, document);
                    documentByteArr = ms.ToArray();
                }


                int[] delta = null;

                for (int i = 0; i <= this.refrence.Length; i++)
                {
                    delta[i] = this.refrence[i] - documentByteArr[i];
                }

                var result = RLE<int>.Encode(delta.ToList<int>()));

                return string.Concat(result);
            }

        }






        public void Dispose()
        {
            
        }
    }
}
