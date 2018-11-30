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
        /// Конструктор класса NutBuilder
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

            BuildModel(nutParameters.DiametrIn, nutParameters.DiametrOut);
            BuildExtrusion(nutParameters.Height);
            BuildChamfer(nutParameters.DiametrIn, nutParameters.Angle, nutParameters.KeyParam);
            BuildIndentation(nutParameters.DiametrOut, nutParameters.Height);
            BuildThread(nutParameters.Dnom, nutParameters.Height, nutParameters.DiametrIn);

        }

        /// <summary>
        /// Построение начального эскиза с номинальным диаметром и внешнем диаметром
        /// </summary>
        /// <param name="dNom">Номинальный диаметр резьбы</param>
        /// <param name="diametrOut">Внешний диаметр резьбы</param>
        private void BuildModel(double diameterIn, double diametrOut)
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
            Document2D.ksCircle(0, 0, diameterIn / 2, 1);
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
        private void BuildChamfer(double diameterIn, int angle, double keyParam)
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
            ksEntity EntityChamferOut = (Part.NewEntity(o3d_chamfer));
            ksEntity EntityChamferIn = (Part.NewEntity(o3d_chamfer));

            //Получаем интерфейс параметров объекта "скругление"
            ksChamferDefinition ChamferDefinitionOut = EntityChamferOut.GetDefinition();
            ksChamferDefinition ChamferDefinitionIn = EntityChamferIn.GetDefinition();

            //Не продолжать по касательным ребрам
            ChamferDefinitionOut.tangent = false;
            ChamferDefinitionIn.tangent = false;

            //Устанавливаем параметры фаски внешней поверхности
            ChamferDefinitionOut.SetChamferParam(true, diameterIn / 10, (diameterIn / 10) / index);
            //Устанавливаем параметры фаски внутренней поверхности
            ChamferDefinitionIn.SetChamferParam(true, keyParam / 10, (keyParam / 10) / index);

            //Получаем массив поверхностей детали
            ksEntityCollection EntityCollectionPart = (Part.EntityCollection(o3d_face));

            //Получаем массив поверхностей, на которых будет строиться фаска
            ksEntityCollection EntityCollectionChamferOut = (ChamferDefinitionOut.array());
            ksEntityCollection EntityCollectionChamferIn = (ChamferDefinitionIn.array());
            EntityCollectionChamferOut.Clear();
            EntityCollectionChamferIn.Clear();

            //Заполняем массив поверхностей, на которых будет строится фаска (Внешняя поверхность)
            EntityCollectionChamferOut.Add(EntityCollectionPart.GetByIndex(2));
            //Заполняем массив поверхностей, на которых будет строится фаска (Внутреняя поверхность)
            EntityCollectionChamferIn.Add(EntityCollectionPart.GetByIndex(1));

            //Создаем фаску
            EntityChamferOut.Create();
            EntityChamferIn.Create();
        }

        /// <summary>
        /// Операция "Вырезание выдавливанием"
        /// </summary>
        /// <param name="diametrOut">Внешний диаметр резьбы</param>
        /// <param name="heigth">Высота гайки</param>
        private void BuildIndentation(double diametrOut, double heigth)
        {
            #region Константы для вырезания и построения шестиугольника
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
        /// Операция "Резьба"
        /// </summary>
        /// <param name="diametrNom">Номинальный диаметр резьбы</param>
        /// <param name="height">Высота гайки</param>
        /// <param name="diametrIn">Внутренний диаметр резьбы</param>
        private void BuildThread(double diametrNom, double height, double diametrIn)
        {
            #region Константы для резьбы

            // Тип компо­нента Get Param. Главный компонент, в составе которо­го находится новый или редактируе­мый компонент.
            const int pTop_part = -1;

            //Тип объекта NewEntity. Указывает на создание эскиза.
            const int o3d_planeOffset = 14;

            //Тип объекта NewEntity. Указывает на создание эскиза.
            const int o3d_sketch = 5;

            // Тип объекта GetDefaultEntity. Указывает на работу в плостости XOY.
            const int o3d_planeXOY = 1;

            // Тип объекта GetDefaultEntity. Указывает на работу в плостости XOZ.
            const int o3d_planeXOZ = 2;

            //Тип объекта NewEntity. Указывает на цилиндрическую спираль
            const int o3d_cylindricSpiral = 56;

            //Коэффициент для расчета угла в 15°
            double index = (diametrNom / 10) / 1.6667;

            //Расстояние для резьбы
            double threadLength = diametrNom - diametrIn;

            //Тип объекта NewEntity. Указывает на создание кинематического вырезания.
            const int o3d_cutEvolution = 47;

            //TODO: Понять почему нужно дополнительно смещать на сотую долю номинального диаметра для совпадения с диаметром фаски 
            //Начальная точка фигуря для резьбы
            double xStart = diametrNom / 2 + diametrNom/100;

            #endregion

            //Получаем интерфейс 3D-модели 
            Part = doc3D.GetPart(pTop_part);
            //Получаем интерфейс объекта "смещенная плоскость"
            ksEntity entityDrawOffset = Part.NewEntity(o3d_planeOffset);
            //Получаем интерфейс параметров смещенной плоскости
            ksPlaneOffsetDefinition planeDefinition = entityDrawOffset.GetDefinition();
            //Задаем расстояние смещенной плоскости от объекта
            planeDefinition.offset = 1;
            //Задаем направление смещенной плоскости
            planeDefinition.direction = false;
            //Получаем интерфейс объекта "плоскость XOY"
            ksEntity EntityPlaneOffset = Part.GetDefaultEntity(o3d_planeXOY);
            //Получаем базовую плоскость смещенной плоскости по "XOY"
            planeDefinition.SetPlane(EntityPlaneOffset);
            //Создаем смещенную плоскость
            entityDrawOffset.Create();

            //Получаем интерфейс объекта "Цилиндрическая спираль"
            ksEntity entityCylinderic = Part.NewEntity(o3d_cylindricSpiral);
            //Получаем интерфейс параметров цилиндрической спирали
            ksCylindricSpiralDefinition cylindricSpiral = entityCylinderic.GetDefinition();

            cylindricSpiral.SetPlane(entityDrawOffset);

            cylindricSpiral.buildDir = true;
            cylindricSpiral.buildMode = 1;
            cylindricSpiral.height = planeDefinition.offset + height + 1;
            cylindricSpiral.diam = diametrNom;
            cylindricSpiral.firstAngle = 0;
            cylindricSpiral.turnDir = true;
            cylindricSpiral.step = 0.4;
            entityCylinderic.Create();

            //Получаем интерфейс объекта "Эскиз"
            EntityDraw = Part.NewEntity(o3d_sketch);
            //Получаем интерфейс параметров эскиза
            ksSketchDefinition sketchDefinition = EntityDraw.GetDefinition();
            //Получаем интерфейс объекта "плоскость XOZ"
            ksEntity EntityPlane = Part.GetDefaultEntity(o3d_planeXOZ);
            //Получить базовую плоскость эскиза
            sketchDefinition.SetPlane(EntityPlane);
            //Создаем эскиз
            EntityDraw.Create();
            //Входим в режим редактирования эскиза
            Document2D document2D = sketchDefinition.BeginEdit();

            #region Построение фигуры для выдавливания резьбы
            
            //Построение верхней части левого отрезка
            document2D.ksLineSeg(xStart, (planeDefinition.offset), xStart, (planeDefinition.offset + (index / 2) ), 1);
            //Построение нижней части левого отрезка
            document2D.ksLineSeg(xStart, (planeDefinition.offset), xStart, (planeDefinition.offset - (index / 2) ), 1);
            //Построение верхней части правого отрезка
            document2D.ksLineSeg((xStart - threadLength), (planeDefinition.offset), (xStart - threadLength),
                (planeDefinition.offset + (index * 1.89318) / 2), 1);
            //Построение нижней части правого отрезка
            document2D.ksLineSeg((xStart - threadLength), (planeDefinition.offset), (xStart - threadLength),
                (planeDefinition.offset - (index * 1.89318) / 2), 1);
            //Поединение верхних частей отрезка
            document2D.ksLineSeg(xStart, (planeDefinition.offset + (index / 2)), (xStart - threadLength),
                (planeDefinition.offset + (index * 1.89318) / 2), 1);
            //Соединение нижних частей отрезка
            document2D.ksLineSeg(xStart, (planeDefinition.offset - (index / 2)), (xStart  - threadLength), 
                (planeDefinition.offset - (index * 1.89318) / 2),1);

            #endregion

            //Выходим из режима редактирования эскиза
            sketchDefinition.EndEdit();

            //Получаем интерфейс операции
            ksEntity entityCutEvolution= Part.NewEntity(o3d_cutEvolution);
            //Получаем интерфейс параметров операции
            ksCutEvolutionDefinition cutEvolutionDefinition = entityCutEvolution.GetDefinition();
            //Вычитане объектов
            cutEvolutionDefinition.cut= true;
            //Тип движения
            cutEvolutionDefinition.sketchShiftType= 1;
            //Устанавливаем эскиз сечения
            cutEvolutionDefinition.SetSketch(sketchDefinition);
            //Получаем массив объектов
            ksEntityCollection EntityCollection = (cutEvolutionDefinition.PathPartArray());
            EntityCollection.Clear();
            //Добавляем в массив эскиз с траекторией
            EntityCollection.Add(entityCylinderic);
            //Создаем операцию
            entityCutEvolution.Create();
        }
    }
}
