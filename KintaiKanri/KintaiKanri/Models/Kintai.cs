using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KintaiKanri.Models
{
    public class Kintai
    {
        /// <summary>
        /// 勤怠ID
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// 打刻時間
        /// </summary>
        public DateTime RecordingDate { get; set; }

        public virtual Syain Syain { get; set; }

    }
}