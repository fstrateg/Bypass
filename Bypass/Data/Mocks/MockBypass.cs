﻿using Bypass.Data.Types;
using System;
using System.Collections.Generic;

namespace Bypass.Data.Mocks
{
    public class MockBypass : Interfaces.IBypassItems
    {
        public IEnumerable<BypassItem> GetAllItems()
        {
            List<BypassItem> rez = new List<BypassItem>();
            BypassItem p = new BypassItem()
            {
                ID = "10000000000001024633",
                DocDate = "09.12.2021 09:07:39",
                EventDate = new DateTime(2021, 12, 16).ToShortDateString(),
                TypeName = "увольнение",
                Staff = "Москва | Региональное представительство | Маркетолог",
                Remark = "Собственное желание",
                ObjCaption = "Гаевая Валентина Анатольевна| 29.05.1990",
                P108 = -1,
                P124 = 0,
                P138 = 0,
                P183 = 1,
                P314 = 2,
                P363 = 0,
                P405 = 0,
                P758 = 2,
                P778 = 0,
                Info = "",
                Object_id = "1000002353777773",
                ZverContract = "АДМЗР",
                Zverid = "ГАЕВАЯ ВА"

            };
            p.Info = @"Отдел 138->Дата: 15.12.2021; Оператор: Бектемиров Марс Акылбекович | 06.09.1973; Долги: Нет долгов -> Нет долгов; Прислал документ : Автопроверка остатков
Отдел 183->Дата: 09.12.2021; Оператор: Бектемиров Марс Акылбекович | 06.09.1973; Долги: Есть долги -> Есть долги по КИС Глобус; Прислал документ : Автопроверка остатков
Отдел 314->Не проверен
Отдел 405->Дата: 16.12.2021; Оператор: Петрунин Антон Александрович | 04.06.1975; Долги: Нет долгов -> Нет долгов; Прислал документ : Автопроверка остатков
Отдел 778->Дата: 16.12.2021; Оператор: Урманцев Борис Маратович | 12.11.1981; Долги: Нет долгов
Отдел 363->Дата: 16.12.2021; Оператор: Шинкарев Тарас Владимирович | 22.03.1980; Долги: Нет долгов
Отдел 124->Дата: 15.12.2021; Оператор: Калинина Оксана Владимировна | 18.09.1969; Долги: Нет долгов
Отдел 108->Дата: 15.12.2021; Оператор: Калинина Оксана Владимировна | 18.09.1969; Долги: Нет долгов
Отдел 758->Не проверен";
            rez.Add(p);
            p = new BypassItem()
            {
                ID = "10000000000001019682",
                DocDate = "07.12.2022 17:35:01",
                EventDate = "01.12.2020",
                TypeName = "увольнение",
                Staff = "Москва | Региональное представительство | Менеджер по продажам",
                Remark = "ПН -746 | Нарушение финансовой дисциплины",
                ObjCaption = "Потрясилов Павел Владимирович| 10.07.1984",
                P108 = 1,
                P124 = 1,
                P138 = 0,
                P183 = 0,
                P314 = 0,
                P363 = 0,
                P405 = 0,
                P758 = 0,
                P778 = 0,
                Info = "",
                Object_id = "1000002330045370",
                ZverContract = "АДМЗР",
                Zverid = "ПОТРЯСИЛО ПВ"

            };
            p.Info = @"Отдел 138 -> Дата: 08.12.2020; Оператор: Бектемиров Марс Акылбекович|06.09.1973; Долги: Нет долгов -> Нет долгов; Прислал документ : Автопроверка остатков
Отдел 183->Дата: 08.12.2020; Оператор: Бектемиров Марс Акылбекович | 06.09.1973; Долги: Нет долгов -> Нет долгов; Прислал документ : Автопроверка остатков
Отдел 314->Дата: 08.12.2020; Оператор: Бектемиров Марс Акылбекович | 06.09.1973; Долги: Нет долгов
Отдел 405->Дата: 10.12.2020; Оператор: Петрунин Антон Александрович | 04.06.1975; Долги: Нет долгов -> Нет долгов; Прислал документ : Автопроверка остатков
Отдел 778->Дата: 08.12.2020; Оператор: Урманцев Борис Маратович | 12.11.1981; Долги: Нет долгов
Отдел 363->Дата: 09.12.2020; Оператор: Шинкарев Тарас Владимирович | 22.03.1980; Долги: Нет долгов
Отдел 124->Дата: 09.12.2020; Оператор: Калинина Оксана Владимировна | 18.09.1969; Долги: Есть долги
Отдел 108->Дата: 09.12.2020; Оператор: Калинина Оксана Владимировна | 18.09.1969; Долги: Есть долги
Отдел 758->Дата: 08.12.2020; Оператор: Бектемиров Марс Акылбекович | 06.09.1973; Долги: Нет долгов";
            rez.Add(p);
            return rez;
        }
    }
}