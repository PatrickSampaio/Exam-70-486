using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeTest
{
    class Program
    {
        private static string PresentationDir = "C:\\PPTX\\";
        static void Main(string[] args)
        {
            Presentation pres = new Presentation();         
            pres = AddLayoutToPresentantion(pres);
            pres = setSlideNumber(pres);

            SavePresentation(pres);
            pres.Dispose();
        }

        public static ISlide AddAutoShape(ISlide slid)
        {
            slid.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
            return slid;
        }

        public static void SavePresentation(Presentation pres)
        {
            pres.Save(PresentationDir + "NewPresentation.pptx", SaveFormat.Pptx);
        }

        public static Presentation AddLayoutToPresentantion(Presentation pres)
        {
            IMasterLayoutSlideCollection slidesLayout = pres.Masters[0].LayoutSlides;
            ILayoutSlide slideLayout = slidesLayout.GetByType(SlideLayoutType.TitleAndObject) ?? slidesLayout.GetByType(SlideLayoutType.Title);

            if(slideLayout == null)
            {
                slideLayout = slidesLayout.ToList().Where((x) => x.Name == "Title and Object").Single();

                if(slideLayout == null)
                {
                    slideLayout = slidesLayout.ToList().Where((x) => x.Name == "Title").Single();

                    if(slideLayout == null)
                    {
                        slideLayout = slidesLayout.GetByType(SlideLayoutType.Blank);
                        if (slideLayout == null)
                            slideLayout = slidesLayout.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                    }
                }
            }

            pres.Slides.InsertEmptySlide(0, slideLayout);
            return pres;
        }

        public static Presentation setSlideNumber(Presentation pres)
        {
            int firstSlideNumber = pres.FirstSlideNumber;
            pres.FirstSlideNumber = 10;
            return pres;
        } 
    }
}
