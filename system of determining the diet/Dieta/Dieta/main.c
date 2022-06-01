#include <stdio.h>

void main()
{

	float dieta_kalorie = 0;
	float CCM = 0;
	float PPM = 0;
	int plec = 1;
	int wiek = 20;
	int wzrost = 165;
	int tryb_zycia = 1;
	int kg = 1;
	int okres = 7;
	float waga = 55;

	if (plec == 1)
	{
		PPM = 665.09 + (9.56 * waga) + (1.85 * wzrost) - (4.67 * wiek);
	}
	else
	{
		PPM = 66.47 + (13.7 * waga) + (5.0 * wzrost) - (6.76 * wiek);
	}

	switch (tryb_zycia)
	{
	case 1:
		CCM = PPM * 1.15;
		break;
	case 2:
		CCM = PPM * 1.35;
		break;
	case 3:
		CCM = PPM * 1.6;
		break;
	case 4:
		CCM = PPM * 1.85;
		break;
	default:
		break;
	}
	
	dieta_kalorie = (PPM + CCM)- (kg*7716.17918/okres);

	printf("%f, %f, %f", PPM, CCM, dieta_kalorie);

}



int dane2()
{
	int plec = 1;
	int wiek = 20;
	int wzrost = 165;
	int tryb_zycia = 1;
	int kg = 5;
	int okres = 14;
	float waga = 55;
}



int dane()
{
	int plec, wiek, wzrost, tryb_zycia, kg, okres;
	float waga;

	printf("Podaj plec: 1- kobieta, 2-mezczyzna\n");
	if (scanf_s("%d", &plec) < 1 || ferror(stdin))
	{
		printf("Niepoprawne dane");
	}
	printf("Podaj wiek: ");
	if (scanf_s("%d", &wiek) < 1 || ferror(stdin))
	{
		printf("Niepoprawne dane");
	}

	printf("Podaj wzrost: ");
	if (scanf_s("%d", &wzrost) < 1 || ferror(stdin))
	{
		printf("Niepoprawne dane");
	}

	printf("Podaj wage: ");
	if (scanf_s("%d", &waga) < 1 || ferror(stdin))
	{
		printf("Niepoprawne dane");
	}

	printf("Podaj tryb zycia: 1-siedzacy, 2-niska aktywonosc, 3-srednia aktwnosc, 4-wysoka aktywnosc\n");
	if (scanf_s("%d", &tryb_zycia) < 1 || ferror(stdin))
	{
		printf("Niepoprawne dane");
	}

	printf("Podaj ile kg chcesz schudnac: ");
	if (scanf_s("%d", &kg) < 1 || ferror(stdin))
	{
		printf("Niepoprawne dane");
	}

	printf("Podaj okres diety w dniach: ");
	if (scanf_s("%d", &okres) < 1 || ferror(stdin))
	{
		printf("Niepoprawne dane");
	}

	return plec, wiek, wzrost, tryb_zycia, kg, okres, waga;
}