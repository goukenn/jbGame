using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame.WinUI
{
    partial  class  UIGameTable
    {
        public class LayerFrameCollections :IEnumerable 
        {
            List<JGLayerFrame> m_frames;
            UIGameTable m_table;
            public int Count { get { return this.m_frames.Count;  } }
            public LayerFrameCollections(UIGameTable table)
            {
                this.m_table = table;
                this.m_frames = new List<JGLayerFrame>();
            }

            public IEnumerator GetEnumerator()
            {
                return this.m_frames.GetEnumerator();
            }

            internal void Add(JGLayerFrame frame)
            {
                this.m_frames.Add(frame);
            }
        }
    }
}
