//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolManagement.Models.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public long StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public long CityFK { get; set; }
        public long StateFK { get; set; }
        public long CountryFK { get; set; }
        public long StandardFk { get; set; }
        public long TeacherFK { get; set; }
        public long SubjectFK { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public long CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        public Nullable<long> DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Standard Standard { get; set; }
        public virtual State State { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}