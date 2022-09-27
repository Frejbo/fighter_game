int enemy_hp = 20;
int my_hp = 20;

Random random = new Random();

while (enemy_hp > 0 && my_hp > 0) {
    Console.WriteLine($"Du har {my_hp} hp.");
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
        } else if (axe_hurt_rate > 0 && !(enemy_hp >= 4)) {
            Console.WriteLine("Du högg din fiende i armen och hen tappade 3 hp.");
            enemy_hp -= 3;
        } else if (axe_hurt_rate == 4) {
            Console.WriteLine("Du drog ett skitbra drag och träffade din fiendes hals, hen tappade 5 hp!");
            enemy_hp -= 5;
        } else if (axe_hurt_rate == 5) {
            Console.WriteLine("Attans! Din fiende tog fram sin sköld och dämpade ditt slag. Varken du eller din fiende gjorde någon skada.");
            continue;
        }
    }

    int my_pain = random.Next(0, 5);
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
    }
    my_hp -= my_pain;

    Console.WriteLine(enemy_hp);
}


Console.ReadLine();
