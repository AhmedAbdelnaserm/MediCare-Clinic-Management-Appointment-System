
using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Infrastructure.Repository.Seed;

public static class SpecializationSeeding
{
    private static readonly DateTime SeedDate = new(2025, 12, 27);

    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Specialization>()
            .HasData(GetSpecializations());
    }

    private static Specialization[] GetSpecializations()
    {
        return
        [
            Create(SpecializationEnum.InternalMedicine, "Internal Medicine", "الباطنة"),
            Create(SpecializationEnum.Cardiology, "Cardiology", "القلب"),
            Create(SpecializationEnum.Neurology, "Neurology", "المخ والأعصاب"),
            Create(SpecializationEnum.Pediatrics, "Pediatrics", "طب الأطفال"),
            Create(SpecializationEnum.Dermatology, "Dermatology", "الأمراض الجلدية"),
            Create(SpecializationEnum.Orthopedics, "Orthopedics", "جراحة العظام"),
            Create(SpecializationEnum.GeneralSurgery, "General Surgery", "الجراحة العامة"),
            Create(SpecializationEnum.ObstetricsAndGynecology, "Obstetrics and Gynecology", "النساء والتوليد"),
            Create(SpecializationEnum.Ophthalmology, "Ophthalmology", "طب وجراحة العيون"),
            Create(SpecializationEnum.ENT, "ENT", "الأنف والأذن والحنجرة"),
            Create(SpecializationEnum.Urology, "Urology", "المسالك البولية"),
            Create(SpecializationEnum.Nephrology, "Nephrology", "أمراض الكلى"),
            Create(SpecializationEnum.ChestDiseases, "Chest Diseases", "أمراض الصدر"),
            Create(SpecializationEnum.GastroenterologyAndHepatology, "Gastroenterology and Hepatology", "الجهاز الهضمي والكبد"),
            Create(SpecializationEnum.EndocrinologyAndDiabetes, "Endocrinology and Diabetes", "الغدد الصماء والسكر"),
            Create(SpecializationEnum.Psychiatry, "Psychiatry", "الطب النفسي"),
            Create(SpecializationEnum.Oncology, "Oncology", "الأورام"),
            Create(SpecializationEnum.Rheumatology, "Rheumatology", "أمراض الروماتيزم"),
            Create(SpecializationEnum.Hematology, "Hematology", "أمراض الدم"),
            Create(SpecializationEnum.FamilyMedicine, "Family Medicine", "طب الأسرة"),
            Create(SpecializationEnum.EmergencyMedicine, "Emergency Medicine", "طب الطوارئ"),
            Create(SpecializationEnum.Anesthesiology, "Anesthesiology", "التخدير"),
            Create(SpecializationEnum.CriticalCareMedicine, "Critical Care Medicine", "طب الحالات الحرجة"),
            Create(SpecializationEnum.DiagnosticRadiology, "Diagnostic Radiology", "الأشعة التشخيصية"),
            Create(SpecializationEnum.ClinicalPathology, "Clinical Pathology", "الباثولوجيا الإكلينيكية"),
            Create(SpecializationEnum.PhysicalMedicineAndRehabilitation, "Physical Medicine and Rehabilitation", "الطب الطبيعي والتأهيل"),
            Create(SpecializationEnum.Neurosurgery, "Neurosurgery", "جراحة المخ والأعصاب"),
            Create(SpecializationEnum.CardiothoracicSurgery, "Cardiothoracic Surgery", "جراحة القلب والصدر"),
            Create(SpecializationEnum.VascularSurgery, "Vascular Surgery", "جراحة الأوعية الدموية"),
            Create(SpecializationEnum.PlasticSurgery, "Plastic Surgery", "جراحة التجميل"),
            Create(SpecializationEnum.PediatricSurgery, "Pediatric Surgery", "جراحة الأطفال"),
            Create(SpecializationEnum.Andrology, "Andrology", "أمراض الذكورة"),
            Create(SpecializationEnum.TropicalMedicine, "Tropical Medicine", "الطب الاستوائي"),
            Create(SpecializationEnum.Geriatrics, "Geriatrics", "طب المسنين"),
            Create(SpecializationEnum.Dentistry, "Dentistry", "طب الأسنان"),
            Create(SpecializationEnum.Physiotherapy, "Physiotherapy", "العلاج الطبيعي"),
            Create(SpecializationEnum.Nutrition, "Nutrition", "التغذية العلاجية"),
            Create(SpecializationEnum.InterventionalCardiology, "Interventional Cardiology", "القسطرة التداخلية للقلب"),
            Create(SpecializationEnum.PediatricCardiology, "Pediatric Cardiology", "قلب الأطفال"),
            Create(SpecializationEnum.Neurophysiology, "Neurophysiology", "الفسيولوجيا العصبية"),
            Create(SpecializationEnum.Hepatology, "Hepatology", "أمراض الكبد"),
            Create(SpecializationEnum.Neonatology, "Neonatology", "حديثو الولادة"),
            Create(SpecializationEnum.SurgicalOncology, "Surgical Oncology", "جراحة الأورام"),
            Create(SpecializationEnum.InterventionalRadiology, "Interventional Radiology", "الأشعة التداخلية"),
            Create(SpecializationEnum.InfertilityAndIVF, "Infertility and IVF", "العقم وأطفال الأنابيب"),
            Create(SpecializationEnum.CosmeticDermatology, "Cosmetic Dermatology", "الجلدية والتجميل"),
            Create(SpecializationEnum.SpineSurgery, "Spine Surgery", "جراحة العمود الفقري"),
            Create(SpecializationEnum.PediatricUrology, "Pediatric Urology", "مسالك بولية الأطفال"),
            Create(SpecializationEnum.BariatricSurgery, "Bariatric Surgery", "جراحات السمنة"),
            Create(SpecializationEnum.PainManagement, "Pain Management", "علاج الألم"),
            Create(SpecializationEnum.BloodTransfusionMedicine, "Blood Transfusion Medicine", "طب نقل الدم"),

            Create(SpecializationEnum.AllergyAndImmunology, "Allergy and Immunology", "الحساسية والمناعة"),
            Create(SpecializationEnum.InfectiousDiseases, "Infectious Diseases", "الأمراض المعدية"),
            Create(SpecializationEnum.MedicalGenetics, "Medical Genetics", "الوراثة الطبية"),
            Create(SpecializationEnum.OccupationalMedicine, "Occupational Medicine", "الطب المهني"),
            Create(SpecializationEnum.NuclearMedicine, "Nuclear Medicine", "الطب النووي"),
            Create(SpecializationEnum.Audiology, "Audiology", "السمعيات"),
            Create(SpecializationEnum.SpeechAndLanguageTherapy, "Speech and Language Therapy", "التخاطب وعلاج النطق"),
            Create(SpecializationEnum.OralAndMaxillofacialSurgery, "Oral and Maxillofacial Surgery", "جراحة الفم والوجه والفكين"),
            Create(SpecializationEnum.Orthodontics, "Orthodontics", "تقويم الأسنان"),
            Create(SpecializationEnum.PediatricDentistry, "Pediatric Dentistry", "طب أسنان الأطفال"),
            Create(SpecializationEnum.Endodontics, "Endodontics", "علاج جذور الأسنان"),
            Create(SpecializationEnum.Periodontology, "Periodontology", "أمراض وجراحة اللثة"),
            Create(SpecializationEnum.Prosthodontics, "Prosthodontics", "تركيبات الأسنان"),
            Create(SpecializationEnum.HandSurgery, "Hand Surgery", "جراحة اليد"),
            Create(SpecializationEnum.ColorectalSurgery, "Colorectal Surgery", "جراحة القولون والمستقيم"),
            Create(SpecializationEnum.BreastSurgery, "Breast Surgery", "جراحة الثدي"),
            Create(SpecializationEnum.SleepMedicine, "Sleep Medicine", "طب النوم")
        ];
    }

    private static Specialization Create(
        SpecializationEnum id,
        string enName,
        string arName)
    {
        return new Specialization
        {
            SpecializationId = (int)id,
            EnName = enName,
            ArName = arName,
            EnDescription = string.Empty,
            ArDescription = string.Empty,
            CreationTime = SeedDate,
            LastModificationTime = SeedDate,
            CreatorUserId = null,
            LastModifierUserId = null,
            DeleteStatusId = (int)DeleteStatusEnum.NotDeleted
        };
    }
}
