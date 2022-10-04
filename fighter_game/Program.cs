int enemy_hp = 30;
int my_hp = 30;
bool boosted_attack = false;
Random random = new Random();
List<string> body_harm = new List<string>();


namnge:
Console.WriteLine("Vad heter din fiende?");
string enemy_name = Console.ReadLine();
while (enemy_name.Length < 2 || enemy_name.Length >= 20) {
    Console.WriteLine($"Din fiendes namn måste vara mellan 2 - 20 tecken, men ditt valda namn var {enemy_name.Length}.\nFörsök igen:");
    enemy_name = Console.ReadLine();
}


while (true) {
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine($"Du har {my_hp} hp.");
    Console.WriteLine($"{enemy_name} har {enemy_hp} hp.");
    Console.ResetColor();
    
    Console.WriteLine("Välj ditt vapen:");
    int my_chosen_weapon = 0;
    while (my_chosen_weapon == 0) {
        Console.WriteLine("1. Knytnäve\n2. Yxa\n3. Hammare\n4. Kniv\n5. Hink med vatten");
        string temp_chosen = Console.ReadLine();
        
        if (!int.TryParse(temp_chosen, out int number)) {
            Console.WriteLine("Du måste skriva en siffra mellan 1 - 5.\n");
            continue;
        } else if (!(number <= 5 && number > 0)) {
            Console.WriteLine("Ditt svar var utanför de möjliga alternativen.\n");
            continue;
        } else {
            my_chosen_weapon = number;
        }
    }
    
    load_delay();

    if (my_chosen_weapon == 1) {
        Console.WriteLine($"Du slog till {enemy_name} lite patetiskt på kinden med höger knytnäve.");
        decrease_enemy_hp(1);
    } else if (my_chosen_weapon == 2) {
        int axe_hurt_rate = random.Next(0, 6);
        if (axe_hurt_rate == 0) {
            Console.WriteLine($"Du missade! {enemy_name} tog 0 i skada.");
        } else if (axe_hurt_rate == 1) {
            Console.WriteLine($"Du drog ett skitbra drag och träffade {enemy_name}'s hals!");
            decrease_enemy_hp(5);
        } else if (axe_hurt_rate == 2) {
            Console.WriteLine($"Attans! {enemy_name} tog fram sin sköld och dämpade ditt slag. Varken du eller {enemy_name} gjorde någon skada.");
            continue;
        } else {
            Console.WriteLine($"Du högg {enemy_name} i armen med yxan.");
            decrease_enemy_hp(3);
        }
    } else if (my_chosen_weapon == 3) {
        int hammer_hurt_rate = random.Next(0, 4);
        if (hammer_hurt_rate == 0) {
            Console.WriteLine($"Vem fan fightas med en hammare? {enemy_name} blev förvirrad och tappade sitt vapen. Du drog ett hårt slag.");
            Console.WriteLine($"{enemy_name} gjorde ingen skada på dig.");
            decrease_enemy_hp(2);
            continue;
        } else if (hammer_hurt_rate == 1) {
            Console.WriteLine($"Du slog {enemy_name} på lilltån och hen ramlade omkull och tappade sitt vapen. Dessvärre flög hens yxa mot dig och träffade dig i ansiktet.");
            decrease_my_hp(4);
            decrease_enemy_hp(3);
            body_harm.Add("ansikte - yxa");
            continue;
        } 
        else {
            Console.WriteLine($"Du slog {enemy_name} i magen med hammaren, desvärre var {enemy_name} väldigt fet och hens mage dämpade slaget.");
        }
    } else if (my_chosen_weapon == 4) {
        int kniv_hurt_rate = random.Next(0, 2);
        if (kniv_hurt_rate == 0) {
            Console.WriteLine($"Du tog fram din kniv och högg {enemy_name} i benet.");
            decrease_enemy_hp(3);
        } else if (kniv_hurt_rate == 1) {
            Console.WriteLine($"Du skulle precis ta upp kniven för att slå {enemy_name}, men du slank och skar dig själv istället!");
            Console.ForegroundColor = ConsoleColor.Red;
            my_hp -= 2;
            Console.ResetColor();
        }
    } else if (my_chosen_weapon == 5) {
        if (random.Next(0, 2) == 0) {
            Console.WriteLine($"Du friskade upp {enemy_name} med en hink kallvatten. {enemy_name} gjorde 1 extra skada på dig.");
            boosted_attack = true;
        } else {
            Console.WriteLine($"Du hällde kallt vatten över {enemy_name} så hen fick en kallsup.");
            decrease_enemy_hp(2);
        }
    }

    load_delay();

    int my_pain_rate = random.Next(12, 13);
    if (my_pain_rate == 0) {
        Console.WriteLine($"{enemy_name} missade och högg i marken!");
        Console.WriteLine("Du tog ingen skada.");
    } else if (my_pain_rate == 1) {
        Console.WriteLine($"{enemy_name} sträckte sig efter sin kniv men råkade ta fel och fick bara upp ett rakblad!");
        decrease_my_hp(1);
    } else if (my_pain_rate == 2) {
        Console.WriteLine($"{enemy_name} slog dig i ansiktet med knytnäven");
        decrease_my_hp(2);
    } else if (my_pain_rate < 5) {
        Console.WriteLine($"{enemy_name} tog sin kniv och högg dig i armen");
        decrease_my_hp(3);
        body_harm.Add("arm");
    } else if (my_pain_rate <= 7) {
        Console.WriteLine($"{enemy_name} tog en yxa och högg dig i magen");
        decrease_my_hp(5);
        body_harm.Add("mage");
    } else if (my_pain_rate == 8) {
        Console.WriteLine($"{enemy_name} tog fram sin hårtork och blåste dig i ansiktet tills du fick ett brännmärke och ramlade omkull.");
        decrease_my_hp(5);
        body_harm.Add("ansikte - hårtork");
    } else if (my_pain_rate <= 10) {
        Console.WriteLine($"{enemy_name} brottade ner dig på marken och högg dig med en smörkniv.");
        decrease_my_hp(2);
    } else if (my_pain_rate == 11) {
        Console.WriteLine($"{enemy_name} lekte sur tant och slog till dig med sin handväska.");
        decrease_my_hp(1);
    } else if (my_pain_rate == 12) {
        Console.WriteLine($"Du svimmade. {enemy_name} hade slagit dig så hårt att du föll omkull och svimmade. {enemy_name} trodde därmed att du var död så hen gjorde ingen mer skada på dig.");
        load_delay();
        Console.WriteLine($"Du öppnade ögonen och såg hur du på något sätt är i din säng, vem hade burit dig hit? Kan det ha varit {enemy_name} som ångrade sig? Nej, det skulle aldrig ske. Du reste dig upp och kollade på klockan.");
        load_delay();
        Console.WriteLine("Du försöker fokusera dina ögon för att läsa tiden på mobilskärmen");
        load_delay();
        Console.WriteLine($"Måndag 05:47!");
        decrease_my_hp(1);
        load_delay();
        Console.WriteLine("Fan fan fan! Helvetes! - ropade du ut i din ensamma lägenhet.");
        load_delay();
        Console.WriteLine("Måndag morgon var det värsta du visste! Nu skulle du behöva åka in till jobbet och umgås med dina dumma kollegor!");
        load_delay();
        if (body_harm.Contains("arm")) {
            Console.WriteLine($"Du fick syn på ditt köttsår på armen, hade {enemy_name} gjort detta?");
            load_delay();
        } else if (body_harm.Contains("mage")) {
            Console.WriteLine($"Du tittade ner och fick syn på din mage - den var helt blodig! hade {enemy_name} gjort detta? Eller hade jag snubblat? Vad hände?");
            load_delay();
        }
        Console.WriteLine("Du reste dig från sängen och gick till badrummet för att borsta tänder.");
        if (body_harm.Contains("ansikte - yxa")) {
            Console.WriteLine("När du kom in i badrummet fick du syn på spegeln, herregud! Hur såg du ut? Du var alldeles röd och blodig i ansiktet! Det var nästan som att någon slagit dig med en yxa!");
            load_delay();
            Console.WriteLine("Du ringde direkt sjukhuset och du fick en akuttid.");
        } else {
            if (body_harm.Contains("ansikte - hårtork")) {
                Console.WriteLine("När du kom in i badrummet kollade du i spegeln, vad röd du var! Du hade brännmärken över hela ansiktet! Vad hade hänt?");
            }
            Console.WriteLine("Du borstade tänderna och gick ut i hallen.");
        }
        // åk hemifrån, sjukhus eller jobb.
    }
    if (enemy_hp <= 0 | my_hp <= 0) {
        if (enemy_hp <= 0 && my_hp > 0) {
            Console.WriteLine($"Du vann mot {enemy_name}!");
        } else if (my_hp <= 0 && enemy_hp > 0) {
            Console.WriteLine($"Du föll ihop på marken och förblödde plågsamt. {enemy_name} vann.");
        } else {
            Console.WriteLine($"Ni båda föll ihop på marken och förblödde medan ni såg varann i ögonen. Det skapades nästan en lite romantisk spänning mellan dig och {enemy_name} när ni låg där och kollade på varandra. Du kände att du ångrade allt som hänt och ville börja om som vänner, men det var försent nu... Du kollade {enemy_name} i ögonen medan hen tog sitt sista andetag. Det var bara en tidsfråga tills samma sak skulle hända dig... när som helst nu...");
        }

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n\nVill du spela igen?");
        Console.ResetColor();
        if (Console.ReadLine().ToLower() == "ja") {
            Console.Clear();
            enemy_hp = 30;
            my_hp = 30;
            goto namnge;
        } else {
            Environment.Exit(0);
        }
    } else {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Tryck enter för att fortsätta till nästa runda");
        Console.ResetColor();
        Console.ReadLine();
    }
}



void decrease_my_hp(int amount) {
    my_hp -= amount;
    Console.ForegroundColor = ConsoleColor.Red;
    System.Console.WriteLine($"Du tappade {amount} hp.");
    Console.ResetColor();
}

void decrease_enemy_hp(int amount) {
    if (boosted_attack) {
        amount += 1;
        boosted_attack = false;
    }
    enemy_hp -= amount;
    Console.ForegroundColor = ConsoleColor.Green;
    System.Console.WriteLine($"{enemy_name} tappade {amount} hp.");
    Console.ResetColor();
}

void load_delay() {
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    System.Threading.Thread.Sleep(300);
    Console.Write(".");
    System.Threading.Thread.Sleep(300);
    Console.Write(".");
    System.Threading.Thread.Sleep(300);
    Console.Write(".");
    System.Threading.Thread.Sleep(300);
    Console.Write("\b\b\b");
    // Console.WriteLine();
    Console.ResetColor();
}


Console.ReadLine();
