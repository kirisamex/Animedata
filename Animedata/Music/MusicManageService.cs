using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    class MusicManageService : MainService
    {
        MusicManageDAO dao = new MusicManageDAO();

        public DataSet GetTracks()
        {
            return dao.GetTracks();
        }
    }
}
