Feature: Правило при движении с поворотом меняется мгновенная скорость

    Feature Description: движение с поворотом

    @позитивный
    Scenario: Выполнить поворот объекта в движении
        Given создать объект IMovable
        And установить направление 4, угловую скорость 2 и количество секторов 8
        When выполнить MacroRotateCommand
        Then мгновенная скорость изменена

    @негативный
    Scenario: Выполнить поворот статичного объекта
        Given создать объект с направлением 2, угловую скорость 2 и количество секторов 8
        When выполнить MacroRotateCommand
        Then мгновенная скорость не изменялась