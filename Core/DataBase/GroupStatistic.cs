//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class GroupStatistic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GroupStatistic()
        {
            this.GroupTime = new HashSet<GroupTime>();
        }
    
        public int ID { get; set; }
        public Nullable<int> IDStudent { get; set; }
        public Nullable<int> IDLesson { get; set; }
        public Nullable<bool> isDelete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupTime> GroupTime { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual Student Student { get; set; }
    }
}
