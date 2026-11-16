// Source: Open Admin Data - Egypt Administrative Divisions (CC BY 4.0)
// https://github.com/open-admin-data/egypt-administrative-divisions

using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Infrastructure.Repository.Seed;

public static class DataSeeding
{
    private static readonly DateTime SeedDate = new(2025, 12, 27);

    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>().HasData(GetCities());
        modelBuilder.Entity<Area>().HasData(GetAreas());
    }

    private static City[] GetCities()
    {
        return
        [
            new City
            {
                CityId = 1,
                EnName = "Cairo",
                ArName = "القاهرة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 2,
                EnName = "Alexandria",
                ArName = "الاسكندرية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 3,
                EnName = "Port Said",
                ArName = "بورسعيد",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 4,
                EnName = "Suez",
                ArName = "السويس",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 11,
                EnName = "Damietta",
                ArName = "دمياط",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 12,
                EnName = "Dakahlia",
                ArName = "الدقهلية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 13,
                EnName = "Sharkia",
                ArName = "الشرقية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 14,
                EnName = "Kalyoubia",
                ArName = "القليوبية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 15,
                EnName = "Kafr El-Shikh",
                ArName = "كفر الشيخ",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 16,
                EnName = "Gharbia",
                ArName = "الغربية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 17,
                EnName = "Menoufia",
                ArName = "المنوفية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 18,
                EnName = "Behera",
                ArName = "البحيرة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 19,
                EnName = "Ismailia",
                ArName = "الإسماعيلية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 21,
                EnName = "Giza",
                ArName = "الجيزة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 22,
                EnName = "Beni Suef",
                ArName = "بنى سويف",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 23,
                EnName = "Fayoum",
                ArName = "الفيوم",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 24,
                EnName = "Menia",
                ArName = "المنيا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 25,
                EnName = "Assiut",
                ArName = "أسيوط",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 26,
                EnName = "Suhag",
                ArName = "سوهاج",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 27,
                EnName = "Qena",
                ArName = "قنا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 28,
                EnName = "Aswan",
                ArName = "أسوان",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 29,
                EnName = "Luxor",
                ArName = "مدينة الأقصر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 31,
                EnName = "Red Sea",
                ArName = "البحر الأحمر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 32,
                EnName = "New Valley",
                ArName = "الوادى الجديد",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 33,
                EnName = "Matrouh",
                ArName = "مطروح",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 34,
                EnName = "North Sinai",
                ArName = "شمال سيناء",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new City
            {
                CityId = 35,
                EnName = "South Sinai",
                ArName = "جنوب سيناء",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
        ];
    }

    private static Area[] GetAreas()
    {
        return
        [
            new Area
            {
                AreaId = 100,
                CityId = 1,
                EnName = "Zemam Out",
                ArName = "خارج الزمام",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 101,
                CityId = 1,
                EnName = "Al Tibbin",
                ArName = "قسم التبين",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 102,
                CityId = 1,
                EnName = "Hilwan",
                ArName = "قسم حلوان",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 103,
                CityId = 1,
                EnName = "15 Mayu",
                ArName = "قسم 15 مايو",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 104,
                CityId = 1,
                EnName = "Maadi",
                ArName = "قسم المعادي",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 105,
                CityId = 1,
                EnName = "Tura",
                ArName = "قسم طره",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 106,
                CityId = 1,
                EnName = "Misr Al-Qadima",
                ArName = "مصرالقديمة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 107,
                CityId = 1,
                EnName = "Sayyida Zainab",
                ArName = "قسم السيدة زينب",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 108,
                CityId = 1,
                EnName = "Al Khalifa",
                ArName = "قسم الخليفة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 109,
                CityId = 1,
                EnName = "Abdin",
                ArName = "قسم عابدين",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 110,
                CityId = 1,
                EnName = "Muski",
                ArName = "قسم الموسكي",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 111,
                CityId = 1,
                EnName = "Qasr Al-Nile",
                ArName = "قسم قصر النيل",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 112,
                CityId = 1,
                EnName = "Bulaq",
                ArName = "قسم بولاق",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 113,
                CityId = 1,
                EnName = "Al Azbakiyya",
                ArName = "قسم الأزبكية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 114,
                CityId = 1,
                EnName = "Al Darb al-Ahmar",
                ArName = "قسم الدرب الأحمر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 115,
                CityId = 1,
                EnName = "Gamaliyya",
                ArName = "قسم الجمالية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 116,
                CityId = 1,
                EnName = "Bab Al-Shariyya",
                ArName = "قسم باب الشعرية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 117,
                CityId = 1,
                EnName = "Al Zahir",
                ArName = "قسم الظاهر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 118,
                CityId = 1,
                EnName = "Al Sharabiyya",
                ArName = "قسم الشرابية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 119,
                CityId = 1,
                EnName = "Shubra",
                ArName = "قسم شبرا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 120,
                CityId = 1,
                EnName = "Rud Al-Farag",
                ArName = "قسم روضالفرج",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 121,
                CityId = 1,
                EnName = "Al Sahil",
                ArName = "قسم الساحل",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 122,
                CityId = 1,
                EnName = "Al Wayli",
                ArName = "قسم الوايلي",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 123,
                CityId = 1,
                EnName = "Hadaiq Al-Qubba",
                ArName = "قسم حدائقالقبة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 124,
                CityId = 1,
                EnName = "Al Zaytun",
                ArName = "قسم الزيتون",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 125,
                CityId = 1,
                EnName = "Al Matariyya",
                ArName = "قسم المطرية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 126,
                CityId = 1,
                EnName = "Nasr City",
                ArName = "قسم أول مدينة نصر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 127,
                CityId = 1,
                EnName = "Madinat Nasr-2",
                ArName = "قسم ثانمدينةنصر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 128,
                CityId = 1,
                EnName = "Misr al-Gadida",
                ArName = "قسم مصرالجديدة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 129,
                CityId = 1,
                EnName = "Nuzha",
                ArName = "قسم النزهة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 130,
                CityId = 1,
                EnName = "Ain Shams",
                ArName = "قسم عينشمس",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 131,
                CityId = 1,
                EnName = "Zawiyya Al-Hamra",
                ArName = "قسم الزاويةالحمراء",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 132,
                CityId = 1,
                EnName = "Al Salam",
                ArName = "قسم السلام",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 133,
                CityId = 1,
                EnName = "Zamalik",
                ArName = "قسم الزمالك",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 134,
                CityId = 1,
                EnName = "Minshat Nasir",
                ArName = "منشأةناصر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 135,
                CityId = 1,
                EnName = "Basatin",
                ArName = "قسم البساتين",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 136,
                CityId = 1,
                EnName = "Marg",
                ArName = "قسم المرج",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 137,
                CityId = 1,
                EnName = "New Cairo-1",
                ArName = "قسم أول القاهرة الجديدة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 138,
                CityId = 1,
                EnName = "New Cairo-2",
                ArName = "قسم ثان القاهرة الجديدة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 139,
                CityId = 1,
                EnName = "New Cairo-3",
                ArName = "قسم ثالث القاهرة الجديدة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 140,
                CityId = 1,
                EnName = "Shroq",
                ArName = "قسم الشروق",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 141,
                CityId = 1,
                EnName = "Badr",
                ArName = "قسم بدر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 200,
                CityId = 2,
                EnName = "Zemam Out",
                ArName = "خارج الزمام",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 201,
                CityId = 2,
                EnName = "Muntazah",
                ArName = "قسم المنتزة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 202,
                CityId = 2,
                EnName = "Al Raml",
                ArName = "قسم أول الرمل",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 203,
                CityId = 2,
                EnName = "Sidi Gabir",
                ArName = "قسم سيدى جابر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 204,
                CityId = 2,
                EnName = "Bab Sharqi",
                ArName = "قسم باب شرقى",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 205,
                CityId = 2,
                EnName = "Muharam Bik",
                ArName = "قسم محرم بك",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 206,
                CityId = 2,
                EnName = "Al Attarin",
                ArName = "قسم العطارين",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 207,
                CityId = 2,
                EnName = "Al Manshiyya",
                ArName = "قسم المنشية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 208,
                CityId = 2,
                EnName = "Karmuz",
                ArName = "قسم كرموز",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 209,
                CityId = 2,
                EnName = "A L Labban",
                ArName = "قسم اللبان",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 210,
                CityId = 2,
                EnName = "Al Gumruk",
                ArName = "قسم الجمرك",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 211,
                CityId = 2,
                EnName = "Mina Al-Basal",
                ArName = "قسم مينا البصل",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 212,
                CityId = 2,
                EnName = "Al Dikhila",
                ArName = "قسم الدخيلة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 213,
                CityId = 2,
                EnName = "Al Amreia",
                ArName = "قسم العامرية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 214,
                CityId = 2,
                EnName = "Burg al-Arab",
                ArName = "قسم برج العرب",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 215,
                CityId = 2,
                EnName = "Port Alexandria Police Department",
                ArName = "اداره شرطه ميناء الأسكندريه",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 216,
                CityId = 2,
                EnName = "Burg Al-Arab City",
                ArName = "مدينه برج العرب الجديده",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 217,
                CityId = 2,
                EnName = "Kesm than Al Raml",
                ArName = "قسم ثان الرمل",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 218,
                CityId = 2,
                EnName = "North Coast",
                ArName = "الساحل الشمالى",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 301,
                CityId = 3,
                EnName = "Al-Sharq",
                ArName = "قسم الشرق",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 302,
                CityId = 3,
                EnName = "Al-Arab",
                ArName = "قسم العرب",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 303,
                CityId = 3,
                EnName = "Al-Munakh",
                ArName = "قسم المناخ",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 304,
                CityId = 3,
                EnName = "Port Fuad",
                ArName = "قسم بور فؤاد",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 305,
                CityId = 3,
                EnName = "Al-Dawahy",
                ArName = "قسم الضواحى",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 306,
                CityId = 3,
                EnName = "Al-Ganoub",
                ArName = "قسم الجنوب",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 307,
                CityId = 3,
                EnName = "Al-Zohour",
                ArName = "قسم الزهور",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 308,
                CityId = 3,
                EnName = "Port Fuad 2",
                ArName = "قسم ثان بور فؤاد",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 309,
                CityId = 3,
                EnName = "Mubark-Sharq Tafrea",
                ArName = "قسم مبارك - شرق التفريعة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 310,
                CityId = 3,
                EnName = "Al-Manasra",
                ArName = "قسم المناصرة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 311,
                CityId = 3,
                EnName = "Al-Ganoub 2",
                ArName = "قسم ثان الجنوب",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 312,
                CityId = 3,
                EnName = "Police Department Port Said Port",
                ArName = "إدارة شرطة ميناء بورسعيد",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 401,
                CityId = 4,
                EnName = "Suez",
                ArName = "قسم السويس",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 402,
                CityId = 4,
                EnName = "Al-Arbiin",
                ArName = "قسم الأربعين",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 403,
                CityId = 4,
                EnName = "Ataqa",
                ArName = "قسم عتاقة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 404,
                CityId = 4,
                EnName = "Faysal",
                ArName = "قسم فيصل",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 405,
                CityId = 4,
                EnName = "Al-Ganayin",
                ArName = "قسم الجناين",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 406,
                CityId = 4,
                EnName = "Port Suez Police Department",
                ArName = "إدارة شرطة ميناء السويس",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1101,
                CityId = 11,
                EnName = "Dumyat 1",
                ArName = "قسم أول دمياط",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1102,
                CityId = 11,
                EnName = "Dumyat",
                ArName = "مركز دمياط",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1103,
                CityId = 11,
                EnName = "Fariskur",
                ArName = "مركز فارسكور",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1104,
                CityId = 11,
                EnName = "Kafr Sad",
                ArName = "مركز كفر سعد",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1105,
                CityId = 11,
                EnName = "Dumyat Al-Gadida",
                ArName = "قسم مدينه دمياط الجديده",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1106,
                CityId = 11,
                EnName = "Ras al-Bar",
                ArName = "قسم رأس البر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1107,
                CityId = 11,
                EnName = "Zarqa",
                ArName = "مركز الزرقا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1108,
                CityId = 11,
                EnName = "Police Department Port of Damietta",
                ArName = "إداره شرطه ميناء دمياط الجديد",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1109,
                CityId = 11,
                EnName = "Dumyat 2",
                ArName = "قسم ثان دمياط",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1201,
                CityId = 12,
                EnName = "El Mansora 1",
                ArName = "قسم اول المنصورة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1202,
                CityId = 12,
                EnName = "E Mansora 2",
                ArName = "قسم ثان المنصورة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1203,
                CityId = 12,
                EnName = "El Mansora",
                ArName = "مركز المنصورة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1204,
                CityId = 12,
                EnName = "Aga",
                ArName = "مركز أجا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1205,
                CityId = 12,
                EnName = "Sinbillawin",
                ArName = "مركز السنبلاوين",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1206,
                CityId = 12,
                EnName = "Matariyya",
                ArName = "مركز المطرية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1207,
                CityId = 12,
                EnName = "Manzala",
                ArName = "مركز المنزلة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1208,
                CityId = 12,
                EnName = "Bilqas",
                ArName = "مركز بلقاس",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1209,
                CityId = 12,
                EnName = "Dikirnis",
                ArName = "مركز دكرنس",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1210,
                CityId = 12,
                EnName = "Shirbin",
                ArName = "مركز شربين",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1211,
                CityId = 12,
                EnName = "Talkha",
                ArName = "مركز طلخا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1212,
                CityId = 12,
                EnName = "Mit Ghamr",
                ArName = "قسم ميت غمر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1213,
                CityId = 12,
                EnName = "Mit Ghamr",
                ArName = "مركز ميت غمر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1214,
                CityId = 12,
                EnName = "Minya Al-Nasr",
                ArName = "مركز منية النصر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1215,
                CityId = 12,
                EnName = "Gamaliyya",
                ArName = "مركز الجمالية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1216,
                CityId = 12,
                EnName = "Tamy Al-Amdid",
                ArName = "مركز تمى الأمديد",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1217,
                CityId = 12,
                EnName = "MIt Salsil",
                ArName = "مركز ميت سلسيل",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1218,
                CityId = 12,
                EnName = "Bany Abeed",
                ArName = "مركز بنى عبيد",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1219,
                CityId = 12,
                EnName = "Mahalet Demna",
                ArName = "مركز محلة دمنة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1220,
                CityId = 12,
                EnName = "Gamsa",
                ArName = "قسم جمصة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1221,
                CityId = 12,
                EnName = "Nebro",
                ArName = "مركز نبروة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1300,
                CityId = 13,
                EnName = "Zemam Out",
                ArName = "خارج الزمام",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1301,
                CityId = 13,
                EnName = "Zaqaziq 1",
                ArName = "قسم اول الزقازيق",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1302,
                CityId = 13,
                EnName = "Zaqaziq 2",
                ArName = "قسم ثان الزقازيق",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1303,
                CityId = 13,
                EnName = "Zaqaziq",
                ArName = "مركز الزقازيق",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1304,
                CityId = 13,
                EnName = "Abu Hammad",
                ArName = "مركز أبو حماد",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1305,
                CityId = 13,
                EnName = "Abu Kabir",
                ArName = "مركز أبوكبير",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1306,
                CityId = 13,
                EnName = "Al-Husayniya",
                ArName = "مركز الحسينية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1307,
                CityId = 13,
                EnName = "Al-Salhiyya",
                ArName = "قسم الصالحية الجديدة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1308,
                CityId = 13,
                EnName = "Bilbis",
                ArName = "مركز بلبيس",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1309,
                CityId = 13,
                EnName = "10 Ramadan 1",
                ArName = "قسم اول مدينة العاشر من رمضان",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1310,
                CityId = 13,
                EnName = "Dyarb Nigm",
                ArName = "مركز ديرب نجم",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1311,
                CityId = 13,
                EnName = "Faqus",
                ArName = "قسم فاقوس",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1312,
                CityId = 13,
                EnName = "Faqus",
                ArName = "مركز فاقوس",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1313,
                CityId = 13,
                EnName = "Kafr Saqr",
                ArName = "مركز كفر صقر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1314,
                CityId = 13,
                EnName = "Minya al-Qamh",
                ArName = "مركز منيا القمح",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1315,
                CityId = 13,
                EnName = "Hihya",
                ArName = "مركز ههيا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1316,
                CityId = 13,
                EnName = "Mashtul Al-Suq",
                ArName = "مركز مشتول السوق",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1317,
                CityId = 13,
                EnName = "El-Ibrahimiya",
                ArName = "مركز الأبراهيمية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1318,
                CityId = 13,
                EnName = "Al-Qanayat",
                ArName = "قسم القنايات",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1319,
                CityId = 13,
                EnName = "Awlad Saqr",
                ArName = "مركز أولاد صقر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1320,
                CityId = 13,
                EnName = "Qurin",
                ArName = "قسم القرين",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1321,
                CityId = 13,
                EnName = "10 Ramadan 2",
                ArName = "قسم ثان مدينه العاشر من رمضان",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1400,
                CityId = 14,
                EnName = "Zemam Out",
                ArName = "خارج الزمام",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1401,
                CityId = 14,
                EnName = "Banha",
                ArName = "قسم بنها",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1402,
                CityId = 14,
                EnName = "Banha",
                ArName = "مركز بنها",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1403,
                CityId = 14,
                EnName = "Al Khanka",
                ArName = "مركز الخانكة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1404,
                CityId = 14,
                EnName = "Qanatir Al-Khayriyya",
                ArName = "مركز القناطر الخيرية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1405,
                CityId = 14,
                EnName = "Shibin al-Qanatir",
                ArName = "مركز شبين القناطر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1406,
                CityId = 14,
                EnName = "Shubra Al-Khayma 1",
                ArName = "قسم أول شبرا الخيمة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1407,
                CityId = 14,
                EnName = "Shubra Al-Khayma 2",
                ArName = "قسم ثان شبرا الخيمة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1408,
                CityId = 14,
                EnName = "Tukh",
                ArName = "مركز طوخ",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1409,
                CityId = 14,
                EnName = "Qalyub",
                ArName = "قسم قليوب",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1410,
                CityId = 14,
                EnName = "Qalyub",
                ArName = "مركز قليوب",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1411,
                CityId = 14,
                EnName = "Kafr Shukr",
                ArName = "مركز كفر شكر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1412,
                CityId = 14,
                EnName = "Khsos",
                ArName = "قسم الخصوص",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1413,
                CityId = 14,
                EnName = "Abour",
                ArName = "قسم العبور",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1414,
                CityId = 14,
                EnName = "Qaha",
                ArName = "قسم قها",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1501,
                CityId = 15,
                EnName = "Kafr Al-Shaykh",
                ArName = "قسم كفر الشيخ",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1502,
                CityId = 15,
                EnName = "Kafr Al-Shaykh",
                ArName = "مركز كفر الشيخ",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1503,
                CityId = 15,
                EnName = "Burullus",
                ArName = "مركز البرلس",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1504,
                CityId = 15,
                EnName = "Biyalu",
                ArName = "مركز بيلا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1505,
                CityId = 15,
                EnName = "Disuq",
                ArName = "قسم دسوق",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1506,
                CityId = 15,
                EnName = "Disuq",
                ArName = "مركز دسوق",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1507,
                CityId = 15,
                EnName = "Sidi Salim",
                ArName = "مركز سيدى سالم",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1508,
                CityId = 15,
                EnName = "Fuwwa",
                ArName = "مركز فوه",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1509,
                CityId = 15,
                EnName = "Qillin",
                ArName = "مركز قلين",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1510,
                CityId = 15,
                EnName = "Mitubas",
                ArName = "مركز مطوبس",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1511,
                CityId = 15,
                EnName = "Al Hamul",
                ArName = "مركز الحامول",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1512,
                CityId = 15,
                EnName = "Riyad",
                ArName = "مركز الرياض",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1601,
                CityId = 16,
                EnName = "Tanta 1",
                ArName = "قسم أول طنطا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1602,
                CityId = 16,
                EnName = "Tanta 2",
                ArName = "قسم ثان طنطا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1603,
                CityId = 16,
                EnName = "Tanta",
                ArName = "مركز طنطا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1604,
                CityId = 16,
                EnName = "Santa",
                ArName = "مركز السنطة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1605,
                CityId = 16,
                EnName = "El Mahalla El Kobra 1",
                ArName = "قسم أول المحلة الكبرى",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1606,
                CityId = 16,
                EnName = "El Mahalla El Kobra 2",
                ArName = "قسم ثان المحلة الكبرى",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1607,
                CityId = 16,
                EnName = "El Mahalla El Kobra",
                ArName = "مركز المحله الكبرى",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1608,
                CityId = 16,
                EnName = "Basyun",
                ArName = "مركز بسيون",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1609,
                CityId = 16,
                EnName = "Zifta",
                ArName = "مركز زفتى",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1610,
                CityId = 16,
                EnName = "Samannud",
                ArName = "مركز سمنود",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1611,
                CityId = 16,
                EnName = "Qutur",
                ArName = "مركز قطور",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1612,
                CityId = 16,
                EnName = "Kafr Al-Zayyat",
                ArName = "مركز كفر الزيات",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1701,
                CityId = 17,
                EnName = "Shibin al-Kum",
                ArName = "قسم شبين الكوم",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1702,
                CityId = 17,
                EnName = "Shibin al-Kum",
                ArName = "مركز شبين الكوم",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1703,
                CityId = 17,
                EnName = "Ashmun",
                ArName = "مركز أشمون",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1704,
                CityId = 17,
                EnName = "Al-Bagur",
                ArName = "مركز الباجور",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1705,
                CityId = 17,
                EnName = "Al-Shuhada",
                ArName = "مركز الشهداء",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1706,
                CityId = 17,
                EnName = "Birkat Al-Sab",
                ArName = "مركز بركة السبع",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1707,
                CityId = 17,
                EnName = "Tala",
                ArName = "مركز تلا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1708,
                CityId = 17,
                EnName = "Quwisna",
                ArName = "مركز قويسنا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1709,
                CityId = 17,
                EnName = "Minuf",
                ArName = "مركز منوف",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1710,
                CityId = 17,
                EnName = "Sirs Al-Layyana City",
                ArName = "قسم مدينة سرس الليانة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1711,
                CityId = 17,
                EnName = "Sadat City",
                ArName = "مركز السادات",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1712,
                CityId = 17,
                EnName = "Minuf City",
                ArName = "قسم مدينة منوف",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1800,
                CityId = 18,
                EnName = "Zemam Out",
                ArName = "خارج الزمام",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1801,
                CityId = 18,
                EnName = "Damanhur",
                ArName = "قسم دمنهور",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1802,
                CityId = 18,
                EnName = "Damanhur",
                ArName = "مركز دمنهور",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1803,
                CityId = 18,
                EnName = "Abu-l-Matamir",
                ArName = "مركز ابوالمطامير",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1804,
                CityId = 18,
                EnName = "Abu Hummus",
                ArName = "مركز ابوحمص",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1805,
                CityId = 18,
                EnName = "Al-Dilingat",
                ArName = "مركز الدلنجات",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1806,
                CityId = 18,
                EnName = "Al-Mahmudiyya",
                ArName = "مركز المحمودية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1807,
                CityId = 18,
                EnName = "Itay Al-Barud",
                ArName = "مركز إيتاى البارود",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1808,
                CityId = 18,
                EnName = "Hush Isa",
                ArName = "مركز حوش عيسى",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1809,
                CityId = 18,
                EnName = "Rashid",
                ArName = "مركز رشيد",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1810,
                CityId = 18,
                EnName = "Shubra Khit",
                ArName = "مركز شبراخيت",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1811,
                CityId = 18,
                EnName = "Kafr Al-Dawwar",
                ArName = "قسم كفرالدوار",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1812,
                CityId = 18,
                EnName = "Kafr Al-Dawwar",
                ArName = "مركز كفر الدوار",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1813,
                CityId = 18,
                EnName = "Kum Hamada",
                ArName = "مركز كوم حمادة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1814,
                CityId = 18,
                EnName = "Wadi Al-NatrUn",
                ArName = "مركز وادى النطرون",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1815,
                CityId = 18,
                EnName = "Al-Rahmaniyya",
                ArName = "مركز الرحمانية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1816,
                CityId = 18,
                EnName = "Idku",
                ArName = "مركز إدكو",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1817,
                CityId = 18,
                EnName = "Nubariyya West",
                ArName = "قسم غرب النوبارية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1818,
                CityId = 18,
                EnName = "Badr",
                ArName = "مركز بدر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1901,
                CityId = 19,
                EnName = "Ismailiyya 1",
                ArName = "قسم أول الاسماعيلية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1902,
                CityId = 19,
                EnName = "Ismailiyya 2",
                ArName = "قسم ثان الاسماعيلية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1903,
                CityId = 19,
                EnName = "Ismailiyya 3",
                ArName = "قسم ثالث الاسماعيلية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1904,
                CityId = 19,
                EnName = "Ismailiyya",
                ArName = "مركز الاسماعيلية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1905,
                CityId = 19,
                EnName = "Tal al-Kabir, al-",
                ArName = "مركز التل الكبير",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1906,
                CityId = 19,
                EnName = "Qantara Gharb, al-",
                ArName = "مركز القنطرة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1907,
                CityId = 19,
                EnName = "Fayid",
                ArName = "مركز فايد",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 1908,
                CityId = 19,
                EnName = "Qantara Sharq, al-",
                ArName = "قسم القنطرة شرق",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2100,
                CityId = 21,
                EnName = "Zemam Out",
                ArName = "خارج الزمام",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2101,
                CityId = 21,
                EnName = "Imbaba",
                ArName = "قسم امبابه",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2102,
                CityId = 21,
                EnName = "Al-Aguza",
                ArName = "قسم العجوزة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2103,
                CityId = 21,
                EnName = "DuqqI",
                ArName = "قسم الدقي",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2104,
                CityId = 21,
                EnName = "Giza",
                ArName = "قسم الجيزة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2105,
                CityId = 21,
                EnName = "Bulaq Al-DakrUr",
                ArName = "قسم بولاق الدكرور",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2106,
                CityId = 21,
                EnName = "Al-Ahram",
                ArName = "قسم الأهرام",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2107,
                CityId = 21,
                EnName = "6 October-1",
                ArName = "قسم أول 6 أكتوبر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2108,
                CityId = 21,
                EnName = "Hwamdeia",
                ArName = "قسم الحوامدية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2109,
                CityId = 21,
                EnName = "Giza",
                ArName = "مركز الجيزة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2110,
                CityId = 21,
                EnName = "Badrashain",
                ArName = "مركز البدرشين",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2111,
                CityId = 21,
                EnName = "Saf",
                ArName = "مركز الصف",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2112,
                CityId = 21,
                EnName = "Ayat",
                ArName = "مركز العياط",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2113,
                CityId = 21,
                EnName = "Imbaba",
                ArName = "مركز إمبابة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2114,
                CityId = 21,
                EnName = "Bahariya Oasis",
                ArName = "قسم الواحاتالبحرية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2115,
                CityId = 21,
                EnName = "Atfeh",
                ArName = "مركز أطفيح",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2116,
                CityId = 21,
                EnName = "Auseem",
                ArName = "مركز أوسيم",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2117,
                CityId = 21,
                EnName = "Waraq",
                ArName = "قسم الوراق",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2118,
                CityId = 21,
                EnName = "Umraniyya",
                ArName = "قسم العمرانية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2119,
                CityId = 21,
                EnName = "Shaykh Zayed",
                ArName = "قسم الشيخ زايد",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2120,
                CityId = 21,
                EnName = "Kardasa",
                ArName = "مركز كرداسة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2121,
                CityId = 21,
                EnName = "6 October-2",
                ArName = "قسم ثان 6 أكتوبر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2200,
                CityId = 22,
                EnName = "Zemam Out",
                ArName = "خارج الزمام",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2201,
                CityId = 22,
                EnName = "Bani Swayf",
                ArName = "قسم بنى سويف",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2202,
                CityId = 22,
                EnName = "Bani Swayf",
                ArName = "مركز بنى سويف",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2203,
                CityId = 22,
                EnName = "Bani Swayf City",
                ArName = "قسم مدينة بنى سويف الجديدة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2204,
                CityId = 22,
                EnName = "Al Fashn",
                ArName = "مركز الفشن",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2205,
                CityId = 22,
                EnName = "Al Wasta",
                ArName = "مركز الواسطى",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2206,
                CityId = 22,
                EnName = "Ahnasya",
                ArName = "مركز أهناسيا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2207,
                CityId = 22,
                EnName = "Biba",
                ArName = "مركز ببا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2208,
                CityId = 22,
                EnName = "Sumusta",
                ArName = "مركز سمسطا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2209,
                CityId = 22,
                EnName = "Nasir",
                ArName = "مركز ناصر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2300,
                CityId = 23,
                EnName = "Zemam Out",
                ArName = "خارج الزمام",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2301,
                CityId = 23,
                EnName = "Fayyum",
                ArName = "قسم الفيوم",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2302,
                CityId = 23,
                EnName = "Fayyum",
                ArName = "مركز الفيوم",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2303,
                CityId = 23,
                EnName = "Abshaway",
                ArName = "مركز أبشواى",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2304,
                CityId = 23,
                EnName = "Atsa",
                ArName = "مركز أطسا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2305,
                CityId = 23,
                EnName = "Sinuras",
                ArName = "مركز سنورس",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2306,
                CityId = 23,
                EnName = "Tamya",
                ArName = "مركز طامية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2307,
                CityId = 23,
                EnName = "Yousef El sadeq",
                ArName = "مركز يوسف الصديق",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2308,
                CityId = 23,
                EnName = "Fayyum City",
                ArName = "مدينة الفيوم الجديدة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2400,
                CityId = 24,
                EnName = "Zemam Out",
                ArName = "خارج الزمام",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2401,
                CityId = 24,
                EnName = "Kesm Al-minya",
                ArName = "قسم المنيا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2402,
                CityId = 24,
                EnName = "Markz Al Minya",
                ArName = "مركز المنيا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2403,
                CityId = 24,
                EnName = "New Minya",
                ArName = "مدينة المنيا الجديدة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2404,
                CityId = 24,
                EnName = "Markz Abu Qurqas",
                ArName = "مركز ابو قرقاص",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2405,
                CityId = 24,
                EnName = "Markz Al Idwa",
                ArName = "مركز العدوة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2406,
                CityId = 24,
                EnName = "Markz Bani Mazar",
                ArName = "مركز بنى مزار",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2407,
                CityId = 24,
                EnName = "Markz Dir Mawas",
                ArName = "مركز دير مواس",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2408,
                CityId = 24,
                EnName = "Markz Samalut",
                ArName = "مركز سمالوط",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2409,
                CityId = 24,
                EnName = "Markz Matay",
                ArName = "مركز مطاى",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2410,
                CityId = 24,
                EnName = "Markz Maghagha",
                ArName = "مركز مغاغة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2411,
                CityId = 24,
                EnName = "Kesm Mallawi",
                ArName = "قسم ملوى",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2412,
                CityId = 24,
                EnName = "Markz Mallawi",
                ArName = "مركز ملوى",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2500,
                CityId = 25,
                EnName = "Zemam Out",
                ArName = "صحراء أسيوط",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2501,
                CityId = 25,
                EnName = "Kesm Awal Assuit",
                ArName = "قسم أول أسيوط",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2502,
                CityId = 25,
                EnName = "Kesm Than Assuit",
                ArName = "قسم ثان أسيوط",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2503,
                CityId = 25,
                EnName = "Assuit",
                ArName = "مركز أسيوط",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2504,
                CityId = 25,
                EnName = "Abnub",
                ArName = "مركز أبنوب",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2505,
                CityId = 25,
                EnName = "Abu Tig",
                ArName = "مركز أبوتيج",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2506,
                CityId = 25,
                EnName = "Al- Badari",
                ArName = "مركز البدارى",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2507,
                CityId = 25,
                EnName = "Sahil Silim",
                ArName = "مركز ساحل سليم",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2508,
                CityId = 25,
                EnName = "Al-Ghanayem",
                ArName = "مركز الغنايم",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2509,
                CityId = 25,
                EnName = "Al-Qusia",
                ArName = "مركز القوصية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2510,
                CityId = 25,
                EnName = "Dayrut",
                ArName = "مركز ديروط",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2511,
                CityId = 25,
                EnName = "Sidfa",
                ArName = "مركز صدفا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2512,
                CityId = 25,
                EnName = "Manfalut",
                ArName = "مركز منفلوط",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2513,
                CityId = 25,
                EnName = "Alfath",
                ArName = "مركز الفتح",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2514,
                CityId = 25,
                EnName = "Assuit City",
                ArName = "مدينة اسيوط الجديدة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2600,
                CityId = 26,
                EnName = "Zemam Out",
                ArName = "صحراء سوهاج",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2601,
                CityId = 26,
                EnName = "Suhag",
                ArName = "قسم اول سوهاج",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2602,
                CityId = 26,
                EnName = "Suhag-2",
                ArName = "قسم ثان سوهاج",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2603,
                CityId = 26,
                EnName = "Suhag",
                ArName = "مركز سوهاج",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2604,
                CityId = 26,
                EnName = "Akhmim",
                ArName = "مركز أخميم",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2605,
                CityId = 26,
                EnName = "Al-Balyana",
                ArName = "مركز البلينا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2606,
                CityId = 26,
                EnName = "Al-Maragha",
                ArName = "مركز المراغة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2607,
                CityId = 26,
                EnName = "Al-Minshat",
                ArName = "مركز المنشأة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2608,
                CityId = 26,
                EnName = "Dar al-Salam",
                ArName = "مركز دار السلام",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2609,
                CityId = 26,
                EnName = "Girga",
                ArName = "قسم جرجا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2610,
                CityId = 26,
                EnName = "Girga",
                ArName = "مركز جرجا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2611,
                CityId = 26,
                EnName = "Guhayna Al-Gharbiyya",
                ArName = "مركز جهينة الغربية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2612,
                CityId = 26,
                EnName = "Saqulta",
                ArName = "مركز ساقلته",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2613,
                CityId = 26,
                EnName = "Tama",
                ArName = "مركز طما",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2614,
                CityId = 26,
                EnName = "Tahta",
                ArName = "مركز طهطا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2615,
                CityId = 26,
                EnName = "Kesm Tahta",
                ArName = "قسم طهطا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2616,
                CityId = 26,
                EnName = "Kawther",
                ArName = "قسم الكوثر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2617,
                CityId = 26,
                EnName = "Al Usayrat",
                ArName = "مركز العسيرات",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2618,
                CityId = 26,
                EnName = "Akhmim City",
                ArName = "مدينة أخميم الجديدة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2619,
                CityId = 26,
                EnName = "Suhag City",
                ArName = "مدينة سوهاج الجديدة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2700,
                CityId = 27,
                EnName = "Zemam Out",
                ArName = "صحراء قنا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2701,
                CityId = 27,
                EnName = "Qina",
                ArName = "قسم قنا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2702,
                CityId = 27,
                EnName = "Qina",
                ArName = "مركز قنا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2703,
                CityId = 27,
                EnName = "Abu Tisht",
                ArName = "مركز أبو طشت",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2704,
                CityId = 27,
                EnName = "Armant",
                ArName = "مركز أرمنت",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2705,
                CityId = 27,
                EnName = "Isna",
                ArName = "مركز إسنا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2706,
                CityId = 27,
                EnName = "Dishna",
                ArName = "مركز دشنا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2707,
                CityId = 27,
                EnName = "Qus",
                ArName = "مركز قوص",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2708,
                CityId = 27,
                EnName = "Nag Hammadi",
                ArName = "مركز نجع حمادى",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2709,
                CityId = 27,
                EnName = "Naqada",
                ArName = "مركز نقادة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2710,
                CityId = 27,
                EnName = "Farshut",
                ArName = "مركز فرشوط",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2711,
                CityId = 27,
                EnName = "Qift",
                ArName = "مركز قفط",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2712,
                CityId = 27,
                EnName = "Al Waqf",
                ArName = "مركز الوقف",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2713,
                CityId = 27,
                EnName = "Qina City",
                ArName = "مدينة قنا الجديدة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2800,
                CityId = 28,
                EnName = "Zemam Out",
                ArName = "خارج الزمام",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2801,
                CityId = 28,
                EnName = "Aswan",
                ArName = "قسم أسوان",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2802,
                CityId = 28,
                EnName = "Aswan",
                ArName = "مركز أسوان",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2803,
                CityId = 28,
                EnName = "Adfu",
                ArName = "مركز أدفو",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2804,
                CityId = 28,
                EnName = "Kum Umbu",
                ArName = "مركز كوم امبو",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2805,
                CityId = 28,
                EnName = "Nasr",
                ArName = "مركز نصر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2806,
                CityId = 28,
                EnName = "Daraw",
                ArName = "مركز دراو",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2807,
                CityId = 28,
                EnName = "Abu Simbel",
                ArName = "مركز أبوسنبل",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2808,
                CityId = 28,
                EnName = "Aswan City",
                ArName = "مدينة أسوان الجديدة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2809,
                CityId = 28,
                EnName = "Tushaka",
                ArName = "مدينة توشكى الجديدة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2900,
                CityId = 29,
                EnName = "Zemam Out",
                ArName = "خارج الزمام",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2901,
                CityId = 29,
                EnName = "Luxor",
                ArName = "قسم الأقصر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2902,
                CityId = 29,
                EnName = "Luxor",
                ArName = "مركز الأقصر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 2903,
                CityId = 29,
                EnName = "Tiba police station",
                ArName = "مركز شرطة طيبة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3101,
                CityId = 31,
                EnName = "Hurghada 1",
                ArName = "قسم أول الغردقة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3102,
                CityId = 31,
                EnName = "Qusir",
                ArName = "قسم القصير",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3103,
                CityId = 31,
                EnName = "Safaga",
                ArName = "قسم سفاجا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3104,
                CityId = 31,
                EnName = "Marsa Alam",
                ArName = "قسم مرسى علم",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3105,
                CityId = 31,
                EnName = "Ras Gharib",
                ArName = "قسم رأس غارب",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3106,
                CityId = 31,
                EnName = "Shallatin",
                ArName = "قسم شلاتين",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3107,
                CityId = 31,
                EnName = "Halayib",
                ArName = "قسم حلايب",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3108,
                CityId = 31,
                EnName = "Hurghada 2",
                ArName = "قسم ثان الغردقة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3201,
                CityId = 32,
                EnName = "Al-Kharga Oasis",
                ArName = "مركز الواحات الخارجة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3202,
                CityId = 32,
                EnName = "A-Dakhla Oasis",
                ArName = "مركز الوحات الداخلة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3203,
                CityId = 32,
                EnName = "Al Farafra Oasis",
                ArName = "مركز الفرافرة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3204,
                CityId = 32,
                EnName = "Paris Paris",
                ArName = "مركز باريس",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3301,
                CityId = 33,
                EnName = "Marsa Matruh",
                ArName = "قسم مرسى مطروح",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3302,
                CityId = 33,
                EnName = "Al-Hammam",
                ArName = "قسم الحمام",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3303,
                CityId = 33,
                EnName = "Salloum",
                ArName = "قسم السلوم",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3304,
                CityId = 33,
                EnName = "Daba",
                ArName = "مركز الضبعة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3305,
                CityId = 33,
                EnName = "Sidi Barani",
                ArName = "قسم سيدى برانى",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3306,
                CityId = 33,
                EnName = "Siwa",
                ArName = "مركز سيوة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3307,
                CityId = 33,
                EnName = "Alamn",
                ArName = "قسم مارينا العلمين السياحية",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3308,
                CityId = 33,
                EnName = "North Coast",
                ArName = "قسم الساحل الشمالى-جزء",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3401,
                CityId = 34,
                EnName = "El Arish 1",
                ArName = "قسم أول العريش",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3402,
                CityId = 34,
                EnName = "El Arish 2",
                ArName = "قسم ثان العريش",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3403,
                CityId = 34,
                EnName = "El Arish 3",
                ArName = "قسم ثالث العريش",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3404,
                CityId = 34,
                EnName = "El Arish 4",
                ArName = "قسم رابع العريش",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3405,
                CityId = 34,
                EnName = "Bir Al-Abd",
                ArName = "قسم بئر العبد",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3406,
                CityId = 34,
                EnName = "Al-Hasna",
                ArName = "قسم الحسنة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3407,
                CityId = 34,
                EnName = "Nakhl",
                ArName = "قسم نخل",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3408,
                CityId = 34,
                EnName = "Shaykh Zuwayd",
                ArName = "قسم الشيخ زويد",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3409,
                CityId = 34,
                EnName = "Rafah",
                ArName = "قسم رفح",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3410,
                CityId = 34,
                EnName = "Rummana",
                ArName = "قسم رمانة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3411,
                CityId = 34,
                EnName = "Qasima",
                ArName = "قسم القسيمة",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3501,
                CityId = 35,
                EnName = "Al-Tur",
                ArName = "قسم الطور",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3502,
                CityId = 35,
                EnName = "Ras Sidr",
                ArName = "قسم رأس سدر",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3503,
                CityId = 35,
                EnName = "Abu Radis",
                ArName = "قسم أبو رديس",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3504,
                CityId = 35,
                EnName = "Sant Katrin",
                ArName = "قسم سانت كاترين",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3505,
                CityId = 35,
                EnName = "Sharm el-Sheikh",
                ArName = "قسم شرم الشيخ",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3506,
                CityId = 35,
                EnName = "Dahab",
                ArName = "قسم دهب",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3507,
                CityId = 35,
                EnName = "Nuweiba",
                ArName = "قسم نويبع",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
            new Area
            {
                AreaId = 3508,
                CityId = 35,
                EnName = "Taba",
                ArName = "قسم طابا",
                EnDescription = string.Empty,
                ArDescription = string.Empty,
                CreationTime = SeedDate,
                LastModificationTime = SeedDate,
                CreatorUserId = null,
                LastModifierUserId = null,
                DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
            },
        ];
    }
}
