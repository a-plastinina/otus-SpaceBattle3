Feature: Сравнить вектора

    Feature Description: Сравнить коодинаты

@позитивный
Scenario: Координаты равны
    Given первый объект Vector 12,5
    When прибавить объект Vector -7,3
    Then результат равно 5,8