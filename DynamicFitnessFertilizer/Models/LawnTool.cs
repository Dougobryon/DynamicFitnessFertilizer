//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DynamicFitnessFertilizer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LawnTool
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LawnTool()
        {
            this.Loaners = new HashSet<Loaner>();
        }
    
        public int LawnToolsID { get; set; }
        public string ToolName { get; set; }
        public string ToolBrand { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loaner> Loaners { get; set; }
    }
}
