
// Note
// 1. Названия руд, а именно их типы. Это всего лишь вьюшка для руды. Она не должна содержать в себе что либо.
// 2. Руде нужен конфиг с данными: Названия и иконка для инвенторя.
// 3. У OreResources тоесть руды есть 100% коллайдер
// 4. 100% Pickable


namespace RimuruDev.DotNetDesignPattern.SOLID.OCP
{
    public sealed class Gold : OreResources<Gold> { }
}