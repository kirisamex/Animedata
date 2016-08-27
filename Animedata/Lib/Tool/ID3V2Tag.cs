using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Shell32;
using System.Reflection;
using ID3;
using ID3.ID3v2Frames.BinaryFrames;
using Main.Lib;

namespace Main.Music
{
    /// <summary>
    /// ID3V2标签
    /// </summary>
    public class ID3V2Tag
    {
        public ID3V2Tag() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        public ID3V2Tag(string FilePath)
        {
            ID3Info info = new ID3Info(FilePath, true);
            foreach (AttachedPictureFrame AP in info.ID3v2Info.AttachedPictureFrames.Items)
            {
                TrackImages.Add(Image.FromStream(AP.Data));
            }

            ////曲名
            TrackTitleName = info.ID3v2Info.GetTextFrame("TIT2");
            ////艺术家
            ArtistName = info.ID3v2Info.GetTextFrame("TPE1");
            ////专辑
            AlbumName = info.ID3v2Info.GetTextFrame("TALB");
            ////音轨
            TrackNo = info.ID3v2Info.GetTextFrame("TRCK").Trim();
            ////碟号
            DiscNo = info.ID3v2Info.GetTextFrame("TPOS").Trim();
            ////年份
            SalesYear = info.ID3v2Info.GetTextFrame("TYER").Trim();

            if (TrackNo == string.Empty) TrackNo = "1";
            if (DiscNo == string.Empty) DiscNo = "1";

            string SongName = Path.GetFileName(FilePath);//获得歌曲名称  
            FileInfo fInfo = new FileInfo(FilePath);
            Shell sh = new ShellClass();

            Folder dir = sh.NameSpace(FilePath.Substring(0, FilePath.LastIndexOf(@"\")));
            FolderItem item = dir.ParseName(SongName);
            try
            {
                MainFormat format = new MainFormat();
                this.TrackLength = dir.GetDetailsOf(item, 27);
                this.BitRate = dir.GetDetailsOf(item, 28);
            }
            catch
            {
            }
        }



        /// <summary>
        /// 专辑封面
        /// </summary>
        public List<Image> TrackImages = new List<Image>();

        /// <summary>
        /// 曲目名
        /// </summary>
        public string TrackTitleName { get; set; }

        /// <summary>
        /// 艺术家名
        /// </summary>
        public string ArtistName { get; set; }

        /// <summary>
        /// 专辑名
        /// </summary>
        public string AlbumName { get; set; }

        /// <summary>
        /// 碟号
        /// </summary>
        public string DiscNo { get; set; }

        /// <summary>
        /// 音轨
        /// </summary>
        public string TrackNo { get; set; }

        /// <summary>
        /// 发售年份
        /// </summary>
        public string SalesYear { get; set; }

        /// <summary>
        /// 曲目长度
        /// </summary>
        public string TrackLength { get; set; }

        /// <summary>
        /// 比特率
        /// </summary>
        public string BitRate { get; set; }

        /// <summary>
        /// 保存TAG信息
        /// </summary>
        /// <param name="filePath"></param>
        public void Save(string filePath)
        {
            ID3Info info = new ID3Info(filePath, true);
            //曲名
            info.ID3v2Info.SetTextFrame("TIT2", TrackTitleName);
            //艺术家
            info.ID3v2Info.SetTextFrame("TPE1", ArtistName);
            ////专辑
            info.ID3v2Info.SetTextFrame("TALB",AlbumName );
            ////音轨
            info.ID3v2Info.SetTextFrame("TRCK", TrackNo);
            ////碟号
            info.ID3v2Info.SetTextFrame("TPOS", DiscNo);
            ////年份
            info.ID3v2Info.SetTextFrame("TYER", SalesYear);

            info.ID3v2Info.Save();
        }
    }
}
