int enemy_hp = 30;
int my_hp = 30;

Console.WriteLine("Vad heter din fiende?");
string enemy_name = Console.ReadLine();
while (enemy_name.Length < 2 || enemy_name.Length >= 20) {
    Console.WriteLine($"Din fiendes namn måste vara mellan 2 - 20 tecken, men ditt valda namn var {enemy_name.Length}.\nFörsök igen:");
    enemy_name = Console.ReadLine();
}

Random random = new Random();


while (enemy_hp > 0 && my_hp > 0) {
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine($"\nDu har {my_hp} hp.");
    Console.WriteLine($"{enemy_name} har {enemy_hp} hp.");
    Console.ResetColor();
    Console.ReadLine();
    
    Console.WriteLine("Välj ditt vapen:");
    int my_chosen_weapon = 0;
    while (my_chosen_weapon == 0) {
        Console.WriteLine("1. Knytnäve\n2. Yxa\n3. Hammare\n4. Kniv");
        string temp_chosen = Console.ReadLine();
        
        if (!int.TryParse(temp_chosen, out int number)) {
            Console.WriteLine("Du måste skriva en siffra mellan 1 - 4.\n");
            continue;
        } else if (!(number <= 4 && number > 0)) {
            Console.WriteLine("Ditt svar var utanför de möjliga alternativen.\n");
            continue;
        } else {
            my_chosen_weapon = number;
        }
    }
    
    Console.WriteLine();

    if (my_chosen_weapon == 1) {
        Console.WriteLine($"Du slog till {enemy_name} lite patetiskt på kinden med höger knytnäve.");
        decrease_enemy_hp(1);
    } else if (my_chosen_weapon == 2) {
        int axe_hurt_rate = random.Next(0, 6);
        if (axe_hurt_rate == 0) {
            Console.WriteLine($"Du missade! {enemy_name} tog 0 i skada.");
        } else if (axe_hurt_rate == 4) {
            Console.WriteLine($"Du drog ett skitbra drag och träffade {enemy_name}'s hals!");
            decrease_enemy_hp(5);
        } else if (axe_hurt_rate == 5) {
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
        } else {
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
    }

    int my_pain_rate = random.Next(0, 12);
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
    } else if (my_pain_rate <= 7) {
        Console.WriteLine($"{enemy_name} tog en yxa och högg dig i magen");
        decrease_my_hp(5);
    } else if (my_pain_rate == 8) {
        Console.WriteLine($"{enemy_name} tog fram sin hårtork och blåste dig i ansiktet tills du fick ett brännmärke och ramlade omkull.");
        decrease_my_hp(5);
    } else if (my_pain_rate <= 10) {
        System.Console.WriteLine($"{enemy_name} brottade ner dig på marken och högg dig med en smörkniv.");
        decrease_my_hp(3);
    } else if (my_pain_rate == 11) {
        System.Console.WriteLine($"{enemy_name} lekte sur tant och slog till dig med sin handväska.");
        decrease_my_hp(1);
    }
}

if (enemy_hp <= 0 && my_hp > 0) {
    Console.WriteLine($"Du vann mot {enemy_name}!");
} else if (my_hp <= 0 && enemy_hp > 0) {
    Console.WriteLine($"Du föll ihop på marken och förblödde plågsamt. {enemy_name} vann.");
} else {
    Console.WriteLine($"Ni båda föll ihop på marken och förblödde medan ni såg varann i ögonen. Det skapades nästan en lite romantisk spänning mellan dig och {enemy_name} när ni låg där och kollade på varandra. Du kände att du ångrade allt som hänt och ville börja om som vänner, men det var försent nu... Du kollade {enemy_name} i ögonen medan hen tog sitt sista andetag. Det var bara en tidsfråga tills samma sak skulle hända dig... när som helst nu...");
}

void decrease_my_hp(int amount) {
    my_hp -= amount;
    Console.ForegroundColor = ConsoleColor.Red;
    System.Console.WriteLine($"Du tappade {amount} hp.");
    Console.ResetColor();
}

void decrease_enemy_hp(int amount) {
    enemy_hp -= amount;
    Console.ForegroundColor = ConsoleColor.Green;
    System.Console.WriteLine($"{enemy_name} tappade {amount} hp.");
    Console.ResetColor();
}


Console.ReadLine();
