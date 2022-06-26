using KantriStore.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;
using MvvmHelpers;

namespace KantriStore.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public IList<Category> Categories { get; set; }

        public CategoryViewModel()
        {
            Categories = new ObservableCollection<Category>()
            {
                new Category()
                {
                    Id = 1,
                    NameCategory = "Спецодежда",
                    ImageUrl = "https://habrastorage.org/webt/km/ny/rx/kmnyrx7lwzyc1bbzca5oez45imc.png"
                },
                new Category()
                {
                    Id = 2,
                    NameCategory = "Охота и рыбалка",
                    ImageUrl = "https://habrastorage.org/webt/r9/mq/ej/r9mqej546-hwg3v717k1vj77m4q.png"
                },
                new Category()
                {
                    Id = 3,
                    NameCategory = "Спецобувь",
                    ImageUrl = "https://habrastorage.org/webt/hk/cd/q6/hkcdq6ulrwm5zcsr_7tf12owenm.png"
                },
                new Category()
                {
                    Id = 4,
                    NameCategory = "Летняя обувь",
                    ImageUrl = "https://habrastorage.org/webt/y_/5k/so/y_5ksozeefdxwo9i4q2kqccqeo0.png"
                },
                new Category()
                {
                    Id = 5,
                    NameCategory = "Аляска, Дутыши",
                    ImageUrl = "https://habrastorage.org/webt/4j/d_/7b/4jd_7bsaaue7llzzjizzswlzvm8.png"
                },
                new Category()
                {
                    Id = 6,
                    NameCategory = "Зимняя обувь",
                    ImageUrl = "https://habrastorage.org/webt/mb/dc/lj/mbdcljkis_a4ji2z2dntned1mgs.png"
                },
                new Category()
                {
                    Id = 7,
                    NameCategory = "Домашняя обувь",
                    ImageUrl = "https://habrastorage.org/webt/j6/9i/xh/j69ixh9mjkzniwepdumztrurfhc.png"
                },
                new Category()
                {
                    Id = 8,
                    NameCategory = "Обувь ПВХ",
                    ImageUrl = "https://habrastorage.org/webt/2b/j1/p6/2bj1p6w9qpsiwqz3lhhaurieute.png"
                }
            };
        }
    }
}
