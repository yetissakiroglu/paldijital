using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eticaret.UI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    bannerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: false),
                    detail = table.Column<string>(nullable: false),
                    imgPath = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    row = table.Column<int>(nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.bannerId);
                });

            migrationBuilder.CreateTable(
                name: "Broadcasts",
                columns: table => new
                {
                    broadcastId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    imgPath = table.Column<string>(nullable: true),
                    beginDate = table.Column<string>(nullable: true),
                    finishDate = table.Column<string>(nullable: true),
                    djId = table.Column<int>(nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broadcasts", x => x.broadcastId);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    ClaimId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.ClaimId);
                });

            migrationBuilder.CreateTable(
                name: "Djs",
                columns: table => new
                {
                    djId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    keywords = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    imgPath = table.Column<string>(nullable: true),
                    detail = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    fUrl = table.Column<string>(nullable: true),
                    tUrl = table.Column<string>(nullable: true),
                    iUrl = table.Column<string>(nullable: true),
                    yUrl = table.Column<string>(nullable: true),
                    spUrl = table.Column<string>(nullable: true),
                    sUrl = table.Column<string>(nullable: true),
                    row = table.Column<int>(nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Djs", x => x.djId);
                });

            migrationBuilder.CreateTable(
                name: "NewsCategories",
                columns: table => new
                {
                    categoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    keywords = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    imgPath = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    row = table.Column<int>(nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategories", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    programId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    keywords = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    detail = table.Column<string>(nullable: true),
                    infoDetail = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    imgPath = table.Column<string>(nullable: true),
                    djName = table.Column<string>(nullable: true),
                    row = table.Column<int>(nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.programId);
                });

            migrationBuilder.CreateTable(
                name: "RadioCategories",
                columns: table => new
                {
                    categoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    keywords = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    imgPath = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    row = table.Column<int>(nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadioCategories", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    settingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: false),
                    slogan = table.Column<string>(nullable: false),
                    keywords = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    logoPath = table.Column<string>(nullable: true),
                    footerLogoPath = table.Column<string>(nullable: true),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.settingId);
                });

            migrationBuilder.CreateTable(
                name: "TopMusicLists",
                columns: table => new
                {
                    topmusicListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    keywords = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    row = table.Column<int>(nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopMusicLists", x => x.topmusicListId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    LockoutEnd = table.Column<DateTime>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    RefreshToken = table.Column<string>(nullable: true),
                    RefreshTokenEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    newsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryId = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    keywords = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    shortDetail = table.Column<string>(nullable: true),
                    detail = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    imgPath = table.Column<string>(nullable: true),
                    addTime = table.Column<DateTime>(nullable: false),
                    updateTime = table.Column<DateTime>(nullable: false),
                    viewHit = table.Column<int>(nullable: false),
                    aM = table.Column<bool>(nullable: false),
                    oC = table.Column<bool>(nullable: false),
                    hB = table.Column<bool>(nullable: false),
                    sD = table.Column<bool>(nullable: false),
                    oH = table.Column<bool>(nullable: false),
                    row = table.Column<int>(nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.newsId);
                    table.ForeignKey(
                        name: "FK_News_NewsCategories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "NewsCategories",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastMusicLists",
                columns: table => new
                {
                    podcastMusicListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    programId = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    detail = table.Column<string>(nullable: true),
                    soundPath = table.Column<string>(nullable: true),
                    startingDate = table.Column<DateTime>(nullable: false),
                    row = table.Column<int>(nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastMusicLists", x => x.podcastMusicListId);
                    table.ForeignKey(
                        name: "FK_PodcastMusicLists_Programs_programId",
                        column: x => x.programId,
                        principalTable: "Programs",
                        principalColumn: "programId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Radios",
                columns: table => new
                {
                    radioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryId = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    slogan = table.Column<string>(nullable: true),
                    imgPath = table.Column<string>(nullable: true),
                    webUrl = table.Column<string>(nullable: true),
                    m3u8Url = table.Column<string>(nullable: true),
                    streamUrl = table.Column<string>(nullable: true),
                    row = table.Column<int>(nullable: false),
                    webstatus = table.Column<bool>(nullable: false),
                    mobilstatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radios", x => x.radioId);
                    table.ForeignKey(
                        name: "FK_Radios_RadioCategories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "RadioCategories",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    settingId = table.Column<int>(nullable: false),
                    icon = table.Column<string>(nullable: false),
                    url = table.Column<string>(nullable: false),
                    row = table.Column<int>(nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedias_Settings_settingId",
                        column: x => x.settingId,
                        principalTable: "Settings",
                        principalColumn: "settingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicLists",
                columns: table => new
                {
                    musicListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    topmusicListId = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    imgPath = table.Column<string>(nullable: true),
                    filePath = table.Column<string>(nullable: true),
                    songName = table.Column<string>(nullable: true),
                    singerName = table.Column<string>(nullable: true),
                    row = table.Column<int>(nullable: false),
                    rating = table.Column<int>(nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLists", x => x.musicListId);
                    table.ForeignKey(
                        name: "FK_MusicLists_TopMusicLists_topmusicListId",
                        column: x => x.topmusicListId,
                        principalTable: "TopMusicLists",
                        principalColumn: "topmusicListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "ClaimId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Frequencys",
                columns: table => new
                {
                    frequencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityName = table.Column<string>(nullable: true),
                    frequencyNo = table.Column<string>(nullable: true),
                    imgPath = table.Column<string>(nullable: true),
                    radioId = table.Column<int>(nullable: false),
                    row = table.Column<int>(nullable: false),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencys", x => x.frequencyId);
                    table.ForeignKey(
                        name: "FK_Frequencys_Radios_radioId",
                        column: x => x.radioId,
                        principalTable: "Radios",
                        principalColumn: "radioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsRadio",
                columns: table => new
                {
                    newsId = table.Column<int>(nullable: false),
                    radioId = table.Column<int>(nullable: false),
                    newsRadioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsRadio", x => new { x.newsId, x.radioId });
                    table.ForeignKey(
                        name: "FK_NewsRadio_News_newsId",
                        column: x => x.newsId,
                        principalTable: "News",
                        principalColumn: "newsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsRadio_Radios_radioId",
                        column: x => x.radioId,
                        principalTable: "Radios",
                        principalColumn: "radioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Frequencys_radioId",
                table: "Frequencys",
                column: "radioId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLists_topmusicListId",
                table: "MusicLists",
                column: "topmusicListId");

            migrationBuilder.CreateIndex(
                name: "IX_News_categoryId",
                table: "News",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsRadio_radioId",
                table: "NewsRadio",
                column: "radioId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastMusicLists_programId",
                table: "PodcastMusicLists",
                column: "programId");

            migrationBuilder.CreateIndex(
                name: "IX_Radios_categoryId",
                table: "Radios",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_settingId",
                table: "SocialMedias",
                column: "settingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_ClaimId",
                table: "UserClaims",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "Broadcasts");

            migrationBuilder.DropTable(
                name: "Djs");

            migrationBuilder.DropTable(
                name: "Frequencys");

            migrationBuilder.DropTable(
                name: "MusicLists");

            migrationBuilder.DropTable(
                name: "NewsRadio");

            migrationBuilder.DropTable(
                name: "PodcastMusicLists");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "TopMusicLists");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Radios");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "NewsCategories");

            migrationBuilder.DropTable(
                name: "RadioCategories");
        }
    }
}
