Тема: "Онлайн-магазин".

Паттерны проектирования:
1. Порождающий паттерн: Прототип. Позволяет создавать новые объекты путем клонирования уже существующих объектов-прототипов. В контексте онлайн-магазина, прототип используется для создания копий товаров в корзине, чтобы избежать непосредственного создания объектов с нуля. 
2. Структурный паттерн: Фасад. Предоставляет унифицированный интерфейс к группе интерфейсов в подсистеме, упрощая работу с ней. В данном проекте фасад используется для создания унифицированного интерфейса для взаимодействия с различными компонентами, такими как поиск товаров, добавление их в корзину, выбор способа оплаты и оформление заказа.
3. Поведенческий паттерн: Наблюдатель. Позволяет объектам оповещать другие объекты об изменении своего состояния. В проекте наблюдатель использован для уведомления покупателей об изменении цены товара.
