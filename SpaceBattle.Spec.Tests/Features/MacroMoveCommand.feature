Feature: Правило при движении расходуется топливо

    Feature Description: Сжигание топлива при движении

    @позитивный
    Scenario: Выполнить движение, расход топлива
        Given создать объект IFuelObject с топливом 15, скоростью 6
        And создать MacroMoveCommand
        When выполнить MacroMoveCommand
        Then все шаги MacroMoveCommand выполнены

    @негативный
    Scenario: Недостаточно топлива выполнить движение, расход топлива
        Given создать объект IFuelObject с топливом 5, скоростью 6
        And создать MacroMoveCommand
        When выполнить MacroMoveCommand
        Then выброшено исключение в MacroMoveCommand