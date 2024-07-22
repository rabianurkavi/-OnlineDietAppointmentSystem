using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_update_message_property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Admins_AdminID",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Consultants_ConsultantID",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Admins_AdminID",
                table: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                table: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_AdminID",
                table: "Notifications",
                newName: "IX_Notifications_AdminID");

            migrationBuilder.RenameColumn(
                name: "ConsultantID",
                table: "Messages",
                newName: "SenderID");

            migrationBuilder.RenameColumn(
                name: "AdminID",
                table: "Messages",
                newName: "ReceiverID");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ConsultantID",
                table: "Messages",
                newName: "IX_Messages_SenderID");

            migrationBuilder.RenameIndex(
                name: "IX_Message_AdminID",
                table: "Messages",
                newName: "IX_Messages_ReceiverID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "NotificationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Clients_ReceiverID",
                table: "Messages",
                column: "ReceiverID",
                principalTable: "Clients",
                principalColumn: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Clients_SenderID",
                table: "Messages",
                column: "SenderID",
                principalTable: "Clients",
                principalColumn: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Admins_AdminID",
                table: "Notifications",
                column: "AdminID",
                principalTable: "Admins",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Clients_ReceiverID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Clients_SenderID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Admins_AdminID",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notification");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_AdminID",
                table: "Notification",
                newName: "IX_Notification_AdminID");

            migrationBuilder.RenameColumn(
                name: "SenderID",
                table: "Message",
                newName: "ConsultantID");

            migrationBuilder.RenameColumn(
                name: "ReceiverID",
                table: "Message",
                newName: "AdminID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderID",
                table: "Message",
                newName: "IX_Message_ConsultantID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ReceiverID",
                table: "Message",
                newName: "IX_Message_AdminID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                table: "Notification",
                column: "NotificationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Admins_AdminID",
                table: "Message",
                column: "AdminID",
                principalTable: "Admins",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Consultants_ConsultantID",
                table: "Message",
                column: "ConsultantID",
                principalTable: "Consultants",
                principalColumn: "ConsultantID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Admins_AdminID",
                table: "Notification",
                column: "AdminID",
                principalTable: "Admins",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
