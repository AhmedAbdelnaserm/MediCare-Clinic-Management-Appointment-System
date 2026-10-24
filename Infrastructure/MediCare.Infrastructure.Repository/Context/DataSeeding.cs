using MediCare.Core.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Infrastructure.Repository.Context
{
    public class DataSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //SeedCities(modelBuilder);
            //SeedAreas(modelBuilder);
        }

        //#region Cities
        //private static void SeedCities(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<City>().HasData(
        //        new City { CityId = 1, ArName = "القاهرة", EnName = "Cairo", ArDescription = "القاهرة", EnDescription = "Cairo", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 2, ArName = "الجيزة", EnName = "Giza", ArDescription = "الجيزة", EnDescription = "Giza", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 3, ArName = "الإسكندرية", EnName = "Alexandria", ArDescription = "الإسكندرية", EnDescription = "Alexandria", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 4, ArName = "الدقهلية", EnName = "Dakahlia", ArDescription = "الدقهلية", EnDescription = "Dakahlia", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 5, ArName = "البحر الأحمر", EnName = "Red Sea", ArDescription = "البحر الأحمر", EnDescription = "Red Sea", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 6, ArName = "البحيرة", EnName = "Beheira", ArDescription = "البحيرة", EnDescription = "Beheira", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 7, ArName = "الفيوم", EnName = "Fayoum", ArDescription = "الفيوم", EnDescription = "Fayoum", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 8, ArName = "الغربية", EnName = "Gharbiya", ArDescription = "الغربية", EnDescription = "Gharbiya", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 9, ArName = "الإسماعلية", EnName = "Ismailia", ArDescription = "الإسماعلية", EnDescription = "Ismailia", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 10, ArName = "المنوفية", EnName = "Menofia", ArDescription = "المنوفية", EnDescription = "Menofia", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 11, ArName = "المنيا", EnName = "Minya", ArDescription = "المنيا", EnDescription = "Minya", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 12, ArName = "القليوبية", EnName = "Qalyubia", ArDescription = "القليوبية", EnDescription = "Qalyubia", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 13, ArName = "الوادي الجديد", EnName = "New Valley", ArDescription = "الوادي الجديد", EnDescription = "New Valley", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 14, ArName = "السويس", EnName = "Suez", ArDescription = "السويس", EnDescription = "Suez", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 15, ArName = "أسوان", EnName = "Aswan", ArDescription = "أسوان", EnDescription = "Aswan", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 16, ArName = "أسيوط", EnName = "Assiut", ArDescription = "أسيوط", EnDescription = "Assiut", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 17, ArName = "بني سويف", EnName = "Beni Suef", ArDescription = "بني سويف", EnDescription = "Beni Suef", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 18, ArName = "بورسعيد", EnName = "Port Said", ArDescription = "بورسعيد", EnDescription = "Port Said", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 19, ArName = "دمياط", EnName = "Damietta", ArDescription = "دمياط", EnDescription = "Damietta", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 20, ArName = "سوهاج", EnName = "Sohag", ArDescription = "سوهاج", EnDescription = "Sohag", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 21, ArName = "شمال سيناء", EnName = "North Sinai", ArDescription = "شمال سيناء", EnDescription = "North Sinai", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 22, ArName = "جنوب سيناء", EnName = "South Sinai", ArDescription = "جنوب سيناء", EnDescription = "South Sinai", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 23, ArName = "الشرقية", EnName = "Sharqia", ArDescription = "الشرقية", EnDescription = "Sharqia", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 24, ArName = "كفر الشيخ", EnName = "Kafr El Sheikh", ArDescription = "كفر الشيخ", EnDescription = "Kafr El Sheikh", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 25, ArName = "مطروح", EnName = "Matrouh", ArDescription = "مطروح", EnDescription = "Matrouh", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 26, ArName = "الفيوم", EnName = "Faiyum", ArDescription = "الفيوم", EnDescription = "Faiyum", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted },
        //        new City { CityId = 27, ArName = "الوادي الجديد", EnName = "New Valley", ArDescription = "الوادي الجديد", EnDescription = "New Valley", CreationTime = new DateTime(2025, 12, 27), LastModificationTime = new DateTime(2025, 12, 27), CreatorUserId = 1, LastModifierUserId = 1, DeleteStatusId = (int)DeleteStatusEnum.NotDeleted }
        //    );
        //}
        //#endregion

        //#region Areas
        //private static void SeedAreas(ModelBuilder modelBuilder)
        //{
        //    int areaId = 1;

        //    var areasPerCity = new Dictionary<int, List<(string ArName, string EnName)>>()
        //    {
        //        // القاهرة - 10 Areas
        //        { 1, new List<(string,string)>
        //            {
        //                ("مصر الجديدة","Heliopolis"),("المعادي","Maadi"),("العباسية","Abbaseya"),
        //                ("الزمالك","Zamalek"),("الجيزة","Giza"),("حلوان","Helwan"),
        //                ("المرج","El Marg"),("مدينة نصر","Nasr City"),("عين شمس","Ain Shams"),("الظاهر","Al Zaher")
        //            }
        //        },
        //        // الجيزة - 10 Areas
        //        { 2, new List<(string,string)>
        //            {
        //                ("الهرم","Al Haram"),("الشيخ زايد","Sheikh Zayed"),("الواحات","Al Wahat"),
        //                ("الدقي","Dokki"),("الجيزة الجديدة","New Giza"),("المهندسين","Mohandessin"),
        //                ("العجوزة","Agouza"),("أبو الهول","Abu El Hol"),("الصف","Saf"),("الوراق","Warraq")
        //            }
        //        },
        //        // الإسكندرية - 10 Areas
        //        { 3, new List<(string,string)>
        //            {
        //                ("سموحة","Smoha"),("العصافرة","El Asafra"),("كامب شيزار","Camp Chezar"),
        //                ("برج العرب","Borg El Arab"),("محرم بك","Moharam Bek"),("سيدي جابر","Sidi Gaber"),
        //                ("رشدي","Roshdy"),("ستانلي","Stanley"),("المنتزه","Montaza"),("برج العرب الجديدة","New Borg El Arab")
        //            }
        //        },
        //        // باقي المحافظات 3-5 Areas
        //        { 4, new List<(string,string)>{ ("منية النصر","Menia El Nasr"),("طلخا","Talkha"),("المنصورة","Mansoura") } },
        //        { 5, new List<(string,string)>{ ("الغردقة","Hurghada"),("رأس غارب","Ras Gharib"),("القصير","Quseir") } },
        //        { 6, new List<(string,string)>{ ("دمنهور","Damanhur"),("كفر الدوار","Kafr El Dawar"),("رشيد","Rashid") } },
        //        { 7, new List<(string,string)>{ ("الفيوم الجديدة","Faiyum El Gedida"),("مدينة الفيوم","Faiyum City"),("طامية","Tamiya") } },
        //        { 8, new List<(string,string)>{ ("طنطا","Tanta"),("المحلة الكبرى","Mahalla"),("زفتى","Zefta") } },
        //        { 9, new List<(string,string)>{ ("القصاصين","Al Qassaseen"),("الإسماعيلية الجديدة","New Ismailia"),("فايد","Fayed") } },
        //        { 10, new List<(string,string)>{ ("شبين الكوم","Shebin El Kom"),("منوف","Menouf"),("السادات","Sadat City") } },
        //        { 11, new List<(string,string)>{ ("المنيا الجديدة","New Minya"),("مغاغة","Magagha"),("ملوي","Mallawi") } },
        //        { 12, new List<(string,string)>{ ("بنها","Banha"),("قليوب","Qalyub"),("شبرا الخيمة","Shubra El Kheima") } },
        //        { 13, new List<(string,string)>{ ("الخارجة","El Kharga"),("باريس","Paris"),("الداخلة","El Dakhla") } },
        //        { 14, new List<(string,string)>{ ("السويس","Suez City"),("جميع","Gomaa"),("القصاصين","Qassaseen") } },
        //        { 15, new List<(string,string)>{ ("أسوان","Aswan City"),("كوم أمبو","Kom Ombo"),("نصر النوبة","Naser El Nuba") } },
        //        { 16, new List<(string,string)>{ ("أسيوط","Assiut City"),("ديروط","Deirout"),("منفلوط","Manfalut") } },
        //        { 17, new List<(string,string)>{ ("بني سويف","Beni Suef City"),("الفشن","Fashn"),("ناصر","Naser") } },
        //        { 18, new List<(string,string)>{ ("بورسعيد","Port Said City"),("العرب","Al Arab"),("الضواحي","Al Dawaahi") } },
        //        { 19, new List<(string,string)>{ ("دمياط","Damietta City"),("رأس البر","Ras El Bar"),("الزرقا","Zarqa") } },
        //        { 20, new List<(string,string)>{ ("سوهاج","Sohag City"),("جبل طوسون","Jabal Toson"),("أخميم","Akhmim") } },
        //        { 21, new List<(string,string)>{ ("العريش","Al Arish"),("الشيخ زويد","Sheikh Zuweid"),("رفح","Rafah") } },
        //        { 22, new List<(string,string)>{ ("دهب","Dahab"),("شرم الشيخ","Sharm El Sheikh"),("طور سيناء","Tor Sinai") } },
        //        { 23, new List<(string,string)>{ ("الزقازيق","Zagazig"),("بلبيس","Belbeis"),("أبو حماد","Abu Hammad") } },
        //        { 24, new List<(string,string)>{ ("كفر الشيخ","Kafr El Sheikh City"),("دسوق","Desouq"),("مطوبس","Motobas") } },
        //        { 25, new List<(string,string)>{ ("مرسى مطروح","Marsa Matrouh"),("الحمام","El Hammam"),("النجيلة","El Negila") } },
        //        { 26, new List<(string,string)>{ ("الفيوم الجديدة","Faiyum El Gedida"),("مدينة الفيوم","Faiyum City"),("طامية","Tamiya") } },
        //        { 27, new List<(string,string)>{ ("الخارجة","El Kharga"),("باريس","Paris"),("الداخلة","El Dakhla") } },
        //    };

        //    foreach (var kvp in areasPerCity)
        //    {
        //        int cityId = kvp.Key;
        //        foreach (var area in kvp.Value)
        //        {
        //            modelBuilder.Entity<Area>().HasData(
        //                new Area
        //                {
        //                    AreaId = areaId++,
        //                    CityId = cityId,
        //                    ArName = area.ArName,
        //                    EnName = area.EnName,
        //                    ArDescription = area.ArName,
        //                    EnDescription = area.EnName,
        //                    CreationTime = new DateTime(2025, 12, 27),
        //                    LastModificationTime = new DateTime(2025, 12, 27),
        //                    CreatorUserId = 1,
        //                    LastModifierUserId = 1,
        //                    DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
        //                });
        //        }
        //    }
        //}
        //#endregion
    }
}
