using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketSystem.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ticket_system_db");

            migrationBuilder.CreateTable(
                name: "agent",
                schema: "ticket_system_db",
                columns: table => new
                {
                    agent_id = table.Column<Guid>(nullable: false),
                    agent_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agent", x => x.agent_id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "ticket_system_db",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    user_type = table.Column<string>(nullable: true),
                    agent_id = table.Column<Guid>(nullable: false),
                    is_assigned = table.Column<bool>(nullable: false),
                    agent_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                });

            migrationBuilder.InsertData(
                schema: "ticket_system_db",
                table: "agent",
                columns: new[] { "agent_id", "agent_name" },
                values: new object[,]
                {
                    { new Guid("6ce2c411-1fc8-4f2f-9f8b-37a2ed025f55"), "Agent 2dc7f6a4-fc42-437b-83ac-3af6e8dcc06d" },
                    { new Guid("4d17bbb8-bf62-4761-a5ea-9cc98ad246d2"), "Agent f47a2f90-4d0f-4421-b30a-a3dadf7012ff" }
                });

            migrationBuilder.InsertData(
                schema: "ticket_system_db",
                table: "user",
                columns: new[] { "user_id", "agent_id", "agent_name", "email", "is_assigned", "user_type" },
                values: new object[,]
                {
                    { new Guid("9b9e810e-5416-4c70-bdf4-7e05b58babca"), new Guid("c0cb0301-33d8-42b1-9fd6-65a20270b3a9"), "Agent fcf539f6-263c-4ec7-a6d2-2b282f8546af", "a@gmail.com", true, "Customer" },
                    { new Guid("46636628-40e2-4412-821d-94bc9515a2f4"), new Guid("4bed90af-e737-4e11-8676-764a10d6e0be"), "Agent 4a0e769c-d3cc-4d17-8097-b30c25a25fb3", "b@gmail.com", true, "Customer" },
                    { new Guid("cd7f9700-c107-48a5-9079-ad289f71238b"), new Guid("d5c8bb39-1d25-45a0-b184-e5f6891c860f"), "Agent bb4f735e-a88b-426b-bfc3-9d98996762a1", "c@gmail.com", false, "Customer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agent",
                schema: "ticket_system_db");

            migrationBuilder.DropTable(
                name: "user",
                schema: "ticket_system_db");
        }
    }
}
