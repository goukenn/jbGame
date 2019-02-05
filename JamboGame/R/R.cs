using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    public static class R
    {
        static Dictionary<string, Image> sm_resImg;

        static R()
        {
            sm_resImg = new Dictionary<string, Image>();
            Assembly v_asm = MethodInfo.GetCurrentMethod ().DeclaringType.Assembly;
            string[] t = v_asm.GetManifestResourceNames ();
            ResourceManager man = new ResourceManager(MethodInfo.GetCurrentMethod().DeclaringType);
            foreach (string s in t)
	        {

                try
                {
                    Stream v_stream = v_asm.GetManifestResourceStream(s);
                    {
                        if (v_stream == null)
                            continue;
                        using (System.Resources.ResourceReader r = new ResourceReader(v_stream))
                        {
                            foreach (DictionaryEntry item in r)
                            {
                                if (item.Value is Image)
                                {
                                    sm_resImg.Add( (item.Key as string).ToLower (), item.Value as Image );
                                }
                            }
                        }
                    }
                }
                catch { 
                }
	        }
            
        }

        public static Image getImage(string images)
        {
            Image bmp = null;
            string v_s = images.ToLower();
            if (sm_resImg.ContainsKey (v_s))
                bmp = sm_resImg[v_s ];

            return bmp;
        }
    }
}
