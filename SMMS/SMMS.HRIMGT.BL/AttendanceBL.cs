using SMMS.HRIMGT.DAL;
using SMMS.HRIMGT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.HRIMGT.BL
{
    public class AttendanceBL
    {
        AttendanceDAL oAttendanceDAL = new AttendanceDAL();
        public bool AddAttendance(List<AttendanceDTO> attendance)
        {
            return oAttendanceDAL.AddAttendance(attendance);
        }
        public List<AttendanceDTO> GetAttendance()
        {
            return oAttendanceDAL.GetAttendance();
        }
    }
}
