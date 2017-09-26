# ProjectTemplate

Ukazkovy projekt pre urcenie zakladnej architektury projektu v unity

!! citajte design.txt v jednotlivich scripts adresaroch!
Ciel:
Vytovrit ukazku zakladnej architektury, ulohou nie je konkretna hra ale architektura projektu na jej tvorbu navrhnuta tak,
aby sa na nej dal spravit aj jednoduchy prototyp aj velky projekt. Vsetky jej casti treba dalej rozvijat.
Spolocne casti je vhodne oddelit tak, aby sa dali zdielat medzi projektami.

Hlavne body:

1. zavyslosti riesene cez dependency injection, nie cez service locator pattern. S pomocou Zenject DI.
2. podpora MVC patternu cez EventAggregator pattern, ktory zlahcuje komunikaciu jednotlivych casti
3. zjednotene nacitavanie definici
4. zakladne rozlozenie suborov v projekte
