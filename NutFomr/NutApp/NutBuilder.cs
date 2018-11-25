using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;

namespace NutApp
{
    public class NutBuilder
    {
        /// <summary>
        /// Экземпляр компаса
        /// </summary>
        private KompasObject _kompas;

        ksPart Part;
        ksEntity EntityDraw;
        Document3D doc3D;



        /// <summary>
        /// Конструкток класса NutBuilder
        /// </summary>
        /// <param name="kompasObj">Экземпляр КОМПАС'а передаваемый в построитель</param>
        public NutBuilder(KompasObject kompasObj)
        {
            this._kompas = kompasObj;
        }

        /// <summary>
        /// Метод построение детали(гайки)
        /// </summary>
        /// <param name="nutParameters"></param>
        public void BuildDetail(NutParameters nutParameters)
        {
            
            doc3D = _kompas.Document3D();
            doc3D.Create(false, true);

            BuildModel(nutParameters.Dnom, nutParameters.DiametrOut);            BuildExtrusion(nutParameters.Heigth);            BuildChamfer(nutParameters.Dnom, nutParameters.Angle);            BuildIndentation(nutParameters.DiametrOut, nutParameters.Heigth);
        }

        /// <summary>
        /// Построение начального эскиза с номинальным диаметром и внешнем диаметром
        /// </summary>
        /// <param name="dNom">Номинальный диаметр резьбы</param>
        /// <param name="diametrOut">Внешний диаметр резьбы</param>
        private void BuildModel(double dNom, double diametrOut)
        {
            #region Константы для эскиза
            // Тип компо­нента Get Param. Главный компонент, в составе которо­го находится новый или редактируе­мый компонент.
            const int pTop_part = -1;

            //Тип объекта NewEntity. Указывает на создание эскиза.
            const int o3d_sketch = 5;

            // Тип объекта GetDefaultEntity. Указывает на работу в плостости XOY.
            const int o3d_planeXOY = 1;
            #endregion

            //Получаем интерфейс 3D-модели 
            Part = doc3D.GetPart(pTop_part);
            //Получаем интерфейс объекта "Эскиз"
            EntityDraw = Part.NewEntity(o3d_sketch);
            //Получаем интерфейс параметров эскиза
            ksSketchDefinition SketchDefinition = EntityDraw.GetDefinition();
            //Получаем интерфейс объекта "плоскость XOY"
            ksEntity EntityPlane = Part.GetDefaultEntity(o3d_planeXOY);
            //Устанавливаем плоскость XOY базовой для эскиза
            SketchDefinition.SetPlane(EntityPlane);
            //Создаем эскиз
            EntityDraw.Create();
            //Входим в режим редактирования эскиза
            ksDocument2D Document2D = SketchDefinition.BeginEdit();
            //Строим окружность (Указывается радиус, поэтому диаметр делим попалам)
            Document2D.ksCircle(0, 0, dNom / 2, 1);
            Document2D.ksCircle(0, 0, diametrOut / 2, 1);
            //Выходим из режима редактирования эскиза
            SketchDefinition.EndEdit();
        }

        /// <summary>
        /// Операция выдавливания карказа
        /// </summary>
        /// <param name="heigth">Высота гайки</param>
        private void BuildExtrusion(double heigth)
        {
            #region Константы для выдавливания
            //Тип объекта NewEntity. Указывает на создание операции выдавливания.
            const int o3d_baseExtrusion = 24;
            // Тип обекта DrawMode. Устанавливает полутоновое изображение модели
            const int vm_Shaded = 3;
            //Тип выдавливания. Строго на глубину
            const int etBlind = 0;
            #endregion

            //Получаем интерфейс объекта "операция выдавливание"
            ksEntity EntityExtrusion = Part.NewEntity(o3d_baseExtrusion);
            //Получаем интерфейс параметров операции "выдавливание"
            ksBaseExtrusionDefinition BaseExtrusionDefinition = EntityExtrusion.GetDefinition();
            //Устанавливаем параметры операции выдавливания
            BaseExtrusionDefinition.SetSideParam(true, etBlind, heigth, 0, true);
            //Устанавливаем эскиз операции выдавливания
            BaseExtrusionDefinition.SetSketch(EntityDraw);
            //Создаем операцию выдавливания
            EntityExtrusion.Create();
            //Устанавливаем полутоновое изображение модели
            doc3D.drawMode = vm_Shaded;
            //Включаем отображение каркаса
            doc3D.shadedWireframe= true;
        }

