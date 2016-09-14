using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Lib.Const;

namespace Main.Music
{
    class TrackSeriesService : MusicManageService
    {
        TrackSeriesDao dao = new TrackSeriesDao();

        /// <summary>
        /// 通过曲目ID获得曲目信息
        /// </summary>
        /// <param name="TrackID"></param>
        /// <returns></returns>
        public DataSet GetTrackByTrackId(string TrackID)
        {
            return dao.GetTrackByTrackId(TrackID);
        }

        /// <summary>
        /// 获取匹配表
        /// </summary>
        /// <param name="TrackID"></param>
        /// <returns></returns>
        public List<TrackResource> GetResourceMaps(string TrackID)
        {
            List<TrackResource> mapList = new List<TrackResource>();

            DataSet ds = dao.GetResourceMapByTrackId(TrackID);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TrackResource map = new TrackResource();
                map.ResourceID = Convert.ToInt32(dr[CommonConst.ColumnName.RESOURCE_ID]);
                map.TrackID = dr[CommonConst.ColumnName.TRACK_ID].ToString();
                mapList.Add(map);
            }

            return mapList;
        }

        /// <summary>
        /// 获取资源信息
        /// </summary>
        /// <param name="TrackID"></param>
        /// <returns></returns>
        public List<ResourceSeries> GetResources(string TrackID)
        {
            List<ResourceSeries> resourceList = new List<ResourceSeries>();

            DataSet ds = dao.GetResourceIDByTrackId(TrackID);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ResourceSeries resource = new ResourceSeries(Convert.ToInt32(dr[CommonConst.ColumnName.RESOURCE_ID]));

                resourceList.Add(resource);
            }

            return resourceList;
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        public bool Insert(TrackSeries track)
        {
            foreach (ResourceSeries resource in track.Resource)
            {
                if (!resource.Insert())
                {
                    return false;
                }
            }

            foreach (TrackResource map in track.ResourceMap)
            {
                if (!map.Insert())
                {
                    return false;
                }
            }

            return dao.Insert(track);
        }
    }
}
