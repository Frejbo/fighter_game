int enemy_hp = 30;
int my_hp = 30;

Random random = new Random();

while (enemy_hp > 0 && my_hp > 0) {
    Console.WriteLine($"\nDu har {my_hp} hp.");
    Console.WriteLine($"Din fiende har {enemy_hp} hp.");
    Console.ReadLine();
    
    Console.WriteLine("\nVälj ditt vapen:");
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

    if (my_chosen_weapon == 1) {
        Console.WriteLine("Du slog till din fiende lite patetiskt på kinden med höger knytnäve och hen tappade 1 hp.");
        enemy_hp -= 1;
    } else if (my_chosen_weapon == 2) {
        int axe_hurt_rate = random.Next(0, 5);
        if (axe_hurt_rate == 0) {
            Console.WriteLine("Du missade! Din fiende tog 0 i skada.");
        } else if (axe_hurt_rate == 4) {
            Console.WriteLine("Du drog ett skitbra drag och träffade din fiendes hals, hen tappade 5 hp!");
            enemy_hp -= 5;
        } else if (axe_hurt_rate == 5) {
            Console.WriteLine("Attans! Din fiende tog fram sin sköld och dämpade ditt slag. Varken du eller din fiende gjorde någon skada.");
            continue;
        } else {
            Console.WriteLine("Du högg din fiende i armen och hen tappade 3 hp.");
            enemy_hp -= 3;
        }
    } else if (my_chosen_weapon == 3) {
        int hammer_hurt_rate = random.Next(0, 1);
        if (hammer_hurt_rate == 0) {
            Console.WriteLine("Vem fan fightas med en hammare? Din fiende blev förvirrad och tappade sitt vapen. Du drog ett hårt slag och din fiende tappade 2 hp.");
            Console.WriteLine("Din fiende gjorde ingen skada på dig.");
            enemy_hp -= 2;
            continue;
        } else {
            Console.WriteLine("Du slog din fiende i magen med hammaren men hen tappade endast 1 hp.");
        }
    } else if (my_chosen_weapon == 4) {
        Console.WriteLine("Du tog fram din kniv och högg din fiende i benet. Din fiende tappade 3 hp.");
        enemy_hp -= 3;
    }

    int my_pain = random.Next(0, 4);
    if (my_pain == 0) {
        Console.WriteLine("Din fiende missade och högg i marken!");
        Console.WriteLine("Du tog ingen skada.");
    } else if (my_pain == 1) {
        Console.WriteLine("Din fiende sträckte sig efter sin kniv men råkade ta fel och fick bara upp ett rakblad!");
        Console.WriteLine("Du tappade 1 hp.");
    } else if (my_pain == 2) {
        Console.WriteLine("Din fiende slog dig i ansiktet med knytnäven");
        Console.WriteLine("Du tappade 2 hp.");
    } else if (my_pain == 3) {
        Console.WriteLine("Din fiende tog sin kniv och högg dig i armen");
        Console.WriteLine("Du tappade 3 hp.");
    } else if (my_pain == 4) {
        Console.WriteLine("Din fiende tog en yxa och högg dig i magen");
        Console.WriteLine("Du tappade 5 hp.");
    }
    my_hp -= my_pain;
}

if (enemy_hp <= 0 && my_hp > 0) {
    Console.WriteLine("Du vann mot din fiende!");
} else if (my_hp <= 0 && enemy_hp > 0) {
    Console.WriteLine("Du föll ihop på marken och förblödde plågsamt. Du förlorade.");
} else {
    Console.WriteLine("Ni båda föll ihop på marken och förblödde medan ni såg varann i ögonen. Det skapades nästan en lite romantisk spänning emellan er när ni låg där och kollade på varandra. Du kände att du ångrade allt som hänt och ville börja om som vänner, men det var försent nu...");
}


Console.ReadLine();
