﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_Assist
{
    public class o_Result
    {
        public static string FullName { get; set; }
        public static string IDNO { get; set; }
        public static string Gender { get; set; }
        public static string DOB { get; set; }
        public static string LabNumber { get; set; }
        public static string DateReceived { get; set; }
      
        public static string ProductID { get; set; }
        public static string TestCode { get; set; }
        public static string SD_BioLine { get; set; }
        public static string Abbot_Determine { get; set; }
        public static string Final_Result { get; set; }

        public static string TimeEntered { get; set; }
        public static string Doctor { get; set; }
        public static string Hospital { get; set; }
        public static string Cryptococcal_Antigen { get; set; }
        public static string Titre { get; set; }
        public static string WBC { get; set; }
        public static string RBC { get; set; }
        public static string HGB { get; set; }
        public static string HCT { get; set; }
        public static string MVC { get; set; }
        public static string MCH { get; set; }
        public static string MCHC { get; set; }
        public static string RDW_CV { get; set; }
        public static string PLT { get; set; }
        public static string MPV { get; set; }
        public static string Neutrophils { get; set; }
        public static string Lymphocytes { get; set; }
        public static string Monocytes { get; set; }
        public static string Eosinophils { get; set; }
        public static string Basophils { get; set; }
        public static string C_Reactive_Protein { get; set; }
        public static string ESR { get; set; }
        public static string Malaria_ICT { get; set; }
        public static string Microscopy { get; set; }
        public static string BloodGroup { get; set; }
        public static string Sodium { get; set; }
        public static string Potassium { get; set; }
        public static string Chloride { get; set; }
        public static string Bicarbonate { get; set; }
        public static string Urea { get; set; }
        public static string Creatinine { get; set; }
        public static string eGFR { get; set; }
        public static string Total_Protein { get; set; }
        public static string Albumin { get; set; }
        public static string Bilirubin_Total { get; set; }
        public static string Bilirubin_Direct { get; set; }
        public static string GGT { get; set; }
        public static string ALP { get; set; }
        public static string AST { get; set; }
        public static string ALT { get; set; }
        public static string Total_Cholesterol { get; set; }
        public static string Triglycerides { get; set; }
        public static string HighDensity_lipoprotein_HDL { get; set; }
        public static string LowDensity_lipoprotein { get; set; }
        public static string BloodGlucose { get; set; }
        public static string HelicobacterPylori_SerumAntibody { get; set; }
        public static string HelicobacterPylori_StoolAntigen { get; set; }
        public static string TPHA { get; set; }
        public static string RPR { get; set; }
        public static string HbsAg { get; set; }
        public static string Rubella_IgM { get; set; }
        public static string Rubella_IgG { get; set; }
        public static string ANA { get; set; }
        public static string ANA_Titre { get; set; }
        public static string RheumatoidFactor { get; set; }
        public static string HbA1C { get; set; }
        public static string AverageBloodGlucose { get; set; }
        public static string SalmonellaTyphi_O_Antigen { get; set; }
        public static string SalmonellaTyphi_H_Antigen { get; set; }
        public static string SalmonellaTyphi_AH_Antigen { get; set; }
        public static string SalmonellaTyphi_BH_Antigen { get; set; }
        public static string SalmonellaTyphi_AO_Antigen { get; set; }
        public static string SalmonellaTyphi_BO_Antigen { get; set; }
        public static string FT3 { get; set; }
        public static string FT4 { get; set; }
        public static string TSH { get; set; }
        public static string ProstateSpecificAntigen { get; set; }
        public static string Testosterone { get; set; }
        public static string Progesterone { get; set; }
        public static string Oestradiol_E2 { get; set; }
        public static string BetaHumanChorionicGonadotropin { get; set; }
        public static string Colour { get; set; }
        public static string Clarity_Turbidity { get; set; }
        public static string pH { get; set; }
        public static string SpecificGravity { get; set; }
        public static string Glucose { get; set; }
        public static string Ketones { get; set; }
        public static string Nitrites { get; set; }
        public static string Leucocytes { get; set; }
        public static string Bilirubin { get; set; }
        public static string Urobilirubin { get; set; }
        public static string Blood { get; set; }
        public static string Protein { get; set; }
        public static string RBCs { get; set; }
        public static string WBCs { get; set; }
        public static string SquamousEpithelialCells { get; set; }
        public static string Casts { get; set; }
        public static string Crystals { get; set; }
        public static string Bacteria { get; set; }
        public static string Yeast { get; set; }
        public static string T_Vaginalis { get; set; }
        public static string S_Haematobium { get; set; }
        public static string Culture { get; set; }
        public static string Amphetamines { get; set; }
        public static string Barbiturates { get; set; }
        public static string Benzodiazepines { get; set; }
        public static string Cocaine { get; set; }
        public static string Methamphetamines_MDMA { get; set; }
        public static string Methadone { get; set; }
        public static string Opiates { get; set; }
        public static string Phencyclidine_PCP { get; set; }
        public static string Tricyclic_Antidepressants_TCAs { get; set; }
        public static string Tetrahydrocannabinols_THC { get; set; }
        public static string T_HelperLymphocytesCD4plus { get; set; }
        public static string TotalLymphocytesCD3plus { get; set; }
        public static string HIV_RNA { get; set; }
        public static string LogValue { get; set; }
        public static string NeisseriaGonorrhoeaPCR { get; set; }
        public static string NeisseriaGonorrhoeaIgM { get; set; }
        public static string NeisseriaGonorrhoeaIgG { get; set; }
        public static string ChlamydiaTrachomatisPCR { get; set; }
        public static string ChlamydiaTrachomatisIgM { get; set; }
        public static string ChlamydiaTrachomatisIgG { get; set; }
        public static string UricAcid { get; set; }
        public static string VitaminB12 { get; set; }
        public static string Folate { get; set; }
        public static string SemenApperance { get; set; }
        public static string SemenVolume { get; set; }
        public static string SemenpH { get; set; }
        public static string SemenLiquificationTime { get; set; }
        public static string SpermCount { get; set; }
        public static string TotalMotility { get; set; }
        public static string ProgressiveMotility { get; set; }
        public static string Morphology { get; set; }
        public static string CalculatedMotileFunction { get; set; }
        public static string ProthrombinTime { get; set; }
        public static string INR { get; set; }
        public static string CK_MB { get; set; }
        public static string Troponin1 { get; set; }
        public static string NT_pro_BNP { get; set; }
        public static string PregnancyTest { get; set; }
        public static string AST_ALTRatio { get; set; }
        public static string HighlySensitiveCRP { get; set; }
        public static string Prolactin { get; set; }
        public static string D_Dimer { get; set; }
        public static string LactateDehydrogenaseLDH { get; set; }
        public static string Ferritin { get; set; }
        public static string UrineAlbumin { get; set; }
        public static string UrineCreatinine { get; set; }
        public static string UrineAlbumin_CreatinineRatio { get; set; }
        public static string FollicleStimulatingHormone { get; set; }
        public static string LeutenizingHormone { get; set; }
        public static string ThytoidStimulatingHormone { get; set; }
        public static string HepatitisAVirusIgGAntibody { get; set; }
        public static string HepatitisAVirusIgMAntibody { get; set; }
        public static string HepatitisBSurfaceAntigen { get; set; }
        public static string HepatitisBSurfaceAntibody { get; set; }
        public static string HepatitisCAntibody { get; set; }
        public static string HepatitisCCoreAntigen { get; set; }
        public static string TotalCalcium { get; set; }
        public static string TotalMagnesium { get; set; }
        public static string Phosphate { get; set; }
        public static string Ciprofloxacin { get; set; }
        public static string Cefuroxime { get; set; }
        public static string Clindamycin { get; set; }
        public static string Erythromycin { get; set; }
    public static string Gentamycin { get; set; }
    public static string Kanamycin { get; set; }
    public static string Ampicilin { get; set; }
    public static string Tetracyclin { get; set; }
    public static string GramStain_FirstColony { get; set; }
    public static string GramStain_SecondColony { get; set; }
    public static string Culture_FirstColony { get; set; }
    public static string Culture_SecondColony { get; set; }
    public static string MycobacteriumTuberculosis { get; set; }
    public static string RifampicinResistance { get; set; }
    public static string CarcinoembryonicAntigen { get; set; }
    public static string UrineBetahCG { get; set; }
    public static string Ceftriaxone { get; set; }
    public static string Ampicillin { get; set; }
    public static string Cotrimoxazole { get; set; }
    public static string Appearance { get; set; }
    public static string WetPreparation { get; set; }
    public static string FastingBaseline { get; set; }
    public static string OneHourPostGlucoseLoad { get; set; }
    public static string TwoHoursPostGlucoseLoad { get; set; }
    public static string HerpesSimplex1HSV1_IgM { get; set; }
    public static string HerpesSimplex1HSV1_IgG { get; set; }
    public static string HerpesSimplex2HSV2_IgM { get; set; }
    public static string HerpesSimplex2HSV2_IgG { get; set; }
    public static string ToxoplasmaIgM { get; set; }
    public static string ToxoplasmaIgG { get; set; }
    public static string CytomegalovirusIgM { get; set; }
    public static string CytomegalovirusIgG { get; set; }
    public static string IonizedCalcium2Plus { get; set; }
    public static string Phosphate3Plus { get; set; }
    public static string HepatitisAVirusAntibody_IgM { get; set; }
    public static string SARSCOV2 { get; set; }
    public static string ReferenceInterval { get; set; }
    public static string ResultDocument { get; set; }
    public static string Comment { get; set; }
    public static string Payment_Status { get; set; }
    public static string CreatedBy { get; set; }

    }
}