        /// <summary>
        /// Операция "Фаска" для всех граней
        /// </summary>
        /// <param name="dNom">Номинальный диметр резьбы</param>
        /// <param name="angle">Угол фаски головки</param>
        private void BuildChamfer(double dNom, int angle)
        {
            #region Константы для фаски
            // Тип получения массива объектов. Выбираются поверхности.
            const int o3d_face = 6;
            // Тип объекта NewEntity. Указывает на операцию "Фаска"
            const int o3d_chamfer = 33;
            //Устанавливаем значение коэфициента для расчета угла фаски через второй катет            
            double index = (angle == 15) ? 3.732 : 1.732;
            #endregion

            //Получаем интерфейс объекта "фаска"
            ksEntity EntityChamfer = (Part.NewEntity(o3d_chamfer));
            //Получаем интерфейс параметров объекта "скругление"
            ksChamferDefinition ChamferDefinition = EntityChamfer.GetDefinition();
            //Не продолжать по касательным ребрам
            ChamferDefinition.tangent = true;
            //Устанавливаем параметры фаски
            ChamferDefinition.SetChamferParam(true, dNom/10, (dNom/10)/ index);
            //Получаем массив граней детали
            ksEntityCollection EntityCollectionPart = (Part.EntityCollection(o3d_face));
            //Получаем массив граней, на которых будет строиться фаска
            ksEntityCollection EntityCollectionChamfer = (ChamferDefinition.array());
            EntityCollectionChamfer.Clear();
            //Заполняем массив граней, на которых будет строится фаска (все грани)
            for(int i = 0; i < 4; i++)
            {
                EntityCollectionChamfer.Add(EntityCollectionPart.GetByIndex(i));
            }            
            //Создаем фаску
            EntityChamfer.Create();
        }

        /// <summary>
        /// Вдавливание
        /// </summary>
        private void BuildIndentation(double diametrOut, double heigth)
        {
            #region Константы для вдавливания и построения шестиугольника
            //Тип объекта NewEntity. Указывает на создание эскиза.
            const int o3d_sketch = 5;

            // Тип объекта GetDefaultEntity. Указывает на работу в плостости XOY.
            const int o3d_planeXOY = 1;
            // Тип объекта GetParamStruct. Указывает на построение многоугольника.
            const int ko_RegularPolygonParam = 92;
            //Тип выдавливания. Строго на глубину.
            const int etBlind = 0;
            //Тип объекта NewEntity. Вырезать выдавливанием.
            const int o3d_CutExtrusion = 26;
            //Тип направления вырезания. Обратное направление.
            const int dtReverse = 1;
            #endregion

            #region Задание параметров шестиугольника
            //
            ksRegularPolygonParam hexagon;
            hexagon = _kompas.GetParamStruct(ko_RegularPolygonParam);
            // Количество вершин
            hexagon.count = 6;
            // Координаты центра окружности
            hexagon.xc = 0;
            hexagon.yc = 0;
            // Угол радиус-вектора
            hexagon.ang = 0;
            // Построить по описанной окружности
            hexagon.describe = false;
            // Радиус окружности
            hexagon.radius = diametrOut / 2;
            // Стиль линии
            hexagon.style = 1;
            #endregion

            //Получаем интерфейс объекта "Эскиз"
            EntityDraw = Part.NewEntity(o3d_sketch);
            //Получаем интерфейс параметров эскиза
            ksSketchDefinition SketchDefinition = EntityDraw.GetDefinition();
            //Получаем интерфейс объекта "плоскость XOY"
            ksEntity EntityPlane = Part.GetDefaultEntity(o3d_planeXOY);
            //Устанавливаем плоскость XOY базовой для эскиза
            SketchDefinition.SetPlane(EntityPlane);
            //Создаем эскиз
            EntityDraw.Create();
            //Входим в режим редактирования эскиза
            ksDocument2D Document2D = SketchDefinition.BeginEdit();
            //Строим окружность многобольшего диаметра
            Document2D.ksCircle(0, 0, diametrOut + 3, 1);
            //Строим шестиугольник даметром равным внешнему диаметру
            Document2D.ksRegularPolygon(hexagon,0);
            //Выходим из режима редактирования эскиза
            SketchDefinition.EndEdit();

            //Получаем интерфейс объекта "операция вырезание выдавливанием"
            ksEntity EntityCutExtrusion = (Part.NewEntity(o3d_CutExtrusion));
            //Получаем интерфейс параметров операции
            ksCutExtrusionDefinition CutExtrusionDefinition = (EntityCutExtrusion.GetDefinition());
            //Вычитание элементов
            CutExtrusionDefinition.cut= true;
            //Обратное направление
            CutExtrusionDefinition.directionType= dtReverse;
            //Устанавливаем параметры выдавливания
            CutExtrusionDefinition.SetSideParam(true, etBlind, (heigth + 3), 0, false);
            //Устанавливаем экиз операции
            CutExtrusionDefinition.SetSketch(SketchDefinition);
            //Создаем операцию вырезания выдавливанием
            EntityCutExtrusion.Create();

        }

        /// <summary>
        /// Резьба
        /// </summary>
        private void BuildThread()
        {

        }
    }
}
