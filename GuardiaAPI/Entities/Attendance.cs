using System;

namespace GuardiaAPI.Entities
{
    public class Attendance
    {

        public int AttendanceId { get; set; }
        public int PersonId { get; set; }
        public int UserId { get; set; }
        public int GuardDutyId { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public byte Status  { get; set; }
                        
    }
}
