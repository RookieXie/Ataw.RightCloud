using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Ataw.Framework.Core;
using Ataw.RightCloud.Data;
using Ataw.RightCloud.Data.Table;
using Ataw.RightCloud.DB.PageMark;
using Ataw.RightCloud.DB.RC.Collection;
using Ataw.RightCloud.DB.RC;

namespace Ataw.RightCloud.DB
{
    public class RightCloudDBContext : AtawDbContext
    {


        static RightCloudDBContext()
        {
            Database.SetInitializer<RightCloudDBContext>(null);
        }


        /// <summary>
        /// Ataw_Gruop
        /// </summary>
        public IDbSet<Ataw_Gruop> Ataw_Gruop { get; set; }

       

        /// <summary>
        /// RC_Department
        /// </summary>
        public IDbSet<RC_Department> RC_Department { get; set; }

        /// <summary>
        /// Ataw_Menus
        /// </summary>
        public IDbSet<Ataw_Menus> Ataw_Menus { get; set; }

        /// <summary>
        /// Ataw_Menus_Button
        /// </summary>
        public IDbSet<Ataw_Menus_Button> Ataw_Menus_Button { get; set; }

        /// <summary>
        /// Ataw_Rights
        /// </summary>
        public IDbSet<Ataw_Rights> Ataw_Rights { get; set; }

        /// <summary>
        /// Ataw_Role_Rights
        /// </summary>
        public IDbSet<Ataw_Role_Rights> Ataw_Role_Rights { get; set; }

        /// <summary>
        /// Ataw_Users
        /// </summary>
        public IDbSet<Ataw_Users> Ataw_Users { get; set; }

        /// <summary>
        /// Ataw_UsersDetail
        /// </summary>
        public IDbSet<Ataw_UsersDetail> Ataw_UsersDetail { get; set; }

        /// <summary>
        /// Ataw_User_Roles
        /// </summary>
        public IDbSet<Ataw_User_Roles> Ataw_User_Roles { get; set; }


        /// <summary>
        /// Ataw_Roles
        /// </summary>
        public IDbSet<Ataw_Roles> Ataw_Roles { get; set; }


        public IDbSet<Ataw_Menus_Group> Ataw_Menus_Group { get; set; }

        /// <summary>
        /// RC_Group_Product
        /// </summary>
        public IDbSet<RC_Group_Product> RC_Group_Product { get; set; }

        /// <summary>
        /// RC_Group_tree
        /// </summary>
        public IDbSet<RC_Group_tree> RC_Group_tree { get; set; }

        /// <summary>
        /// RC_Menu_Group
        /// </summary>
        public IDbSet<RC_Menu_Group> RC_Menu_Group { get; set; }

        /// <summary>
        /// RC_Menu_Role
        /// </summary>
        public IDbSet<RC_Menu_Role> RC_Menu_Role { get; set; }

        /// <summary>
        /// RC_Menu_tree
        /// </summary>
        public IDbSet<RC_Menu_tree> RC_Menu_tree { get; set; }

        /// <summary>
        /// RC_Product
        /// </summary>
        public IDbSet<RC_Product> RC_Product { get; set; }

        /// <summary>
        /// RC_Product_Menu
        /// </summary>
        public IDbSet<RC_Product_Menu> RC_Product_Menu { get; set; }

        /// <summary>
        /// RC_Product_Role
        /// </summary>
        public IDbSet<RC_Product_Role> RC_Product_Role { get; set; }

        /// <summary>
        /// RC_UserRole
        /// </summary>
        public IDbSet<RC_UserRole> RC_UserRole { get; set; }

        /// <summary>
        /// Sns_Comment
        /// </summary>
        public IDbSet<Sns_Comment> Sns_Comment { get; set; }

        /// <summary>
        /// Sns_Comment_Resouce
        /// </summary>
        public IDbSet<Sns_Comment_Resouce> Sns_Comment_Resouce { get; set; }
        /// <summary>
        /// XP_Folder_Tree
        /// </summary>
        public IDbSet<XP_Folder_Tree> XP_Folder_Tree { get; set; }
        /// <summary>
        /// XP_WebSite
        /// </summary>
        public IDbSet<XP_WebSite> XP_WebSite { get; set; }


        public IDbSet<PM_PageMark> PM_PageMark { get; set; }
        /// <summary>
        /// Ataw_PageLock
        /// </summary>
        public IDbSet<Ataw_PageLock> Ataw_PageLock { get; set; }

        /// <summary>
        /// ÓÃ»§×´Ì¬
        /// </summary>
        public IDbSet<Ataw_Users_State> Ataw_Users_State { get; set; }


