using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediCare.Infrastructure.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedEgyptLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "ArDescription", "ArName", "CreationTime", "CreatorUserId", "DeleteStatusId", "EnDescription", "EnName", "LastModificationTime", "LastModifierUserId" },
                values: new object[,]
                {
                    { 1, "", "القاهرة", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Cairo", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "", "الاسكندرية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Alexandria", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, "", "بورسعيد", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Port Said", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, "", "السويس", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Suez", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, "", "دمياط", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Damietta", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 12, "", "الدقهلية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Dakahlia", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 13, "", "الشرقية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Sharkia", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 14, "", "القليوبية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kalyoubia", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 15, "", "كفر الشيخ", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kafr El-Shikh", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 16, "", "الغربية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Gharbia", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 17, "", "المنوفية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Menoufia", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 18, "", "البحيرة", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Behera", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 19, "", "الإسماعيلية", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Ismailia", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 21, "", "الجيزة", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Giza", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 22, "", "بنى سويف", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Beni Suef", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 23, "", "الفيوم", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Fayoum", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 24, "", "المنيا", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Menia", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 25, "", "أسيوط", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Assiut", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 26, "", "سوهاج", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Suhag", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 27, "", "قنا", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qena", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 28, "", "أسوان", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Aswan", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 29, "", "مدينة الأقصر", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Luxor", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 31, "", "البحر الأحمر", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Red Sea", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 32, "", "الوادى الجديد", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "New Valley", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 33, "", "مطروح", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Matrouh", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 34, "", "شمال سيناء", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "North Sinai", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 35, "", "جنوب سيناء", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "South Sinai", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "AreaId", "ArDescription", "ArName", "CityId", "CreationTime", "CreatorUserId", "DeleteStatusId", "EnDescription", "EnName", "LastModificationTime", "LastModifierUserId" },
                values: new object[,]
                {
                    { 100, "", "خارج الزمام", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zemam Out", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 101, "", "قسم التبين", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Tibbin", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 102, "", "قسم حلوان", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Hilwan", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 103, "", "قسم 15 مايو", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "15 Mayu", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 104, "", "قسم المعادي", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Maadi", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 105, "", "قسم طره", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Tura", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 106, "", "مصرالقديمة", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Misr Al-Qadima", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 107, "", "قسم السيدة زينب", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Sayyida Zainab", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 108, "", "قسم الخليفة", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Khalifa", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 109, "", "قسم عابدين", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Abdin", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 110, "", "قسم الموسكي", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Muski", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 111, "", "قسم قصر النيل", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qasr Al-Nile", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 112, "", "قسم بولاق", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Bulaq", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 113, "", "قسم الأزبكية", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Azbakiyya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 114, "", "قسم الدرب الأحمر", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Darb al-Ahmar", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 115, "", "قسم الجمالية", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Gamaliyya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 116, "", "قسم باب الشعرية", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Bab Al-Shariyya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 117, "", "قسم الظاهر", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Zahir", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 118, "", "قسم الشرابية", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Sharabiyya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 119, "", "قسم شبرا", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Shubra", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 120, "", "قسم روضالفرج", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Rud Al-Farag", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 121, "", "قسم الساحل", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Sahil", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 122, "", "قسم الوايلي", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Wayli", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 123, "", "قسم حدائقالقبة", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Hadaiq Al-Qubba", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 124, "", "قسم الزيتون", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Zaytun", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 125, "", "قسم المطرية", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Matariyya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 126, "", "قسم أول مدينة نصر", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Nasr City", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 127, "", "قسم ثانمدينةنصر", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Madinat Nasr-2", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 128, "", "قسم مصرالجديدة", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Misr al-Gadida", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 129, "", "قسم النزهة", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Nuzha", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 130, "", "قسم عينشمس", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Ain Shams", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 131, "", "قسم الزاويةالحمراء", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zawiyya Al-Hamra", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 132, "", "قسم السلام", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Salam", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 133, "", "قسم الزمالك", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zamalik", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 134, "", "منشأةناصر", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Minshat Nasir", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 135, "", "قسم البساتين", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Basatin", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 136, "", "قسم المرج", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Marg", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 137, "", "قسم أول القاهرة الجديدة", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "New Cairo-1", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 138, "", "قسم ثان القاهرة الجديدة", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "New Cairo-2", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 139, "", "قسم ثالث القاهرة الجديدة", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "New Cairo-3", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 140, "", "قسم الشروق", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Shroq", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 141, "", "قسم بدر", 1, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Badr", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 200, "", "خارج الزمام", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zemam Out", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 201, "", "قسم المنتزة", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Muntazah", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 202, "", "قسم أول الرمل", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Raml", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 203, "", "قسم سيدى جابر", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Sidi Gabir", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 204, "", "قسم باب شرقى", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Bab Sharqi", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 205, "", "قسم محرم بك", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Muharam Bik", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 206, "", "قسم العطارين", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Attarin", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 207, "", "قسم المنشية", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Manshiyya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 208, "", "قسم كرموز", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Karmuz", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 209, "", "قسم اللبان", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "A L Labban", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 210, "", "قسم الجمرك", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Gumruk", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 211, "", "قسم مينا البصل", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Mina Al-Basal", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 212, "", "قسم الدخيلة", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Dikhila", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 213, "", "قسم العامرية", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Amreia", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 214, "", "قسم برج العرب", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Burg al-Arab", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 215, "", "اداره شرطه ميناء الأسكندريه", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Port Alexandria Police Department", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 216, "", "مدينه برج العرب الجديده", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Burg Al-Arab City", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 217, "", "قسم ثان الرمل", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kesm than Al Raml", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 218, "", "الساحل الشمالى", 2, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "North Coast", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 301, "", "قسم الشرق", 3, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Sharq", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 302, "", "قسم العرب", 3, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Arab", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 303, "", "قسم المناخ", 3, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Munakh", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 304, "", "قسم بور فؤاد", 3, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Port Fuad", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 305, "", "قسم الضواحى", 3, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Dawahy", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 306, "", "قسم الجنوب", 3, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Ganoub", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 307, "", "قسم الزهور", 3, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Zohour", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 308, "", "قسم ثان بور فؤاد", 3, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Port Fuad 2", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 309, "", "قسم مبارك - شرق التفريعة", 3, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Mubark-Sharq Tafrea", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 310, "", "قسم المناصرة", 3, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Manasra", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 311, "", "قسم ثان الجنوب", 3, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Ganoub 2", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 312, "", "إدارة شرطة ميناء بورسعيد", 3, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Police Department Port Said Port", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 401, "", "قسم السويس", 4, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Suez", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 402, "", "قسم الأربعين", 4, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Arbiin", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 403, "", "قسم عتاقة", 4, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Ataqa", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 404, "", "قسم فيصل", 4, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Faysal", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 405, "", "قسم الجناين", 4, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Ganayin", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 406, "", "إدارة شرطة ميناء السويس", 4, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Port Suez Police Department", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1101, "", "قسم أول دمياط", 11, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Dumyat 1", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1102, "", "مركز دمياط", 11, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Dumyat", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1103, "", "مركز فارسكور", 11, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Fariskur", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1104, "", "مركز كفر سعد", 11, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kafr Sad", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1105, "", "قسم مدينه دمياط الجديده", 11, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Dumyat Al-Gadida", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1106, "", "قسم رأس البر", 11, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Ras al-Bar", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1107, "", "مركز الزرقا", 11, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zarqa", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1108, "", "إداره شرطه ميناء دمياط الجديد", 11, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Police Department Port of Damietta", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1109, "", "قسم ثان دمياط", 11, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Dumyat 2", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1201, "", "قسم اول المنصورة", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "El Mansora 1", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1202, "", "قسم ثان المنصورة", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "E Mansora 2", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1203, "", "مركز المنصورة", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "El Mansora", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1204, "", "مركز أجا", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Aga", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1205, "", "مركز السنبلاوين", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Sinbillawin", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1206, "", "مركز المطرية", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Matariyya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1207, "", "مركز المنزلة", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Manzala", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1208, "", "مركز بلقاس", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Bilqas", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1209, "", "مركز دكرنس", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Dikirnis", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1210, "", "مركز شربين", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Shirbin", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1211, "", "مركز طلخا", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Talkha", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1212, "", "قسم ميت غمر", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Mit Ghamr", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1213, "", "مركز ميت غمر", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Mit Ghamr", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1214, "", "مركز منية النصر", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Minya Al-Nasr", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1215, "", "مركز الجمالية", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Gamaliyya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1216, "", "مركز تمى الأمديد", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Tamy Al-Amdid", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1217, "", "مركز ميت سلسيل", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "MIt Salsil", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1218, "", "مركز بنى عبيد", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Bany Abeed", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1219, "", "مركز محلة دمنة", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Mahalet Demna", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1220, "", "قسم جمصة", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Gamsa", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1221, "", "مركز نبروة", 12, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Nebro", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1300, "", "خارج الزمام", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zemam Out", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1301, "", "قسم اول الزقازيق", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zaqaziq 1", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1302, "", "قسم ثان الزقازيق", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zaqaziq 2", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1303, "", "مركز الزقازيق", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zaqaziq", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1304, "", "مركز أبو حماد", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Abu Hammad", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1305, "", "مركز أبوكبير", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Abu Kabir", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1306, "", "مركز الحسينية", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Husayniya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1307, "", "قسم الصالحية الجديدة", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Salhiyya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1308, "", "مركز بلبيس", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Bilbis", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1309, "", "قسم اول مدينة العاشر من رمضان", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "10 Ramadan 1", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1310, "", "مركز ديرب نجم", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Dyarb Nigm", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1311, "", "قسم فاقوس", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Faqus", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1312, "", "مركز فاقوس", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Faqus", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1313, "", "مركز كفر صقر", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kafr Saqr", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1314, "", "مركز منيا القمح", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Minya al-Qamh", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1315, "", "مركز ههيا", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Hihya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1316, "", "مركز مشتول السوق", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Mashtul Al-Suq", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1317, "", "مركز الأبراهيمية", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "El-Ibrahimiya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1318, "", "قسم القنايات", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Qanayat", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1319, "", "مركز أولاد صقر", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Awlad Saqr", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1320, "", "قسم القرين", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qurin", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1321, "", "قسم ثان مدينه العاشر من رمضان", 13, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "10 Ramadan 2", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1400, "", "خارج الزمام", 14, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zemam Out", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1401, "", "قسم بنها", 14, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Banha", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1402, "", "مركز بنها", 14, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Banha", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1403, "", "مركز الخانكة", 14, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Khanka", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1404, "", "مركز القناطر الخيرية", 14, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qanatir Al-Khayriyya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1405, "", "مركز شبين القناطر", 14, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Shibin al-Qanatir", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1406, "", "قسم أول شبرا الخيمة", 14, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Shubra Al-Khayma 1", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1407, "", "قسم ثان شبرا الخيمة", 14, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Shubra Al-Khayma 2", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1408, "", "مركز طوخ", 14, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Tukh", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1409, "", "قسم قليوب", 14, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qalyub", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1410, "", "مركز قليوب", 14, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qalyub", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1411, "", "مركز كفر شكر", 14, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kafr Shukr", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1412, "", "قسم الخصوص", 14, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Khsos", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1413, "", "قسم العبور", 14, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Abour", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1414, "", "قسم قها", 14, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qaha", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1501, "", "قسم كفر الشيخ", 15, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kafr Al-Shaykh", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1502, "", "مركز كفر الشيخ", 15, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kafr Al-Shaykh", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1503, "", "مركز البرلس", 15, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Burullus", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1504, "", "مركز بيلا", 15, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Biyalu", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1505, "", "قسم دسوق", 15, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Disuq", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1506, "", "مركز دسوق", 15, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Disuq", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1507, "", "مركز سيدى سالم", 15, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Sidi Salim", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1508, "", "مركز فوه", 15, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Fuwwa", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1509, "", "مركز قلين", 15, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qillin", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1510, "", "مركز مطوبس", 15, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Mitubas", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1511, "", "مركز الحامول", 15, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Hamul", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1512, "", "مركز الرياض", 15, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Riyad", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1601, "", "قسم أول طنطا", 16, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Tanta 1", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1602, "", "قسم ثان طنطا", 16, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Tanta 2", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1603, "", "مركز طنطا", 16, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Tanta", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1604, "", "مركز السنطة", 16, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Santa", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1605, "", "قسم أول المحلة الكبرى", 16, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "El Mahalla El Kobra 1", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1606, "", "قسم ثان المحلة الكبرى", 16, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "El Mahalla El Kobra 2", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1607, "", "مركز المحله الكبرى", 16, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "El Mahalla El Kobra", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1608, "", "مركز بسيون", 16, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Basyun", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1609, "", "مركز زفتى", 16, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zifta", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1610, "", "مركز سمنود", 16, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Samannud", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1611, "", "مركز قطور", 16, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qutur", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1612, "", "مركز كفر الزيات", 16, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kafr Al-Zayyat", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1701, "", "قسم شبين الكوم", 17, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Shibin al-Kum", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1702, "", "مركز شبين الكوم", 17, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Shibin al-Kum", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1703, "", "مركز أشمون", 17, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Ashmun", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1704, "", "مركز الباجور", 17, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Bagur", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1705, "", "مركز الشهداء", 17, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Shuhada", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1706, "", "مركز بركة السبع", 17, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Birkat Al-Sab", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1707, "", "مركز تلا", 17, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Tala", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1708, "", "مركز قويسنا", 17, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Quwisna", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1709, "", "مركز منوف", 17, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Minuf", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1710, "", "قسم مدينة سرس الليانة", 17, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Sirs Al-Layyana City", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1711, "", "مركز السادات", 17, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Sadat City", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1712, "", "قسم مدينة منوف", 17, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Minuf City", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1800, "", "خارج الزمام", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zemam Out", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1801, "", "قسم دمنهور", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Damanhur", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1802, "", "مركز دمنهور", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Damanhur", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1803, "", "مركز ابوالمطامير", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Abu-l-Matamir", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1804, "", "مركز ابوحمص", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Abu Hummus", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1805, "", "مركز الدلنجات", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Dilingat", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1806, "", "مركز المحمودية", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Mahmudiyya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1807, "", "مركز إيتاى البارود", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Itay Al-Barud", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1808, "", "مركز حوش عيسى", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Hush Isa", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1809, "", "مركز رشيد", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Rashid", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1810, "", "مركز شبراخيت", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Shubra Khit", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1811, "", "قسم كفرالدوار", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kafr Al-Dawwar", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1812, "", "مركز كفر الدوار", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kafr Al-Dawwar", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1813, "", "مركز كوم حمادة", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kum Hamada", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1814, "", "مركز وادى النطرون", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Wadi Al-NatrUn", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1815, "", "مركز الرحمانية", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Rahmaniyya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1816, "", "مركز إدكو", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Idku", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1817, "", "قسم غرب النوبارية", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Nubariyya West", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1818, "", "مركز بدر", 18, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Badr", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1901, "", "قسم أول الاسماعيلية", 19, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Ismailiyya 1", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1902, "", "قسم ثان الاسماعيلية", 19, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Ismailiyya 2", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1903, "", "قسم ثالث الاسماعيلية", 19, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Ismailiyya 3", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1904, "", "مركز الاسماعيلية", 19, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Ismailiyya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1905, "", "مركز التل الكبير", 19, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Tal al-Kabir, al-", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1906, "", "مركز القنطرة", 19, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qantara Gharb, al-", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1907, "", "مركز فايد", 19, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Fayid", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1908, "", "قسم القنطرة شرق", 19, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qantara Sharq, al-", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2100, "", "خارج الزمام", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zemam Out", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2101, "", "قسم امبابه", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Imbaba", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2102, "", "قسم العجوزة", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Aguza", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2103, "", "قسم الدقي", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "DuqqI", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2104, "", "قسم الجيزة", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Giza", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2105, "", "قسم بولاق الدكرور", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Bulaq Al-DakrUr", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2106, "", "قسم الأهرام", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Ahram", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2107, "", "قسم أول 6 أكتوبر", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "6 October-1", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2108, "", "قسم الحوامدية", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Hwamdeia", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2109, "", "مركز الجيزة", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Giza", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2110, "", "مركز البدرشين", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Badrashain", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2111, "", "مركز الصف", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Saf", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2112, "", "مركز العياط", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Ayat", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2113, "", "مركز إمبابة", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Imbaba", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2114, "", "قسم الواحاتالبحرية", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Bahariya Oasis", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2115, "", "مركز أطفيح", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Atfeh", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2116, "", "مركز أوسيم", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Auseem", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2117, "", "قسم الوراق", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Waraq", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2118, "", "قسم العمرانية", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Umraniyya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2119, "", "قسم الشيخ زايد", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Shaykh Zayed", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2120, "", "مركز كرداسة", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kardasa", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2121, "", "قسم ثان 6 أكتوبر", 21, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "6 October-2", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2200, "", "خارج الزمام", 22, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zemam Out", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2201, "", "قسم بنى سويف", 22, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Bani Swayf", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2202, "", "مركز بنى سويف", 22, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Bani Swayf", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2203, "", "قسم مدينة بنى سويف الجديدة", 22, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Bani Swayf City", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2204, "", "مركز الفشن", 22, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Fashn", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2205, "", "مركز الواسطى", 22, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Wasta", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2206, "", "مركز أهناسيا", 22, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Ahnasya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2207, "", "مركز ببا", 22, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Biba", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2208, "", "مركز سمسطا", 22, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Sumusta", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2209, "", "مركز ناصر", 22, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Nasir", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2300, "", "خارج الزمام", 23, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zemam Out", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2301, "", "قسم الفيوم", 23, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Fayyum", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2302, "", "مركز الفيوم", 23, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Fayyum", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2303, "", "مركز أبشواى", 23, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Abshaway", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2304, "", "مركز أطسا", 23, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Atsa", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2305, "", "مركز سنورس", 23, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Sinuras", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2306, "", "مركز طامية", 23, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Tamya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2307, "", "مركز يوسف الصديق", 23, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Yousef El sadeq", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2308, "", "مدينة الفيوم الجديدة", 23, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Fayyum City", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2400, "", "خارج الزمام", 24, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zemam Out", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2401, "", "قسم المنيا", 24, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kesm Al-minya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2402, "", "مركز المنيا", 24, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Markz Al Minya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2403, "", "مدينة المنيا الجديدة", 24, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "New Minya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2404, "", "مركز ابو قرقاص", 24, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Markz Abu Qurqas", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2405, "", "مركز العدوة", 24, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Markz Al Idwa", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2406, "", "مركز بنى مزار", 24, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Markz Bani Mazar", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2407, "", "مركز دير مواس", 24, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Markz Dir Mawas", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2408, "", "مركز سمالوط", 24, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Markz Samalut", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2409, "", "مركز مطاى", 24, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Markz Matay", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2410, "", "مركز مغاغة", 24, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Markz Maghagha", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2411, "", "قسم ملوى", 24, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kesm Mallawi", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2412, "", "مركز ملوى", 24, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Markz Mallawi", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2500, "", "صحراء أسيوط", 25, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zemam Out", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2501, "", "قسم أول أسيوط", 25, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kesm Awal Assuit", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2502, "", "قسم ثان أسيوط", 25, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kesm Than Assuit", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2503, "", "مركز أسيوط", 25, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Assuit", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2504, "", "مركز أبنوب", 25, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Abnub", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2505, "", "مركز أبوتيج", 25, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Abu Tig", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2506, "", "مركز البدارى", 25, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al- Badari", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2507, "", "مركز ساحل سليم", 25, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Sahil Silim", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2508, "", "مركز الغنايم", 25, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Ghanayem", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2509, "", "مركز القوصية", 25, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Qusia", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2510, "", "مركز ديروط", 25, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Dayrut", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2511, "", "مركز صدفا", 25, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Sidfa", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2512, "", "مركز منفلوط", 25, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Manfalut", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2513, "", "مركز الفتح", 25, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Alfath", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2514, "", "مدينة اسيوط الجديدة", 25, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Assuit City", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2600, "", "صحراء سوهاج", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zemam Out", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2601, "", "قسم اول سوهاج", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Suhag", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2602, "", "قسم ثان سوهاج", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Suhag-2", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2603, "", "مركز سوهاج", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Suhag", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2604, "", "مركز أخميم", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Akhmim", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2605, "", "مركز البلينا", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Balyana", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2606, "", "مركز المراغة", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Maragha", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2607, "", "مركز المنشأة", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Minshat", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2608, "", "مركز دار السلام", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Dar al-Salam", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2609, "", "قسم جرجا", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Girga", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2610, "", "مركز جرجا", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Girga", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2611, "", "مركز جهينة الغربية", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Guhayna Al-Gharbiyya", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2612, "", "مركز ساقلته", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Saqulta", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2613, "", "مركز طما", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Tama", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2614, "", "مركز طهطا", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Tahta", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2615, "", "قسم طهطا", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kesm Tahta", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2616, "", "قسم الكوثر", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kawther", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2617, "", "مركز العسيرات", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Usayrat", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2618, "", "مدينة أخميم الجديدة", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Akhmim City", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2619, "", "مدينة سوهاج الجديدة", 26, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Suhag City", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2700, "", "صحراء قنا", 27, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zemam Out", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2701, "", "قسم قنا", 27, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qina", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2702, "", "مركز قنا", 27, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qina", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2703, "", "مركز أبو طشت", 27, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Abu Tisht", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2704, "", "مركز أرمنت", 27, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Armant", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2705, "", "مركز إسنا", 27, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Isna", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2706, "", "مركز دشنا", 27, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Dishna", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2707, "", "مركز قوص", 27, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qus", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2708, "", "مركز نجع حمادى", 27, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Nag Hammadi", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2709, "", "مركز نقادة", 27, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Naqada", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2710, "", "مركز فرشوط", 27, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Farshut", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2711, "", "مركز قفط", 27, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qift", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2712, "", "مركز الوقف", 27, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Waqf", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2713, "", "مدينة قنا الجديدة", 27, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qina City", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2800, "", "خارج الزمام", 28, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zemam Out", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2801, "", "قسم أسوان", 28, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Aswan", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2802, "", "مركز أسوان", 28, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Aswan", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2803, "", "مركز أدفو", 28, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Adfu", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2804, "", "مركز كوم امبو", 28, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Kum Umbu", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2805, "", "مركز نصر", 28, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Nasr", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2806, "", "مركز دراو", 28, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Daraw", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2807, "", "مركز أبوسنبل", 28, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Abu Simbel", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2808, "", "مدينة أسوان الجديدة", 28, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Aswan City", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2809, "", "مدينة توشكى الجديدة", 28, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Tushaka", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2900, "", "خارج الزمام", 29, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Zemam Out", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2901, "", "قسم الأقصر", 29, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Luxor", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2902, "", "مركز الأقصر", 29, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Luxor", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2903, "", "مركز شرطة طيبة", 29, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Tiba police station", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3101, "", "قسم أول الغردقة", 31, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Hurghada 1", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3102, "", "قسم القصير", 31, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qusir", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3103, "", "قسم سفاجا", 31, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Safaga", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3104, "", "قسم مرسى علم", 31, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Marsa Alam", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3105, "", "قسم رأس غارب", 31, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Ras Gharib", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3106, "", "قسم شلاتين", 31, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Shallatin", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3107, "", "قسم حلايب", 31, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Halayib", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3108, "", "قسم ثان الغردقة", 31, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Hurghada 2", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3201, "", "مركز الواحات الخارجة", 32, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Kharga Oasis", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3202, "", "مركز الوحات الداخلة", 32, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "A-Dakhla Oasis", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3203, "", "مركز الفرافرة", 32, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al Farafra Oasis", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3204, "", "مركز باريس", 32, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Paris Paris", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3301, "", "قسم مرسى مطروح", 33, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Marsa Matruh", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3302, "", "قسم الحمام", 33, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Hammam", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3303, "", "قسم السلوم", 33, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Salloum", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3304, "", "مركز الضبعة", 33, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Daba", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3305, "", "قسم سيدى برانى", 33, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Sidi Barani", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3306, "", "مركز سيوة", 33, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Siwa", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3307, "", "قسم مارينا العلمين السياحية", 33, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Alamn", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3308, "", "قسم الساحل الشمالى-جزء", 33, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "North Coast", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3401, "", "قسم أول العريش", 34, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "El Arish 1", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3402, "", "قسم ثان العريش", 34, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "El Arish 2", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3403, "", "قسم ثالث العريش", 34, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "El Arish 3", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3404, "", "قسم رابع العريش", 34, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "El Arish 4", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3405, "", "قسم بئر العبد", 34, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Bir Al-Abd", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3406, "", "قسم الحسنة", 34, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Hasna", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3407, "", "قسم نخل", 34, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Nakhl", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3408, "", "قسم الشيخ زويد", 34, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Shaykh Zuwayd", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3409, "", "قسم رفح", 34, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Rafah", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3410, "", "قسم رمانة", 34, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Rummana", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3411, "", "قسم القسيمة", 34, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Qasima", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3501, "", "قسم الطور", 35, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Al-Tur", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3502, "", "قسم رأس سدر", 35, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Ras Sidr", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3503, "", "قسم أبو رديس", 35, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Abu Radis", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3504, "", "قسم سانت كاترين", 35, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Sant Katrin", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3505, "", "قسم شرم الشيخ", 35, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Sharm el-Sheikh", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3506, "", "قسم دهب", 35, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Dahab", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3507, "", "قسم نويبع", 35, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Nuweiba", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3508, "", "قسم طابا", 35, new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Taba", new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1101);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1102);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1103);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1104);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1105);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1106);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1107);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1108);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1109);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1201);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1202);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1203);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1204);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1205);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1206);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1207);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1208);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1209);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1210);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1211);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1212);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1213);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1214);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1215);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1216);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1217);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1218);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1219);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1220);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1221);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1300);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1301);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1302);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1303);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1304);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1305);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1306);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1307);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1308);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1309);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1310);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1311);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1312);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1313);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1314);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1315);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1316);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1317);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1318);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1319);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1320);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1321);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1400);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1401);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1402);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1403);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1404);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1405);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1406);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1407);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1408);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1409);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1410);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1411);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1412);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1413);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1414);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1501);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1502);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1503);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1504);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1505);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1506);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1507);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1508);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1509);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1510);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1511);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1512);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1601);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1602);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1603);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1604);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1605);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1606);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1607);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1608);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1609);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1610);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1611);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1612);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1701);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1702);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1703);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1704);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1705);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1706);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1707);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1708);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1709);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1710);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1711);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1712);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1800);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1801);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1802);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1803);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1804);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1805);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1806);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1807);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1808);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1809);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1810);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1811);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1812);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1813);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1814);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1815);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1816);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1817);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1818);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1901);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1902);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1903);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1904);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1905);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1906);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1907);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1908);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2100);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2101);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2102);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2103);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2104);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2105);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2106);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2107);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2108);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2109);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2110);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2111);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2112);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2113);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2114);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2115);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2116);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2117);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2118);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2119);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2120);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2121);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2200);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2201);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2202);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2203);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2204);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2205);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2206);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2207);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2208);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2209);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2300);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2301);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2302);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2303);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2304);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2305);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2306);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2307);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2308);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2400);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2401);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2402);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2403);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2404);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2405);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2406);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2407);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2408);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2409);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2410);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2411);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2412);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2500);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2501);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2502);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2503);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2504);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2505);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2506);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2507);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2508);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2509);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2510);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2511);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2512);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2513);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2514);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2600);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2601);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2602);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2603);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2604);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2605);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2606);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2607);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2608);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2609);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2610);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2611);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2612);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2613);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2614);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2615);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2616);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2617);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2618);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2619);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2700);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2701);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2702);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2703);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2704);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2705);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2706);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2707);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2708);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2709);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2710);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2711);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2712);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2713);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2800);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2801);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2802);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2803);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2804);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2805);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2806);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2807);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2808);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2809);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2900);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2901);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2902);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2903);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3101);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3102);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3103);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3104);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3105);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3106);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3107);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3108);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3201);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3202);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3203);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3204);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3301);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3302);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3303);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3304);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3305);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3306);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3307);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3308);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3401);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3402);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3403);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3404);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3405);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3406);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3407);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3408);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3409);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3410);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3411);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3501);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3502);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3503);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3504);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3505);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3506);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3507);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3508);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 35);
        }
    }
}
