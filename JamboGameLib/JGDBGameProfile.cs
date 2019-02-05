using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    /// <summary>
    /// game profile
    /// </summary>
    public class JGDBGameProfile
    {
        private string m_Login;
        private string m_Pwd;

        internal static readonly JGDBGameProfile Info1;
        internal static readonly JGDBGameProfile Info2;

        static JGDBGameProfile() {
            Info1 = new JGDBGameProfile();
            Info1.m_Login = "test1@jgdb.com";
            Info1.m_Pwd = "admin";
            Info2 = new JGDBGameProfile();
            Info2.m_Login = "test1@jgdb.com";
            Info2.m_Pwd = "sample";
        }
        public string Pwd
        {
            get { return m_Pwd; }            
        }
        public string Login
        {
            get { return m_Login; }        
        }
        private int m_Balance;

        public int Balance
        {
            get { return m_Balance; }
            internal set {
                m_Balance = value;
            }
        }
        internal JGDBGameProfile ()
	    {
            m_Balance = JGConstant.INIT_BALANCE;
	    }
        public static JGDBGameProfile CreateNewProfile(string login, string pwd)
        { 
            //
            return new JGDBGameProfile() { 
                m_Login = login,
                m_Pwd = pwd 
            };
        }

        internal static JGDBGameProfile CreateNewProfile(Dictionary<string, string> t)
        {
            JGDBGameProfile v_t = new JGDBGameProfile();
            Type v_type = v_t.GetType ();
            foreach (var item in t)
            {
                FieldInfo f = v_type.GetField("m_" + item.Key, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                TypeConverter v_convt = TypeDescriptor.GetConverter (f.FieldType );
                f.SetValue(
                    v_t, v_convt.ConvertFromString (item.Value));

            }
            return v_t;
        }
    }
}
