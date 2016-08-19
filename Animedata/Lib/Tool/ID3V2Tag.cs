using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ID3;
using ID3.ID3v2Frames.BinaryFrames;

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

            info.ID3v2Info.GetTextFrame("TIT2");

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
        
    }
}
