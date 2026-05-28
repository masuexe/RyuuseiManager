using System;
using System.Collections.Generic;
using System.Text;

namespace RyuuseiManager.Library.SF3
{
    public static class AbilityName
    {
        private static readonly Dictionary<Ability, string> en = new()
        {
            { Ability.Undershirt, "Undershirt" },
            { Ability.AirShoes, "Air Shoes" },
            { Ability.FloatShoes, "Float Shoes" },
            { Ability.Reflect, "Reflect" },
            { Ability.SuperArmor, "Super Armor" },
            { Ability.NoFlash, "No Flash" },
            { Ability.NoGravity, "No Gravity" },
            { Ability.NoParalyze, "No Paralyze" },
            { Ability.NoFreeze, "No Freeze" },
            { Ability.NoBubble, "No Bubble" },
            { Ability.CardHeal, "Card Heal" },
            { Ability.FirstBarrier, "First Barrier" },
            { Ability.FirstAura, "First Aura" },
            { Ability.PlusVShot, "+V-Shot" },
            { Ability.PlusXShot, "+X-Shot" },
            { Ability.PlusSpreadShot, "+Spread Shot" },
            { Ability.PlusWoodPanel, "+Wood Panel" },
            { Ability.PlusIcePanel, "+Ice Panel" },
            { Ability.PlusParaPanel, "+Para Panel" },
            { Ability.PlusGNullPanel, "+G Null Panel" },
            { Ability.PlusPoisonPanel, "+Poison Panel" },
            { Ability.CrossShotC, "Cross Shot C" },
            { Ability.SpreadC, "Spread C" },
            { Ability.MadVulcanC, "Mad Vulcan C" },
            { Ability.BigDropC, "Big Drop C" },
            { Ability.BuzzSawC, "Buzz Saw C" },
            { Ability.MuTechC, "Mu Tech C" },
            { Ability.MechFlameC, "Mech Flame C" },
            { Ability.ShurikenC, "Shuriken C" },
            { Ability.IceSpinC, "Ice Spin C" },
            { Ability.FlashStrC, "Flash Str C" },
            { Ability.PlusWind, "+Wind" },
            { Ability.PlusBlind, "+Blind" },
            { Ability.PlusPanic, "+Panic" },
            { Ability.PlusGravity, "+Gravity" },
            { Ability.PlusInvisible, "+Invisible" },
            { Ability.PlusParalyze, "+Paralyze" },
            { Ability.AutoLock, "Auto Lock" },
            { Ability.QuickGauge, "Quick Gauge" },
            { Ability.AntiDamage, "Anti Damage" },
            { Ability.DiagLock, "Diag Lock" },
            { Ability.SideLock, "Side Lock" },
            { Ability.AcePrgm, "Ace Prgm" },
            { Ability.HumorWord, "Humor Word" },
            { Ability.HumorBstr, "Humor Bstr" },
            { Ability.HumorBstr2, "Humor Bstr 2" },
            { Ability.MaxBuster, "Max Buster" },
            { Ability.BodyPack, "Body Pack" },
            { Ability.StatGuard, "Stat Guard" },
            { Ability.AreaEaterS, "Area Eater S" },
            { Ability.DblStoneS, "Dbl Stone S" },
            { Ability.GrassS, "Grass S" },
            { Ability.IceS, "Ice S" },
            { Ability.AttackPlus10S, "Attack +10 S" },
            { Ability.PnlFormatS, "Pnl Format S" },
            { Ability.WhistleS, "Whistle S" },
            { Ability.Recover30S, "Recover 30 S" },
            { Ability.PanicCloudS, "Panic Cloud S" },
            { Ability.BlackInkS, "Black Ink S" },
            { Ability.DblEaterS, "Dbl Eater S" },
            { Ability.InvisibleS, "Invisible S" },
            { Ability.ParalyzePlusS, "Paralyze+ S" },
            { Ability.ParaStageS, "Para Stage S" },
            { Ability.AttackPnlS, "Attack Pnl S" },
            { Ability.DivideLineS, "Divide Line S" },
            { Ability.BombalizerS, "Bombalizer S" },
            { Ability.NormalGAPlus, "Normal GA+" },
            { Ability.FireGAPlus, "Fire GA+" },
            { Ability.AquaGAPlus, "Aqua GA+" },
            { Ability.ElectricGAPlus, "Electric GA+" },
            { Ability.WoodGAPlus, "Wood GA+" },
            { Ability.CannonCF, "Cannon CF" },
            { Ability.MadVulcanCF, "Mad Vulcan CF" },
            { Ability.MechFlameCF, "Mech Flame CF" },
            { Ability.DrillArmCF, "Drill Arm CF" },
            { Ability.PlasmaSCF, "Plasma SCF" },
            { Ability.SprBarrierF, "Spr Barrier F" },
            { Ability.AuraF, "Aura F" },
            { Ability.GrassPnlF, "Grass Pnl F" },
            { Ability.IcePnlF, "Ice Pnl F" },
            { Ability.GNullPnlF, "G Null Pnl F" },
            { Ability.HolyPnlF, "Holy Pnl F" },
            { Ability.ParaPnlF, "Para Pnl F" },
            { Ability.HPBug1, "HP Bug 1" },
            { Ability.HPBug2, "HP Bug 2" },
            { Ability.HPBug3, "HP Bug 3" },
            { Ability.HPBug4, "HP Bug 4" },
            { Ability.StatBug1, "Stat Bug 1" },
            { Ability.StatBug2, "Stat Bug 2" },
            { Ability.StatBug3, "Stat Bug 3" },
            { Ability.StatBug4, "Stat Bug 4" },
            { Ability.MoveBug1, "Move Bug 1" },
            { Ability.MoveBug2, "Move Bug 2" },
            { Ability.MoveBug3, "Move Bug 3" },
            { Ability.MoveBug4, "Move Bug 4" },
            { Ability.BusterBug1, "Buster Bug 1" },
            { Ability.BusterBug2, "Buster Bug 2" },
            { Ability.BusterBug3, "Buster Bug 3" },
            { Ability.BusterBug4, "Buster Bug 4" },
            { Ability.HPPlus50, "HP +50" },
            { Ability.HPPlus100, "HP +100" },
            { Ability.HPPlus150, "HP +150" },
            { Ability.HPPlus200, "HP +200" },
            { Ability.HPPlus250, "HP +250" },
            { Ability.HPPlus300, "HP +300" },
            { Ability.HPPlus400, "HP +400" },
            { Ability.HPPlus500, "HP +500" },
            { Ability.MegaClassPlus1, "Mega Class +1" },
            { Ability.MegaClassPlus2, "Mega Class +2" },
            { Ability.GigaClassPlus1, "Giga Class +1" },
            { Ability.FirePlus10, "Fire +10" },
            { Ability.FirePlus20, "Fire +20" },
            { Ability.FirePlus40, "Fire +40" },
            { Ability.AquaPlus10, "Aqua +10" },
            { Ability.AquaPlus20, "Aqua +20" },
            { Ability.AquaPlus40, "Aqua +40" },
            { Ability.ElectricPlus10, "Electric +10" },
            { Ability.ElectricPlus20, "Electric +20" },
            { Ability.ElectricPlus40, "Electric +40" },
            { Ability.WoodPlus10, "Wood +10" },
            { Ability.WoodPlus20, "Wood +20" },
            { Ability.WoodPlus40, "Wood +40" },
            { Ability.SwordPlus10, "Sword +10" },
            { Ability.SwordPlus20, "Sword +20" },
            { Ability.SwordPlus40, "Sword +40" },
            { Ability.BreakPlus10, "Break +10" },
            { Ability.BreakPlus20, "Break +20" },
            { Ability.BreakPlus30, "Break +30" },
            { Ability.TurnPlus1F, "Turn +1 F" },
            { Ability.TurnPlus2F, "Turn +2 F" },
            { Ability.AccessLVPlus1, "Access LV +1" },
            { Ability.NormalStar, "Normal Star" },
            { Ability.FireStar, "Fire Star" },
            { Ability.AquaStar, "Aqua Star" },
            { Ability.ElecStar, "Elec Star" },
            { Ability.WoodStar, "Wood Star" },
            { Ability.SwordStar, "Sword Star" },
            { Ability.BreakStar, "Break Star" },
            { Ability.JokerPrgm, "Joker Prgm" },
        };

        private static readonly Dictionary<Ability, string> ja = new()
        {

        };

        private static readonly Dictionary<Ability, string> zh_cn = new()
        {

        };

        private static readonly Dictionary<Ability, string> zh_tw = new()
        {

        };

        public static string GetAbilityName(Ability ability, int language)
        {
            Dictionary<Ability, string> targetLanguage = new Dictionary<Ability, string>();
            switch (language)
            {
                case 0: targetLanguage = en; break;
                case 1: targetLanguage = ja; break;
                case 2: targetLanguage = zh_cn; break;
                case 3: targetLanguage = zh_tw; break;
            }
            if (targetLanguage.TryGetValue(ability, out string? value))
            {
                return value;
            }
            else
            {
                return "(null)";
            }
        }
    }
}
