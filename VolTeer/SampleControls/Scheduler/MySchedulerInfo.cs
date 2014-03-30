
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

public class MySchedulerInfo : SchedulerInfo
{
    public string TeacherID { get; set; }
    public MySchedulerInfo(ISchedulerInfo baseInfo, string teacherID)
        : base(baseInfo)
    {
        TeacherID = teacherID;
    }
    public MySchedulerInfo()
    {

    }
}

