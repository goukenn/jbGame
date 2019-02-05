using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JamboGame
{

    /// <summary>
    /// represent a xml database used to store the current data
    /// </summary>
    public class JGDB
    {
        static Dictionary<string, JGDBGameProfile> sm_profile;

        static JGDB()
        {
            sm_profile = new Dictionary<string, JGDBGameProfile>();
            if (File.Exists(JGConstant.DB_FILE))
            {
                XmlReader xreader = XmlReader.Create("jgdb.xml");
                try
                {
                    while (xreader.Read())
                    {
                        switch (xreader.NodeType)
                        {

                            case XmlNodeType.Element:
                                if (xreader.Name == "profile")
                                {
                                    JGDBGameProfile p = LoadProfile(xreader.ReadSubtree());
                                    if (!string.IsNullOrEmpty(p.Login) && !sm_profile.ContainsKey(p.Login))
                                        sm_profile.Add(p.Login, p);
                                }
                                break;

                            default:
                                break;
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    xreader.Close();
                }
            }
            if (sm_profile.Count == 0)
            {
                sm_profile.Add("test1@jgdb.com", JGDBGameProfile.Info1 );
                sm_profile.Add("test2@jgdb.com", JGDBGameProfile.Info2 );
            }
            
        }
        public static void StoreDb()
        {
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;
            setting.CloseOutput = true;
            XmlWriter xwriter = null;

            try
            {
               xwriter =  XmlWriter.Create("jgdb.xml", setting);

                xwriter.WriteStartElement("jgdb");

                foreach (var item in sm_profile)
                {
                    xwriter.WriteStartElement("profile");
                    foreach (PropertyInfo prop in item.Value.GetType().GetProperties())
                    {
                        object obj = prop.GetValue(item.Value, null);
                        xwriter.WriteElementString(prop.Name, obj != null ? obj.ToString() : "");
                    }
                    xwriter.WriteEndElement();
                }

                xwriter.WriteEndElement();
                xwriter.Flush();
            }
            catch { }
            finally
            {
                xwriter.Close();
            }
        }

        private static JGDBGameProfile LoadProfile(XmlReader xmlReader)
        {
            Dictionary<string , string > t = new Dictionary<string,string> ();
            while (xmlReader.Read())
	        {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (xmlReader.Name != "profile")
                        {
                            if (!t.ContainsKey (xmlReader.Name))
                            t.Add(xmlReader.Name, xmlReader.ReadInnerXml());
                        }
                        break;

                    default:
                        break;
                }
                
	        }
            return JGDBGameProfile.CreateNewProfile(t);
        }



        internal static bool RemoveFromBalance(JGPlayer jGPlayer, int Balance)
        {
            //jGPlayer.P
            if (jGPlayer.Profile != null)
            {
                if (jGPlayer.Profile.Balance >= Balance)
                {
                    jGPlayer.Profile.Balance -= Balance;
                    StoreDb();
                    return true;
                }
            }
            return false;
        }

        internal static bool RestoreBalance(JGGameTablePlayerProfile jGGamePlayerProfile)
        {
            jGGamePlayerProfile.Player.Profile.Balance += jGGamePlayerProfile.TableBalance;
            StoreDb();
            return true;   
        }

        public static JGDBGameProfile GetProfile(string p)
        {
            if (sm_profile.ContainsKey(p))
                return sm_profile[p];
            return null;
        }




        public static void Restore(params JGGameTablePlayerProfile[] profiles)
        {
            var t = (from s in profiles where s != null select s);
            foreach (var s in t)
                s.Restore();
        }
    }
}
