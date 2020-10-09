namespace RestaurantRaterAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRatingToRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "Rating");
        }
    }
}
