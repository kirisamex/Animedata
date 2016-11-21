using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Lib.Class.Abstract;
using MusicClient.MusicForm.Dao;

namespace MusicClient.MusicForm.Service
{
    class MusicManageService : MusicAbstractService
    {
        //实例
        MusicManageDAO dao = new MusicManageDAO();
    }
}