        public RightCloudDBContext()
            : base(AtawAppContext.Current.DefaultConnString)
        {
        }

        public RightCloudDBContext(string connectionString) : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Configurations.Add(new Ataw_GruopMap());

            modelBuilder.Configurations.Add(new RC_UserRoleMap());

            modelBuilder.Configurations.Add(new RC_DepartmentMap());

            modelBuilder.Configurations.Add(new Ataw_MenusMap());

            modelBuilder.Configurations.Add(new Ataw_Menus_ButtonMap());

            modelBuilder.Configurations.Add(new Ataw_RightsMap());

            modelBuilder.Configurations.Add(new Ataw_Role_RightsMap());

            modelBuilder.Configurations.Add(new Ataw_UsersMap());

            modelBuilder.Configurations.Add(new Ataw_UsersDetailMap());

            modelBuilder.Configurations.Add(new Ataw_User_RolesMap());

            modelBuilder.Configurations.Add(new Ataw_RolesMap());

            modelBuilder.Configurations.Add(new Ataw_Menus_GroupMap());

            modelBuilder.Configurations.Add(new RC_Group_ProductMap());

            modelBuilder.Configurations.Add(new RC_Group_treeMap());

            modelBuilder.Configurations.Add(new RC_Menu_GroupMap());

            modelBuilder.Configurations.Add(new RC_Menu_RoleMap());

            modelBuilder.Configurations.Add(new RC_Menu_treeMap());

            modelBuilder.Configurations.Add(new RC_ProductMap());

            modelBuilder.Configurations.Add(new RC_Product_MenuMap());

            modelBuilder.Configurations.Add(new RC_Product_RoleMap());

            modelBuilder.Configurations.Add(new RC_RoleMap());

            modelBuilder.Configurations.Add(new Ataw_Comment_ResouceMap());

            modelBuilder.Configurations.Add(new Ataw_CommentMap());

            modelBuilder.Configurations.Add(new PM_PageMarkMap());

            modelBuilder.Configurations.Add(new XP_Folder_TreeMap());

            modelBuilder.Configurations.Add(new XP_WebSiteMap());

            modelBuilder.Configurations.Add(new Ataw_PageLockMap());

            modelBuilder.Configurations.Add(new Ataw_Users_StateMap());
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {

            modelBuilder.Configurations.Add(new Ataw_GruopMap(schema));

            modelBuilder.Configurations.Add(new RC_UserRoleMap(schema));

            modelBuilder.Configurations.Add(new RC_DepartmentMap(schema));

            modelBuilder.Configurations.Add(new Ataw_MenusMap(schema));

            modelBuilder.Configurations.Add(new Ataw_Menus_ButtonMap(schema));

            modelBuilder.Configurations.Add(new Ataw_RightsMap(schema));

            modelBuilder.Configurations.Add(new Ataw_Role_RightsMap(schema));

            modelBuilder.Configurations.Add(new Ataw_UsersMap(schema));

            modelBuilder.Configurations.Add(new Ataw_UsersDetailMap(schema));

            modelBuilder.Configurations.Add(new Ataw_User_RolesMap(schema));

            modelBuilder.Configurations.Add(new Ataw_RolesMap(schema));

            modelBuilder.Configurations.Add(new Ataw_Menus_GroupMap(schema));

            modelBuilder.Configurations.Add(new RC_Group_ProductMap(schema));

            modelBuilder.Configurations.Add(new RC_Group_treeMap(schema));

            modelBuilder.Configurations.Add(new RC_Menu_GroupMap(schema));

            modelBuilder.Configurations.Add(new RC_Menu_RoleMap(schema));

            modelBuilder.Configurations.Add(new RC_Menu_treeMap(schema));

            modelBuilder.Configurations.Add(new RC_ProductMap(schema));

            modelBuilder.Configurations.Add(new RC_Product_MenuMap(schema));

            modelBuilder.Configurations.Add(new RC_Product_RoleMap(schema));

            modelBuilder.Configurations.Add(new RC_RoleMap(schema));

            modelBuilder.Configurations.Add(new Ataw_Comment_ResouceMap(schema));

            modelBuilder.Configurations.Add(new Ataw_CommentMap(schema));
            
            modelBuilder.Configurations.Add(new PM_PageMarkMap(schema));

            modelBuilder.Configurations.Add(new XP_Folder_TreeMap(schema));

            modelBuilder.Configurations.Add(new XP_WebSiteMap(schema));

            modelBuilder.Configurations.Add(new Ataw_PageLockMap(schema));

            modelBuilder.Configurations.Add(new Ataw_Users_StateMap(schema));

            return modelBuilder;
        }
    }
}

